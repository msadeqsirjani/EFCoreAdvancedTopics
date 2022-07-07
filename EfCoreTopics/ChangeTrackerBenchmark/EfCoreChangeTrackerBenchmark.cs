using BenchmarkDotNet.Attributes;
using EfCoreTopics.Database;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTopics.ChangeTrackerBenchmark;

[MemoryDiagnoser]
[SimpleJob(-1, 3, 10)]
public class EfCoreChangeTrackerBenchmark
{

    [Benchmark]
    public void WithEnabledChangeTracker()
    {
        using var context = new AdventureWorksContext();

        var addresses = context.Addresses.Take(10000).ToList();

        foreach (var address in addresses.Where(address => address.AddressId % 2 == 0))
        {
            address.City = "Mashhad";
            context.SaveChanges();
        }
    }

    [Benchmark]
    public void WithDisabledChangeTracker()
    {
        using var context = new AdventureWorksContext();

        context.ChangeTracker.AutoDetectChangesEnabled = false;

        var addresses = context.Addresses.Take(10000).ToList();

        foreach (var address in addresses.Where(address => address.AddressId % 2 == 0))
        {
            context.Entry(address).State = EntityState.Modified;
            address.City = "Mashhad";
            context.SaveChanges();
        }
    }
}