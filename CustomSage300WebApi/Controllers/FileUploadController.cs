using CustomSage300WebApi.DBContext;
using CustomSage300WebApi.Dtos;
using CustomSage300WebApi.Entities;
using CustomSage300WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomSage300WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FileUploadController : ControllerBase
{
    private readonly IUploadFileService _uploadFileService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly WorkFlowDbContext _dbContext;

    public FileUploadController(IUploadFileService uploadFileService, IWebHostEnvironment webHostEnvironment, WorkFlowDbContext dbContext)
    {
        _uploadFileService = uploadFileService;
        _webHostEnvironment = webHostEnvironment;
        _dbContext = dbContext;
    }
    
    // get file all files
    [HttpGet]
    public async Task<IActionResult> GetFiles()
    {
        var files = await _dbContext.SageFiles.ToListAsync();
        return Ok(files);
    }
    
    [HttpPost]
    public async Task<IActionResult> UploadFiles([FromForm]SageFileRequest request)
    {
        if (request.Files.Count > 5)
        {
            return BadRequest("You can upload a maximum of 5 files at a time.");
        }

        var fileNames = await _uploadFileService.UploadFileAsync(request.Files, _webHostEnvironment);
        
        foreach (var fileName in fileNames)
        {
            var entity = new SageFile() 
            {
                FileName = fileName,
                ItemId = request.ItemId
            };
            _dbContext.SageFiles.Add(entity);
        }
        
        await _dbContext.SaveChangesAsync();
        
        return Ok(fileNames);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFile(int id)
    {
        var file = await _dbContext.SageFiles.FindAsync(id);
        if (file == null)
        {
            return NotFound();
        }

        _dbContext.SageFiles.Remove(file);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }
    
}