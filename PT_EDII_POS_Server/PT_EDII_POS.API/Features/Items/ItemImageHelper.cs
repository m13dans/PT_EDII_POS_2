using Dumpify;
using Microsoft.AspNetCore.Hosting.Server;

namespace PT_EDII_POS.API.Features.Items;

public class ItemImageHelper(IWebHostEnvironment environment, IHttpContextAccessor httpContext)
{
    public (string, string, byte[]) HandleImage(IFormFile file)
    {
        var contentPath = environment.WebRootPath;
        var path = Path.Combine(contentPath, "images");

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var ext = Path.GetExtension(file.FileName);
        var newFileName = $"{Guid.NewGuid()}{ext}";

        var fileNameWithPath = Path.Combine(path, newFileName);
        var host = httpContext.HttpContext!.Request.Host.Value;

        var fileNameWithHostPath = Path.Combine(host, "images", newFileName);

        using var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);
        byte[] imageInByte = memoryStream.ToArray();
        return (fileNameWithPath, fileNameWithHostPath, imageInByte);
    }
}
