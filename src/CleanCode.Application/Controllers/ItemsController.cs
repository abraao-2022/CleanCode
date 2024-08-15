using CleanCode.Domain.Entities;
using CleanCode.Domain.Repositories;
using CleanCode.Infra.CleanCodeContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemRepository _itemRepository;
    private readonly ICouponRepository _couponRepository;
    private readonly DataContext _context;
    public ItemsController(IItemRepository itemRepository, DataContext context, ICouponRepository couponRepository)
    {
        _itemRepository = itemRepository;
        _context = context;
        _couponRepository = couponRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Item>>> FindAll()
    {
        var items = await _context.Items.ToListAsync();
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> AddItem()
    {
        return Ok();
    } 
}
