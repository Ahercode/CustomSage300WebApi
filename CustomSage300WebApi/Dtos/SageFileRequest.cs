using System.ComponentModel.DataAnnotations;

namespace CustomSage300WebApi.Dtos;

public class SageFileRequest
{

    [StringLength(10)]
    public string? ItemId { get; set; }
    
    public List<IFormFile>? Files { get; set; }
    
}