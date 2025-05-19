using Microsoft.AspNetCore.Http;
using Service.Services;

public class FileUploadService : IFileUploadService
{
    public async Task<string> UploadImageAsync(IFormFile file, string folderName)
    {
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);

        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"/{folderName}/{uniqueFileName}";
    }
}
