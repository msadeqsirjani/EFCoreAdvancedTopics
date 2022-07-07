using BenchmarkDotNet.Running;
using EfCoreTopics.ChangeTrackerBenchmark;
using EfCoreTopics.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AdventureWorksContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

BenchmarkRunner.Run<EfCoreChangeTrackerBenchmark>();

app.Run();