using CleanCode.Domain.Entities;

namespace CleanCode.Test.OrderTests;

[TestClass]
public class OrderTest
{
    private readonly Item CD = new Item(1, "Música", "CD", 30);
    private readonly Item DVD = new Item(2, "Vídeo", "DVD", 50);
    private readonly Item VHS = new Item(3, "Vídeo", "VHS", 10);
    private readonly Coupon Vale20 = new Coupon("VALE20", 20);

    [TestMethod]
    public void Deveria_Criar_Um_Pedido_Com_CPF_Valido()
    {
        var cpf = "839.435.452-10";
        var order = new Order(cpf);
        var total = order.GetTotal();

        Assert.AreEqual(0, total);
    }

    [TestMethod]
    public void Deveria_Tentar_Criar_Um_Pedido_Com_CPF_Invalido()
    {
        var cpf = "111.111.111-11";

        try
        {
            var order = new Order(cpf);
        }
        catch (Exception e)
        {
            Assert.AreEqual("Cpf Inválido", e.Message);
        }
    }

    [TestMethod]
    public void Deveria_Criar_Um_Pedido_Com_3_Itens()
    {
        var cpf = "839.435.452-10";
        var order = new Order(cpf);
        order.AddItem(CD, 3);
        order.AddItem(DVD, 1);
        order.AddItem(VHS, 2);
        var total = order.GetTotal();

        Assert.AreEqual(160, total);
    }

    [TestMethod]
    public void Deveria_Criar_Um_Pedido_Com_Cupom_De_Desconto()
    {
        var cpf = "839.435.452-10";
        var order = new Order(cpf);
        order.AddItem(CD, 3);
        order.AddItem(DVD, 1);
        order.AddItem(VHS, 2);
        order.AddCoupon(Vale20);
        var total = order.GetTotal();

        Assert.AreEqual(128, total);
    }
}
