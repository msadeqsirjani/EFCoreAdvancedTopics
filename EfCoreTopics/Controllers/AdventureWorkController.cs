using EfCoreTopics.Database;
using EfCoreTopics.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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

    #region Interpolated SQL

    [HttpGet]
    public async Task<IActionResult> GetNonInterpolatedAddresses(int id) =>
        Ok(await _context.GetAddressNonInterpolatedAsync(id));

    [HttpGet]
    public async Task<IActionResult> GetInterpolatedAddresses(int id) =>
        Ok(await _context.GetAddressInterpolatedAsync(id));

    [HttpPost]
    public async Task<IActionResult> UpdateCity(int id, string city) =>
        Ok(await _context.UpdateCityAddressAsync(id, city));

    // key less entity
    [HttpGet]
    public async Task<IActionResult> GetCityWithProvince() =>
        Ok(await _context.GetCityWithProvince());

    #endregion

    #region Computed Column

    [HttpGet]
    public async Task<IActionResult> GetAddress(string contain) =>
        Ok(await _context.Addresses.Where(x => x.SearchTerm.Contains(contain)).ToListAsync());

    #endregion

    #region DbFunctions

    [HttpGet]
    public async Task<IActionResult> GetCustomerInformation(int customerId) =>
        Ok(await _context.GetCustomerInformation(customerId).FirstOrDefaultAsync());

    [HttpGet]
    public async Task<IActionResult> GetAllCategories() =>
        Ok(await _context.GetAllCategories().ToListAsync());

    #endregion

    #region Views

    [HttpGet]
    public async Task<IActionResult> GetCategories(int categoryId) =>
        Ok(await _context.VGetAllCategories.Where(x => x.ProductCategoryId > categoryId).ToListAsync());

    #endregion

    #region New LINQ Features

    [HttpGet]
    public async Task<IActionResult> GetProductWithMaxWeight()
    {
        var products = await _context.Products.AsNoTracking().ToListAsync();

        var product = products.MaxBy(x => x.Weight);

        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetProductWithMinWeight()
    {
        var products = await _context.Products.AsNoTracking().ToListAsync();

        var product = products.MinBy(x => x.Weight);

        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetProductWithDistinctSize()
    {
        var products = await _context.Products.AsNoTracking().ToListAsync();

        products = products.DistinctBy(x => x.Size).ToList();

        return Ok(products);
    }

    [HttpGet]
    public async Task<IActionResult> GetRedAndHeavyProducts()
    {
        var averageProductWeight = await _context.Products.AsNoTracking().AverageAsync(x => x.Weight);

        var redProducts = await _context.Products.AsNoTracking().Where(x => x.Color == "Red").ToListAsync();
        var heavyProducts = await _context.Products.AsNoTracking().Where(x => x.Weight >= averageProductWeight).ToListAsync();

        var products = redProducts.IntersectBy(heavyProducts.Select(x => x.ProductId), product => product.ProductId)
            .ToList();

        return Ok(products);
    }

    [HttpGet]
    public async Task<IActionResult> GetChunkProducts()
    {
        var products = await _context.Products.AsNoTracking().ToListAsync();

        return Ok(products.Chunk(10));
    }

    [HttpGet]
    public async Task<IActionResult> GetNthFromLastProduct(int index)
    {
        var products = await _context.Products.AsNoTracking().OrderBy(x => x.ProductId).ToListAsync();

        return Ok(products.ElementAt(Index.FromEnd(index)));
    }

    [HttpGet]
    public async Task<IActionResult> GetRangeOfProducts(int start, int end)
    {
        var products = await _context.Products.AsNoTracking().ToListAsync();

        return Ok(products.Take(start..(start + end)));
    }

    #endregion
}