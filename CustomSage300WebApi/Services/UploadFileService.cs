using CustomSage300WebApi.Interfaces;

namespace CustomSage300WebApi.Services;

public class UploadFileService : IUploadFileService
{
    public async Task<List<string>> UploadFileAsync(List<IFormFile> files, IWebHostEnvironment _webHostEnvironment)
    {
        var fileNames = new List<string>();

        foreach (var file in files)
        {
            if (file != null)
            {
                try
                {
                    string imageName = new string(Path.GetFileNameWithoutExtension(file.FileName).Take(10).ToArray()).Replace(' ', '-');
                    imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(file.FileName);
                    var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads/sageFiles", imageName);

                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    fileNames.Add(imageName);
                }
                catch (Exception e)
                {
                    fileNames.Add(e.ToString());
                }
            }
            else
            {
                fileNames.Add("No file was selected");
            }
        }

        return fileNames;
    }
}