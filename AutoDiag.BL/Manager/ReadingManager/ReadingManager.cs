﻿using AutoDiag.BL.DTOs.ReadingDTOs;
using AutoDiag.BL.ResourceParameters;
using AutoDiag.BL.Helpers.Facades.ReadingManagerFacade;
using FluentValidation;
using AutoDiag.BL.Helpers.Converter;

namespace AutoDiag.BL.Manager.ReadingManager;

public class ReadingManager : IReadingManager
{
    private readonly IReadingManagerFacade _readingManagerFacade;
    public ReadingManager(IReadingManagerFacade readingManagerFacade)
    {
        _readingManagerFacade = readingManagerFacade;
    }
    public async Task CreateAsync(
        Guid userId, Dictionary<int, float> readings)
    {
        var userIdValidationResult = await _readingManagerFacade.UserIdValidator.ValidateAsync(userId);
        if (userIdValidationResult.IsValid)
        {
            foreach (var sensorId in readings)
            {
                var readingForCreationDto = new ReadingForCreationDto
                {
                    SensorId = sensorId.Key,
                    UserId = userId,
                    Value = sensorId.Value
                };
                var validationResult = await _readingManagerFacade.CreationValidator.ValidateAsync(
                    readingForCreationDto,
                    options => options.IncludeRuleSets("Business"));

                if (!validationResult.IsValid)
                    return;

                var newReading = readingForCreationDto.ToReading();
                await _readingManagerFacade.ReadingRepository.CreateAsync(newReading);
            }
        }        

        await _readingManagerFacade.UnitOfWork.SaveAsync();
    }

    public async Task<PagedList<ReadingDto>> GetAllAsync(
        int sensorId,
        ReadingResourceParameters resourceParameters)
    {
        var currentUserId = _readingManagerFacade
            .CurrentUserService.GetCurrentUser().UserId;
        
        if (currentUserId == Guid.Empty)
            throw new UnauthorizedAccessException("User is not authorized to access this resource");
        
        var userId = currentUserId.ToString();
        
        var readings =  await _readingManagerFacade
            .ReadingRepository
            .GetAllAsync(sensorId, userId, resourceParameters);
        return readings.ToListDto();
    }
}
