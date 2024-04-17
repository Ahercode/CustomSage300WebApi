using AutoMapper;
using CustomSage300WebApi.DBContext;
using CustomSage300WebApi.Dtos;
using CustomSage300WebApi.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomSage300WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PurchaseOrderController : ControllerBase
{
    private readonly SageDbContext _context;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    
    public PurchaseOrderController(SageDbContext context, IMapper mapper, IEmailService emailService)
    {
        _context = context;
        _mapper = mapper;
        _emailService = emailService;
    }
    
    // all purchase order 
    [HttpGet]
    public IActionResult GetAllPurchaseOrder()
    {
        var purchaseOrder = _context.POPORIs.ToList();
        var purchaseOrderDto = _mapper.Map<IEnumerable<POResponse>>(purchaseOrder);
        return Ok(purchaseOrderDto);
    }
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePurchaseOrder(decimal id, [FromBody] JsonPatchDocument<PORequest> patchDoc)
    {
        if (patchDoc == null)
        {
            return BadRequest("Patch document is missing");
        }

        var existingPurchaseOrder = await _context.POPORIs.FirstOrDefaultAsync(x => x.PORISEQ == id);

        if (existingPurchaseOrder == null)
        {
            return BadRequest("Purchase Order not found");
        }

        var purchaseOrderToPatch = _mapper.Map<PORequest>(existingPurchaseOrder);
        patchDoc.ApplyTo(purchaseOrderToPatch);

        if (!TryValidateModel(purchaseOrderToPatch))
        {
            return BadRequest(ModelState);
        }

        _mapper.Map(purchaseOrderToPatch, existingPurchaseOrder);

        _context.POPORIs.Update(existingPurchaseOrder); 
        await _context.SaveChangesAsync(); 

        return Ok("Purchase Order updated successfully");
    }
    
    [HttpPost("SendEmail")]
    public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data provided");
        try
        {
           await _emailService.SendEmail(emailRequest.To, emailRequest.Subject, emailRequest.Body);
            
            return Ok("Email sent successfully");
        }
        catch (Exception e)
        {
            return BadRequest("An error occurred while sending email");
        }
    }
    
}