using System.Net;
using System.Text.Json;
using CleanArchitecture.App;
using CleanArchitecture.Data.Context;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

StreamerContext context = new();
//await AddNewRecords();
//await QueryFilter();
//await TrackingAndNotTracking();
//await TestWizeLine();
//await AddNewStreamerWithVideo();
//await AddNewStreamerWithVideoId();
//await AddNewActorWithVideo();
await AddNewDirectorWithVideo();
Console.ReadLine();
return;

async Task TestWizeLine()
{
    var client = new HttpClient();
    using var response = await client.GetAsync("https://api.sampleapis.com/cartoons/cartoons2D");
    var jsonResponse = await response.Content.ReadAsStringAsync();
    //Console.WriteLine($"JSON RESPONSE {jsonResponse}");
    var cartoonSerialized = JsonSerializer.Deserialize<List<Cartoon>>(jsonResponse);
    cartoonSerialized?.ForEach(x =>
        Console.WriteLine(
            $"Cartoon: Title: {x.Title}, Year: {x.Year}, Creator: {x.Creator}, Rating: {x.Rating}, Genre: {x.Genre}, Runtime: {x.RuntimeInMinutes}, Episodes: {x.Episodes}, Image: {x.Image}, ID: {x.Id}"));
}

async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Name = "Quentin",
        LastName = "Tarantino",
        VideoId = 1
    };
    
    await context.AddAsync(director);
    await context.SaveChangesAsync();
}

async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Name = "Brad",
        LastName = "Pitt"
    };
    
    await context.AddAsync(actor);
    await context.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1
    };
    
    await context.AddAsync(videoActor);
    await context.SaveChangesAsync();
}

async Task AddNewStreamerWithVideoId()
{
    var streamer = await context.Streamers!.Where(s => s.Name == "west").AsQueryable().FirstOrDefaultAsync();

    if (streamer != null)
    {
        var video = new Video
        {
            Name = $"Video from {streamer.Name} number 2",
            StreamerId = streamer.Id
        };

        await context.AddAsync(video);
        await context.SaveChangesAsync();
    }
}

async Task AddNewStreamerWithVideo()
{
    var streamer = new Streamer
    {
        Name = "west"
    };
    
    var video = new Video
    {
        Name = $"Video from {streamer.Name}",
        Streamer = streamer
    };
    
    await context.AddAsync(video);
    await context.SaveChangesAsync();
}

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

    var streamers = await (from i in context.Streamers where EF.Functions.Like(i.Name, $"%{streamerName}%") select i)
        .ToListAsync();
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
    streamers.ForEach(x => Console.WriteLine($"Streamer Query: {x.Id} - {x.Name}"));

    var streamingPartial = await context.Streamers!.Where(s => EF.Functions.Like(s.Name, $"%{streamingCompany}%"))
        .ToListAsync();
    streamingPartial.ForEach(x => Console.WriteLine($"Streamer Query: {x.Id} - {x.Name}"));
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