using EfCoreTopics.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetNonInterpolatedAddresses(int id) =>
        Ok(await _context.GetAddressNonInterpolatedAsync(id));

    [HttpGet]
    public async Task<IActionResult> GetInterpolatedAddresses(int id) =>
        Ok(await _context.GetAddressInterpolatedAsync(id));

    [HttpPost]
    public async Task<IActionResult> UpdateCity(int id, string city) =>
        Ok(await _context.UpdateCityAddressAsync(id, city));

    [HttpGet]
    public async Task<IActionResult> GetCityWithProvince() =>
        Ok(await _context.GetCityWithProvince());

    [HttpGet]
    public async Task<IActionResult> GetAddress(string contain) =>
        Ok(await _context.Addresses.Where(x => x.SearchTerm.Contains(contain)).ToListAsync());

    [HttpGet]
    public async Task<IActionResult> GetCustomerInformation(int customerId) =>
        Ok(await _context.GetCustomerInformation(customerId).FirstOrDefaultAsync());

    [HttpGet]
    public async Task<IActionResult> GetAllCategories() =>
        Ok(await _context.GetAllCategories().ToListAsync());
}