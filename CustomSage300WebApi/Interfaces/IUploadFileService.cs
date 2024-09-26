namespace CustomSage300WebApi.Interfaces;

public interface IUploadFileService
{
    Task<List<string>> UploadFileAsync(List<IFormFile> files, IWebHostEnvironment _webHostEnvironment);
}