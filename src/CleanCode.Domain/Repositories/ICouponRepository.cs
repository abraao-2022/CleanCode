using CleanCode.Domain.Entities;

namespace CleanCode.Domain.Repositories;

public interface ICouponRepository
{
    Task<Coupon> FindByCode(string code);
}
