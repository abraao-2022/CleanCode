using CleanCode.Application.UseCase.GetOrder;
using System.Text.Json;

namespace CleanCode.Test.Integration;

[TestClass]
public class GetOrdersTest
{
    private readonly HttpClient _httpClient;
    public GetOrdersTest()
    {
        _httpClient = new HttpClient();
    }

    [TestMethod]
    public async Task Deve_Obter_Todos_Os_Pedidos()
    {
        var httpResponse = await _httpClient.GetAsync($"http://localhost:5182/api/orders");
        var jsonAsString = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<GetOrdersOutput>(jsonAsString);
        Console.WriteLine(response);

        Assert.AreEqual(6, response.Orders.Count);
    }
}
