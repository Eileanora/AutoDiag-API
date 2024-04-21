using IntelligentDiagnostician.BL.Services.CurrentUserService;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace IntelligentDiagnostician.DAL.Interceptors;

public sealed class UpdateAuditFieldsInterceptor(
    ICurrentUserService currentUserService)
    : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        DbContext? dbContext = eventData.Context;
        if (dbContext is null)
        {
            return base.SavingChangesAsync(
                eventData,
                result,
                cancellationToken);
        }

        var currentUser = currentUserService.GetCurrentUser();
        Guid? currentUserId = currentUser.IsAuthenticated ? currentUser.UserId : (Guid?)null;

        IEnumerable<EntityEntry<IAuditFields>> entries = dbContext
            .ChangeTracker
            .Entries<IAuditFields>();

        foreach (var entityEntry in entries)
        {
            if (entityEntry.Entity is AppUser)
                SetUserAuditFields(entityEntry, currentUserId);
            
            if (entityEntry.Entity is not AppUser)
                SetEntitesAuditFields(entityEntry, currentUserId);
        }
        return base.SavingChangesAsync(
            eventData,
            result,
            cancellationToken);
    }
    
    void SetUserAuditFields(EntityEntry<IAuditFields> entityEntry, Guid? currentUserId)
    {
        if (entityEntry.State == EntityState.Added)
        {
            entityEntry.Property(e => e.CreatedDate).CurrentValue = DateTime.Now;
        }

        if (entityEntry.State == EntityState.Modified)
        {
            entityEntry.Property(e => e.ModifiedDate).CurrentValue = DateTime.Now;
            if (currentUserId.HasValue)
                entityEntry.Property(e => e.ModifiedBy).CurrentValue = currentUserId.Value;
        }
    }
    
    void SetEntitesAuditFields(EntityEntry<IAuditFields> entityEntry, Guid? currentUserId)
    {
        if (entityEntry.State == EntityState.Added)
        {
            entityEntry.Property(e => e.CreatedDate).CurrentValue = DateTime.Now;
            if (currentUserId.HasValue)
                entityEntry.Property(e => e.CreatedBy).CurrentValue = currentUserId.Value;
        }
        if (entityEntry.State == EntityState.Modified)
        {
            entityEntry.Property(e => e.ModifiedDate).CurrentValue = DateTime.Now;
            if (currentUserId.HasValue)
                entityEntry.Property(e => e.ModifiedBy).CurrentValue = currentUserId.Value;
        }
    }
}
