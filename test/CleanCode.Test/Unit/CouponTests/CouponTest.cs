using CleanCode.Domain.Entities;

namespace CleanCode.Test.Unit.CouponTests;

[TestClass]
public class CouponTest
{
    [TestMethod]
    public void Deve_Criar_Um_Cupom_De_Desconto_Valido()
    {
        var coupon = new Coupon("VALE20", 20, new DateTime(2024, 08, 08));
        var today = new DateTime(2024, 08, 07);
        var isValid = coupon.IsValid(today);

        Assert.IsTrue(isValid);
    }

    [TestMethod]
    public void Deve_Criar_Um_Cupom_De_Desconto_Expirado()
    {
        var coupon = new Coupon("VALE20", 20, new DateTime(2024, 08, 02));
        var today = new DateTime(2024, 08, 07);
        var isExpired = coupon.IsExpired(today);

        Assert.IsTrue(isExpired);
    }

    [TestMethod]
    public void Deve_Criar_Um_Cupom_De_Desconto_Valido_E_Calcular_O_Desconto()
    {
        var coupon = new Coupon("VALE20", 20, new DateTime(2024, 08, 08));
        var discount = coupon.CalculateDiscount(1000, new DateTime(2024, 08, 07));

        Assert.AreEqual(200, discount);
    }
}
