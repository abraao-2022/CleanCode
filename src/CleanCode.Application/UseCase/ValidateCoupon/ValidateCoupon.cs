using CleanCode.Domain.Repositories;

namespace CleanCode.Application.UseCase.ValidateCoupon;

public class ValidateCoupon
{
    private readonly ICouponRepository _couponRepository;

    public ValidateCoupon(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository;
    }

    public async Task<bool> Execute(string code)
    {
        var coupon = await _couponRepository.FindByCodeAsync(code) 
            ?? throw new Exception("cupom não encontrado");

        return coupon.IsValid(); ;
    }
}
