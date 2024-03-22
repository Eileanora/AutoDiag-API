using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Controllers;

[ApiController]
[Route("api/v1/carsystemcollections")]
public class CarSystemCollectionController (ICarSystemManager carSystemManager) : ControllerBase
{
    [HttpGet("({carSystemIds})", Name = "GetCarSystemCollection")]
    public async Task<ActionResult<IEnumerable<CarSystemDto>>> GetCarSystemCollection(
        [FromRoute] string carSystemIds)
    {
        var carSystemIdsArray = carSystemIds.Split(",");
        var carSystemCollection = new List<CarSystemDto>();
        foreach (var carSystemId in carSystemIdsArray)
        {
            var carSystem = await carSystemManager.GetByIdAsync(int.Parse(carSystemId));
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
        var carSystemToReturn = new List<CarSystemDto>();
        foreach(var carSystem in carSystemCollection)
        {
            var newCarSystem = await carSystemManager.CreateAsync(carSystem);
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
