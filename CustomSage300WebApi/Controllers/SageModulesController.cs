using AutoMapper;
using CustomSage300WebApi.DBContext;
using CustomSage300WebApi.Dtos;
using CustomSage300WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomSage300WebApi.Controllers;

[Route("api/[controller]")]
public class SageModulesController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly WorkFlowDbContext _context;
    
    public SageModulesController(IMapper mapper, WorkFlowDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<SageModuleResponse>> GetAllSageModules()
    {
        var sageModules = await _context.SageModules.ToListAsync();
        var sageModulesDto = _mapper.Map<IEnumerable<SageModuleResponse>>(sageModules);
        return Ok(sageModulesDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SageModuleResponse>> GetSageModule(int id)
    {
        var sageModule = await _context.SageModules.FirstOrDefaultAsync(x => x.Id == id);
        var sageModuleDto = _mapper.Map<SageModuleResponse>(sageModule);

        if(sageModuleDto == null)
            return NotFound("Sage Module not found");

        return Ok(sageModuleDto);
    }

    [HttpPost]
    public async Task<ActionResult<SageModuleRequest>> CreateSageModule(SageModuleRequest createSageModuleRequest)
    {
        if(!ModelState.IsValid)
            return BadRequest("Invalid data provided");

        try
        {
            var sageModule = _mapper.Map<SageModule>(createSageModuleRequest);

            if (sageModule.Code != null)
            {
                var sageModuleInDb = await _context.SageModules.FirstOrDefaultAsync(x => x.Code == sageModule.Code);
                if (sageModuleInDb != null)
                    return BadRequest("Sage Module already exists");
            }

            await _context.SageModules.AddAsync(sageModule);
            await _context.SaveChangesAsync();

            return Ok("Sage Module created successfully");

        }
        catch (Exception e)
        {
            return BadRequest("An error occurred while creating Sage Module");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SageModuleRequest>> UpdateSageModule(int id, SageModuleRequest updateSageModuleRequest)
    {
        if(!ModelState.IsValid)
            return BadRequest("Invalid data provided");

        try
        {
            var sageModule = await _context.SageModules.FirstOrDefaultAsync(x => x.Id == id);
            if(sageModule == null)
                return NotFound("Sage Module not found");

            _mapper.Map(updateSageModuleRequest, sageModule);
            await _context.SaveChangesAsync();

            return Ok("Sage Module updated successfully");

        }
        catch (Exception e)
        {
            return BadRequest("An error occurred while updating Sage Module");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSageModule(int id)
    {
        try
        {
            var sageModule = await _context.SageModules.FirstOrDefaultAsync(x => x.Id == id);
            if(sageModule == null)
                return NotFound("Sage Module not found");

            _context.SageModules.Remove(sageModule);
            await _context.SaveChangesAsync();

            return Ok("Sage Module deleted successfully");

        }
        catch (Exception e)
        {
            return BadRequest("An error occurred while deleting Sage Module");
        }
    }
}