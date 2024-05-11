using CleanArchitecture.Data.Context;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

StreamerContext context = new();
await AddNewRecords();
await QueryFilter();
Console.ReadLine();
return;

async Task QueryMethods()
{
    
}

async Task QueryFilter()
{
    Console.WriteLine("Enter a streaming company:");
    var streamingCompany = Console.ReadLine() ?? "";
    var streamers = await context.Streamers!.Where(s => s.Name!.Equals(streamingCompany)).ToListAsync();
    streamers.ForEach(x => Console.WriteLine($"Streamer Query: {x.Id} - {x.Name}" ));
    
    var streamingPartial = await context.Streamers!.Where(s => EF.Functions.Like(s.Name, $"%{streamingCompany}%")).ToListAsync();
    streamingPartial.ForEach(x => Console.WriteLine($"Streamer Query: {x.Id} - {x.Name}" ));
}

void QueryStreaming()
{
    var streamers = context.Streamers!.ToList();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"Streamer: {streamer.Name}");
    }
}

async Task AddNewRecords()
{
    var streamer = new Streamer
    {
        Name = "Streamer 2",
        Url = "https://test/streamer1"
    };

    context.Streamers!.Add(streamer);
    await context.SaveChangesAsync();

    var movies = new List<Video>
    {
        new()
        {
            Name = "Mad Max",
            StreamerId = streamer.Id
        },
        new()
        {
            Name = "GOT",
            StreamerId = streamer.Id
        },
        new()
        {
            Name = "Fast and furios",
            StreamerId = streamer.Id
        },
        new()
        {
            Name = "Citizen Kane",
            StreamerId = streamer.Id
        }
    };

    await context.AddRangeAsync(movies);
    await context.SaveChangesAsync();
    
    QueryStreaming();
}