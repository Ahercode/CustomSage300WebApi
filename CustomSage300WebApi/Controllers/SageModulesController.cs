using AutoMapper;
using CustomSage300WebApi.DBContext;
using CustomSage300WebApi.Dtos;
using CustomSage300WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAllSageModules()
    {
        var sageModules = _context.SageModules.ToList();
        var sageModulesDto = _mapper.Map<IEnumerable<SageModuleResponse>>(sageModules);
        return Ok(sageModulesDto);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetSageModule(int id)
    {
        var sageModule = _context.SageModules.FirstOrDefault(x => x.Id == id);
        var sageModuleDto = _mapper.Map<SageModuleResponse>(sageModule);
        
        if(sageModuleDto == null)
            return NotFound("Sage Module not found");
        
        return Ok(sageModuleDto);
    }
    
    [HttpPost]
    public IActionResult CreateSageModule(SageModuleRequest createSageModuleRequest)
    {
        if(!ModelState.IsValid)
            return BadRequest("Invalid data provided");

        try
        {
            var sageModule = _mapper.Map<SageModule>(createSageModuleRequest);

            if (sageModule.Code != null)
            {
                var sageModuleInDb = _context.SageModules.FirstOrDefault(x => x.Code == sageModule.Code);
                if (sageModuleInDb != null)
                    return BadRequest("Sage Module already exists");
            }

            _context.SageModules.Add(sageModule);
            _context.SaveChanges();
        
            return Ok("Sage Module created successfully");
            
        }
        catch (Exception e)
        {
            return BadRequest("An error occurred while creating Sage Module");
        }
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateSageModule(int id, SageModuleRequest updateSageModuleRequest)
    {
        if(!ModelState.IsValid)
            return BadRequest("Invalid data provided");

        try
        {
            var sageModule = _context.SageModules.FirstOrDefault(x => x.Id == id);
            if(sageModule == null)
                return NotFound("Sage Module not found");

            _mapper.Map(updateSageModuleRequest, sageModule);
            _context.SaveChanges();
        
            return Ok("Sage Module updated successfully");
            
        }
        catch (Exception e)
        {
            return BadRequest("An error occurred while updating Sage Module");
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteSageModule(int id)
    {
        try
        {
            var sageModule = _context.SageModules.FirstOrDefault(x => x.Id == id);
            if(sageModule == null)
                return NotFound("Sage Module not found");

            _context.SageModules.Remove(sageModule);
            _context.SaveChanges();
        
            return Ok("Sage Module deleted successfully");
            
        }
        catch (Exception e)
        {
            return BadRequest("An error occurred while deleting Sage Module");
        }
    }
}