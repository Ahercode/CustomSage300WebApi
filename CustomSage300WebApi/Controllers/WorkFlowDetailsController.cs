using AutoMapper;
using CustomSage300WebApi.DBContext;
using CustomSage300WebApi.Dtos;
using CustomSage300WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomSage300WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class WorkFlowDetailsController : ControllerBase
{
    private WorkFlowDbContext _context;
    private readonly IMapper _mapper;

    public WorkFlowDetailsController(IMapper mapper, WorkFlowDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetWorkFlowDetails()
    {
        var workFlowDetails = await _context.WorkFlowDetails.ToListAsync();
        var workFlowDetailsResponse = _mapper.Map<IEnumerable<WorkFlowDetailResponse>>(workFlowDetails);
        return Ok(workFlowDetailsResponse);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetWorkFlowDetail(int id)
    {
        var workFlowDetail = await _context.WorkFlowDetails.FirstOrDefaultAsync(w => w.Id == id);
        if (workFlowDetail == null)
        {
            return NotFound();
        }
        var workFlowDetailResponse = _mapper.Map<WorkFlowDetailResponse>(workFlowDetail);
        return Ok(workFlowDetailResponse);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateWorkFlowDetail([FromBody] WorkFlowDetailRequest workFlowDetailRequest)
    {
        var workFlowDetail = _mapper.Map<WorkFlowDetail>(workFlowDetailRequest);
        _context.WorkFlowDetails.Add(workFlowDetail);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetWorkFlowDetail), new { id = workFlowDetail.Id }, workFlowDetail);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorkFlowDetail(int id, [FromBody] WorkFlowDetail workFlowDetail)
    {
        if (id != workFlowDetail.Id)
        {
            return BadRequest();
        }
        _context.Entry(workFlowDetail).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok("Updated Successfully");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkFlowDetail(int id)
    {
        var workFlowDetail = await _context.WorkFlowDetails.FirstOrDefaultAsync(w => w.Id == id);
        if (workFlowDetail == null)
        {
            return NotFound();
        }
        _context.WorkFlowDetails.Remove(workFlowDetail);
        await _context.SaveChangesAsync();
        return Ok("Deleted Successfully");
    }
}