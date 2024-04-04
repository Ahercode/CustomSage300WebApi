using AutoMapper;
using CustomSage300WebApi.DBContext;
using CustomSage300WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

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
}