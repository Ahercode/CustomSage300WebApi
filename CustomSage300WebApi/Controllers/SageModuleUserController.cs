using AutoMapper;
using CustomSage300WebApi.DBContext;
using CustomSage300WebApi.Dtos;
using CustomSage300WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CustomSage300WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SageModuleUserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly WorkFlowDbContext _context;
    
    public SageModuleUserController(IMapper mapper, WorkFlowDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<SageModuleUserResponse>> GetAllSageModuleUsers()
    {
        var sageModuleUsers = await _context.SageModuleUsers.ToListAsync();
        var sageModuleUsersDto = _mapper.Map<IEnumerable<SageModuleUserResponse>>(sageModuleUsers);
        return Ok(sageModuleUsersDto);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<SageModuleUserResponse>> GetSageModuleUser(int id)
    {
        var sageModuleUser = await _context.SageModuleUsers.FirstOrDefaultAsync(x => x.Id == id);
        var sageModuleUserDto = _mapper.Map<SageModuleUserResponse>(sageModuleUser);
        
        if(sageModuleUserDto == null)
            return NotFound("Sage Module User not found");
        
        return Ok(sageModuleUserDto);
    }
    
    [HttpPost]
    public async Task<ActionResult<SageModuleUserRequest>> CreateSageModuleUser(SageModuleUserRequest createSageModuleUserRequest)
    {
        // Log the request
        Console.WriteLine($"Received request: {JsonConvert.SerializeObject(createSageModuleUserRequest)}");


        if(!ModelState.IsValid)
            return BadRequest("Invalid data provided");

        try
        {
            var sageModuleUser = _mapper.Map<SageModuleUser>(createSageModuleUserRequest);

            if (sageModuleUser.SageModuleId != null && sageModuleUser.UserId != null)
            {
                var sageModuleUserInDb = await _context.SageModuleUsers.FirstOrDefaultAsync(x => x.SageModuleId == sageModuleUser.SageModuleId && x.UserId == sageModuleUser.UserId);
                if (sageModuleUserInDb != null)
                    return BadRequest("Sage Module User already exists");
            }
            await _context.SageModuleUsers.AddAsync(sageModuleUser);
            await _context.SaveChangesAsync();
            return Ok(createSageModuleUserRequest);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<SageModuleUserRequest>> UpdateSageModuleUser(int id, SageModuleUserRequest updateSageModuleUserRequest)
    {
        if(!ModelState.IsValid)
            return BadRequest("Invalid data provided");

        try
        {
            var sageModuleUser = await _context.SageModuleUsers.FirstOrDefaultAsync(x => x.Id == id);
            if(sageModuleUser == null)
                return NotFound("Sage Module User not found");

            _mapper.Map(updateSageModuleUserRequest, sageModuleUser);
            await _context.SaveChangesAsync();
            return Ok(updateSageModuleUserRequest);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSageModuleUser(int id)
    {
        var sageModuleUser = await _context.SageModuleUsers.FirstOrDefaultAsync(x => x.Id == id);
        if(sageModuleUser == null)
            return NotFound("Sage Module User not found");

        _context.SageModuleUsers.Remove(sageModuleUser);
        await _context.SaveChangesAsync();
        return Ok("Sage Module User deleted successfully");
    }
}