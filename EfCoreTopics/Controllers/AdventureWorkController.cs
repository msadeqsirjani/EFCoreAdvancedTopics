using EfCoreTopics.Database;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreTopics.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AdventureWorkController : ControllerBase
{
    private readonly AdventureWorksContext _context;

    public AdventureWorkController(AdventureWorksContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IResult> GetNonInterpolatedAddresses(int id) =>
        Results.Ok(await _context.GetAddressNonInterpolatedAsync(id));

    [HttpGet]
    public async Task<IResult> GetInterpolatedAddresses(int id) =>
        Results.Ok(await _context.GetAddressInterpolatedAsync(id));

    [HttpPost]
    public async Task<IResult> UpdateCity(int id, string city) =>
        Results.Ok(await _context.UpdateCityAddressAsync(id, city));

    [HttpGet]
    public async Task<IResult> GetCityWithProvince() =>
        Results.Ok(await _context.GetCityWithProvince());
}