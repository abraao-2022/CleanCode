using CleanCode.Domain.Entities;

namespace CleanCode.Domain.Repositories;

public interface ICouponRepository
{
    Task<Coupon> FindByCodeAsync(string code);
    Task AddAsync(Coupon coupon);
}
