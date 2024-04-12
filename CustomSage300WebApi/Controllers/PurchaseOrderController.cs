using AutoMapper;
using CustomSage300WebApi.DBContext;
using CustomSage300WebApi.Dtos;
using CustomSage300WebApi.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CustomSage300WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PurchaseOrderController : ControllerBase
{
    private readonly SageDbContext _context;
    private readonly IMapper _mapper;
    
    public PurchaseOrderController(SageDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

        _mapper.Map(purchaseOrderToPatch, existingPurchaseOrder); // Map the changes back to the POPORI entity

        _context.POPORIs.Update(existingPurchaseOrder); // Tell Entity Framework to track the entity as modified
        await _context.SaveChangesAsync(); // Save the changes to the database

        return Ok("Purchase Order updated successfully");
    }
    
}