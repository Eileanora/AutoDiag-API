using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using IntelligentDiagnostician.API.Helpers.Facades.CarSystemCollectionControllerFacade;
using IntelligentDiagnostician.API.Helpers.InputValidator;

namespace IntelligentDiagnostician.API.Controllers;

[ApiController]
[Route("api/v1/carsystemcollections")]
public class CarSystemCollectionController(ICarSystemCollectionControllerFacade carSystemControllerFacade) : ControllerBase
{
    [HttpGet("({carSystemIds})", Name = "GetCarSystemCollection")]
    public async Task<ActionResult<IEnumerable<CarSystemDto>>> GetCarSystemCollection(
        [FromRoute] string carSystemIds)
    {
        var carSystemIdsArray = carSystemIds.Split(",");
        var carSystemCollection = new List<CarSystemDto>();
        foreach (var carSystemId in carSystemIdsArray)
        {
            var carSystem = await carSystemControllerFacade.CarSystemManager.GetByIdAsync(int.Parse(carSystemId));
            if (carSystem != null)
                carSystemCollection.Add(carSystem);
        }
        if (carSystemCollection.Count == 0)
            return NotFound();
        return Ok(carSystemCollection);
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<CarSystemDto>>> CreateCarSystemCollection(
        IEnumerable<CarSystemForCreationDto> carSystemCollection)
    {
        // BUG: inputting a list with more than one item with the same name will result in some items created and some not
        // DesiredBehavior: DO NOT ADD ANY ITEM
        // TODO: Rollback and commit in EF
        var carSystemToReturn = new List<CarSystemDto>();
        foreach(var carSystem in carSystemCollection)
        {
            // validate input
            var validationResult = await carSystemControllerFacade.CreationValidator.ValidateAsync(
                carSystem,
                options => options.IncludeRuleSets("Input"));
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return ValidationProblem(ModelState);
            }
            
            var newCarSystem = await carSystemControllerFacade.CarSystemManager.CreateAsync(carSystem);
            if (newCarSystem != null)
                carSystemToReturn.Add(newCarSystem);
        }
        var arrayKey = string.Join(",",
            carSystemToReturn.Select(c => c.Id));
        return CreatedAtRoute("GetCarSystemCollection",
            new { carSystemIds = arrayKey },
            carSystemToReturn);
    }
}
