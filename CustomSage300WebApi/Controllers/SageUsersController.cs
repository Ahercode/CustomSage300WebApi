using AutoMapper;
using CustomSage300WebApi.DBContext;
using CustomSage300WebApi.Dtos;
using CustomSage300WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomSage300WebApi.Controllers;

[Route("api/[controller]")]
public class SageUsersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly WorkFlowDbContext _context;
    public SageUsersController(IMapper mapper, WorkFlowDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<SageUserResponse>> GetAllSageUsers()
    {
        var sageUsers = await _context.SageUsers.ToListAsync();
        var sageUsersDto = _mapper.Map<IEnumerable<SageUserResponse>>(sageUsers);
        return Ok(sageUsersDto);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<SageUserResponse>> GetSageUser(int id)
    {
        var sageUser = await _context.SageUsers.FirstOrDefaultAsync(x => x.Id == id);
        var sageUserDto = _mapper.Map<SageUserResponse>(sageUser);
        
        if(sageUserDto == null)
            return NotFound("Sage User not found");
        
        return Ok(sageUserDto);
    }
    
    [HttpPost]
    public async Task<ActionResult<SageUserRequest>> CreateSageUser(SageUserRequest createSageUserRequest)
    {
        if(!ModelState.IsValid)
            return BadRequest("Invalid data provided");

        try
        {
            var sageUser = _mapper.Map<SageUser>(createSageUserRequest);

            if (sageUser.Username != null)
            {
                var sageUserInDb = await _context.SageUsers.FirstOrDefaultAsync(x => x.Username == sageUser.Username);
                if (sageUserInDb != null)
                    return BadRequest("Sage User already exists");
            }

            await _context.SageUsers.AddAsync(sageUser);
            await _context.SaveChangesAsync();
        
            return Ok("Sage User created successfully");
        
        }
        catch (Exception e)
        {
            return BadRequest($"An error occurred while creating Sage User\n {e}");
        }
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<SageUserRequest>> UpdateSageUser(int id, SageUserRequest updateSageUserRequest)
    {
        if(!ModelState.IsValid)
            return BadRequest("Invalid data provided");

        try
        {
            var sageUser = await _context.SageUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (sageUser == null)
                return NotFound("Sage User not found");

            _mapper.Map(updateSageUserRequest, sageUser);
            await _context.SaveChangesAsync();
        
            return Ok("Sage User updated successfully");
        
        }
        catch (Exception e)
        {
            return BadRequest("An error occurred while updating Sage User");
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<SageUserRequest>> DeleteSageUser(int id)
    {
        try
        {
            var sageUser = await _context.SageUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (sageUser == null)
                return NotFound("Sage User not found");

            _context.SageUsers.Remove(sageUser);
            _context.SaveChanges();
        
            return Ok("Sage User deleted successfully");
        
        }
        catch (Exception e)
        {
            return BadRequest("An error occurred while deleting Sage User");
        }
    }
    
}