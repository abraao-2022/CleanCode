using CleanCode.Domain.Entities;

namespace CleanCode.Test.OrderTests;

[TestClass]
public class OrderTest
{

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
}
