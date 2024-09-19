using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PT_EDII_POS.Infrastructure.Features.Items.ImageHelper;

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
		var host = httpContext.HttpContext!.Request.Host.Value.Replace(@"\\", "/");

		var fileNameWithHostPath = Path.Combine("https://" + host, "images", newFileName);
		var fixedNameWithHostPath = fileNameWithHostPath.Replace(@"\\", "/");

		using var memoryStream = new MemoryStream();
		file.CopyTo(memoryStream);
		byte[] imageInByte = memoryStream.ToArray();
		return (fileNameWithPath, fixedNameWithHostPath, imageInByte);
	}

	public static async Task SaveImage(string urlGambar, byte[] byteGambar)
	{
		using var memoryStream = new MemoryStream(byteGambar);
		FormFile formFile = new(
			memoryStream,
			0,
			memoryStream.Length,
			Path.GetFileNameWithoutExtension(urlGambar),
			Path.GetFileName(urlGambar));

		using var stream = new FileStream(urlGambar, FileMode.Create);
		await formFile.CopyToAsync(stream);
	}

}
