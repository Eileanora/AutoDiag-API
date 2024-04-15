using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace IntelligentDiagnostician.DAL.Interceptors;

public sealed class UpdateAuditFieldsInterceptor : SaveChangesInterceptor
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

        IEnumerable<EntityEntry<IAuditFields>> entries = dbContext
            .ChangeTracker
            .Entries<IAuditFields>();

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
                entityEntry.Property(e => e.CreatedDate).CurrentValue = DateTime.Now;
            
            if (entityEntry.State == EntityState.Modified)
                entityEntry.Property(e => e.ModifiedDate).CurrentValue = DateTime.Now;
            
        }
        return base.SavingChangesAsync(
            eventData,
            result,
            cancellationToken);
    }
}
