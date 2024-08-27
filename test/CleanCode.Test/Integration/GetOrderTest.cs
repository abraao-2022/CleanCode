using CleanCode.Application.UseCase.GetOrder;
using System.Text.Json;

namespace CleanCode.Test.Integration;

[TestClass]
public class GetOrderTest
{
    private readonly HttpClient _httpClient;
    public GetOrderTest()
    {
        _httpClient = new HttpClient();
    }

    [TestMethod]
    [Ignore]
    public async Task Deve_Obter_Um_Pedido_Pelo_Codigo()
    {
        var input = "202400000002";
        var httpResponse = await _httpClient.GetAsync($"http://localhost:5182/api/orders/{input}");
        var jsonAsString = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<GetOrderOutput>(jsonAsString);

        Assert.AreEqual(138, response.Total);
    }
}
