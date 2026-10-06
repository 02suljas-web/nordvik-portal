using Azure.Identity;
using Azure.Storage.Blobs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapPost("/api/felanmalan", async (HttpRequest request) =>
{
    var form = await request.ReadFormAsync();

    var rubrik = form["rubrik"].ToString();
    var kategori = form["kategori"].ToString();
    var beskrivning = form["beskrivning"].ToString();
    var bild = form.Files.GetFile("bild");

    string? bildUrl = null;

    if (bild != null && bild.Length > 0)
    {
        var blobServiceClient = new BlobServiceClient(
            new Uri("https://stnordvik02suljas01.blob.core.windows.net"),
            new DefaultAzureCredential());

        var containerClient = blobServiceClient.GetBlobContainerClient("bilder");

        var blobName = $"{Guid.NewGuid()}-{Path.GetFileName(bild.FileName)}";
        var blobClient = containerClient.GetBlobClient(blobName);

        await using var stream = bild.OpenReadStream();
        await blobClient.UploadAsync(stream);

        bildUrl = blobClient.Uri.ToString();
    }

    return Results.Ok(new
    {
        message = "Felanmälan mottagen",
        rubrik,
        kategori,
        beskrivning,
        bildUrl
    });
});

app.Run();
