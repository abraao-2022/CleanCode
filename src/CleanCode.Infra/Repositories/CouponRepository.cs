using CleanCode.Domain.Entities;
using CleanCode.Domain.Repositories;
using CleanCode.Infra.CleanCodeContext;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.Infra.Repositories;

public class CouponRepository : ICouponRepository
{
    private readonly DataContext _context;

    public CouponRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Coupon coupon)
    {
        if (coupon == null) throw new ArgumentNullException(nameof(coupon));

        await _context.Coupons.AddAsync(coupon);
        await _context.SaveChangesAsync();
    }

    public async Task<Coupon> FindByCodeAsync(string code)
    {
        if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException("codigo do cupom não pode ser vazio");
        
        return await _context.Coupons.FirstOrDefaultAsync(c => c.Code == code) 
            ?? throw new Exception("cupom não encontrado");
    }
}
