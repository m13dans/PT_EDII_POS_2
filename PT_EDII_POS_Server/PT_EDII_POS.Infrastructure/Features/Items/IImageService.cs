using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PT_EDII_POS.Infrastructure.Features.Items;

public class ItemImageService(IWebHostEnvironment environment)
{
    public async Task<string> HandleImage(IFormFile file)
    {
        var contentPath = environment.WebRootPath;
        var path = Path.Combine(contentPath, "images");

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var ext = Path.GetExtension(file.FileName);
        var newFileName = $"{Guid.NewGuid()} {ext}";
        var fileNameWithPath = Path.Combine(path, newFileName);

        using var stream = new FileStream(fileNameWithPath, FileMode.Create);
        await file.CopyToAsync(stream);
        return newFileName;
    }
}
