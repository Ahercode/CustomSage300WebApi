using System.ComponentModel.DataAnnotations;

namespace CustomSage300WebApi.Dtos;

public class WorkFlowDetailRequest
{

    public int ApplicationId { get; set; }

    [StringLength(80)]
    public string? Name { get; set; }

    public string? Description { get; set; }
}