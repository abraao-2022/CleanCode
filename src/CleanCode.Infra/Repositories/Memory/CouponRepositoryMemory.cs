﻿using CleanCode.Domain.Entities;
using CleanCode.Domain.Repositories;

namespace CleanCode.Infra.Repositories.Memory;

public class CouponRepositoryMemory : ICouponRepository
{
    public List<Coupon> Coupons { get; set; } = new()
    {
        new Coupon("VALE20", 20)
    };

    public Task AddAsync(Coupon coupon)
    {
        throw new NotImplementedException();
    }

    public async Task<Coupon> FindByCodeAsync(string code)
    {
        return Coupons.FirstOrDefault(coupon => coupon.Code == code)
            ?? throw new Exception("coupon not found");
    }
}
