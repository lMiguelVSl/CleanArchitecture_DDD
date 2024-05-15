using CleanArchitecture.Data.Context;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

StreamerContext context = new();
//await AddNewRecords();
//await QueryFilter();
await TrackingAndNotTracking();
Console.ReadLine();
return;

async Task TrackingAndNotTracking()
{
    var streamerTracking = await context.Streamers!.FirstOrDefaultAsync(x => x.Id == 1);
    var streamerNotTracking = await context.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);
    
    streamerTracking.Name = "Streamer 1 tracking";
    streamerNotTracking.Name = "Streamer 2 no tracking";
    await context.SaveChangesAsync();
}

async Task QueryLinq()
{
    Console.WriteLine("Enter a streamer name:");
    var streamerName = Console.ReadLine();
    
    var streamers = await (from i in context.Streamers where EF.Functions.Like(i.Name, $"%{streamerName}%") select i).ToListAsync();
    streamers.ForEach(x => Console.WriteLine($"streamer: {x.Name}, with ID {x.Id}"));
}

async Task QueryMethods()
{
    var streamerContextValue = context.Streamers;
    var streamer_1 = await streamerContextValue!.Where(e => e.Name!.Contains("t")).FirstAsync();
    var streamer_2 = await streamerContextValue!.Where(e => e.Name!.Contains("t")).FirstOrDefaultAsync();
    var streamer_3 = await streamerContextValue!.FirstOrDefaultAsync(e => e.Name!.Contains("t"));
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