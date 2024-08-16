using CleanCode.Application.UseCase.ValidateCoupon;
using CleanCode.Infra.Repositories.Memory;

namespace CleanCode.Test.Integration;

[TestClass]
public class ValidateCouponTest
{
    [TestMethod]
    public async Task Deve_Validar_Um_Cupom_De_Desconto()
    {
        var couponRepository = new CouponRepositoryMemory();
        var validateCoupon = new ValidateCoupon(couponRepository);
        var isValid = await validateCoupon.Execute("VALE20");
        Assert.IsTrue(isValid);
    }
}
