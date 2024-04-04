using AutoMapper;
using CustomSage300WebApi.DBContext;
using CustomSage300WebApi.Dtos;
using CustomSage300WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CustomSage300WebApi.Controllers;

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
    public IActionResult GetAllSageUsers()
    {
        var sageUsers = _context.SageUsers.ToList();
        var sageUsersDto = _mapper.Map<IEnumerable<SageUserResponse>>(sageUsers);
        return Ok(sageUsersDto);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetASageUser(int id)
    {
        var sageUser = _context.SageUsers.FirstOrDefault(x => x.Id == id);
        var sageUserDto = _mapper.Map<SageUserResponse>(sageUser);
        
        if(sageUserDto == null)
            return NotFound("Sage User not found");
        
        return Ok(sageUserDto);
    }
    
    [HttpPost]
    public IActionResult CreateSageUser(SageUserRequest createSageUserRequest)
    {
        if(!ModelState.IsValid)
            return BadRequest("Invalid data provided");

        try
        {
            var sageUser = _mapper.Map<SageUser>(createSageUserRequest);

            if (sageUser.Username != null)
            {
                var sageUserInDb = _context.SageUsers.FirstOrDefault(x => x.Username == sageUser.Username);
                if (sageUserInDb != null)
                    return BadRequest("Sage User already exists");
            }

            _context.SageUsers.Add(sageUser);
            _context.SaveChanges();
        
            return Ok("Sage User created successfully");
        
        }
        catch (Exception e)
        {
            return BadRequest("An error occurred while creating Sage User");
        }
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateSageUser(int id, SageUserRequest updateSageUserRequest)
    {
        if(!ModelState.IsValid)
            return BadRequest("Invalid data provided");

        try
        {
            var sageUser = _context.SageUsers.FirstOrDefault(x => x.Id == id);
            if (sageUser == null)
                return NotFound("Sage User not found");

            _mapper.Map(updateSageUserRequest, sageUser);
            _context.SaveChanges();
        
            return Ok("Sage User updated successfully");
        
        }
        catch (Exception e)
        {
            return BadRequest("An error occurred while updating Sage User");
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteSageUser(int id)
    {
        try
        {
            var sageUser = _context.SageUsers.FirstOrDefault(x => x.Id == id);
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