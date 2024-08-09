using CleanCode.Domain.Entities;
using CleanCode.Domain.Utils;

namespace CleanCode.Test.Unit.OrderTests;

[TestClass]
public class OrderTest
{
    private readonly Item CD = new Item(1, "Música", "CD", 30);
    private readonly Item DVD = new Item(2, "Vídeo", "DVD", 50);
    private readonly Item VHS = new Item(3, "Vídeo", "VHS", 10);
    private readonly Item Guitarra = new Item(4, "Instrumentos Musicais", "Guitarra", 1000, 100, 30, 10, 3);
    private readonly Item Amplificador = new Item(5, "Instrumentos Musicais", "Amplificador", 5000, 100, 50, 50, 20);
    private readonly Item Cabo = new Item(6, "Acessórios", "Cabo", 30, 10, 10, 10, 0.9);
    private readonly Coupon Vale20 = new Coupon("VALE20", 20, new DateTime(2024, 08, 07));

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

    [TestMethod]
    public void Deveria_Criar_Um_Pedido_Com_Cupom_De_Desconto_Expirado()
    {
        var cpf = "839.435.452-10";
        var order = new Order(cpf, new DateTime(2024, 08, 10));
        order.AddItem(CD, 3);
        order.AddItem(DVD, 1);
        order.AddItem(VHS, 2);
        order.AddCoupon(new Coupon("VALE20", 20, new DateTime(2024, 08, 01)));
        var total = order.GetTotal();

        Assert.AreEqual(160, total);
    }

    [TestMethod]
    public void Deveria_Criar_Um_Pedido_Com_3_Itens_Com_Calculo_Do_Frete()
    {
        var cpf = "839.435.452-10";
        var order = new Order(cpf, new DateTime(2024, 08, 07), new DefaultFreightCalculator());
        order.AddItem(Guitarra, 1);
        order.AddItem(Amplificador, 1);
        order.AddItem(Cabo, 3);
        var freight = order.GetFreight();

        Assert.AreEqual(260, freight);
    }

    [TestMethod]
    public void Deveria_Criar_Um_Pedido_Com_3_Itens_Com_Estratégia_De_Frete_Fixo()
    {
        var cpf = "839.435.452-10";
        var order = new Order(cpf, new FixedFreightCalculator());
        order.AddItem(Guitarra, 1);
        order.AddItem(Amplificador, 1);
        order.AddItem(Cabo, 3);
        var freight = order.GetFreight();

        Assert.AreEqual(50, freight);
    }
}
