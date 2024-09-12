namespace PT_EDII_POS.API.Features.Items;

public static class ImageValidatorHelper
{
    public static bool ValidateImageSize(IFormFile file)
    {
        long allowedSize = 1024 * 1024 * 2;
        return file.Length < allowedSize;
    }

    public static bool ValidateImageExtension(IFormFile file)
    {
        string[] allowedExt = [".jpg", ".png", ".jpeg"];
        var dotIndex = file.FileName.LastIndexOf('.');
        var extension = file.FileName.Substring(dotIndex);
        if (extension is null)
            return false;
        return allowedExt.Contains(extension);
    }

}
