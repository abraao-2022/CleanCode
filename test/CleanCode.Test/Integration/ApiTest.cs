using CleanCode.Application.UseCase;
using CleanCode.Application.UseCase.PlaceOrder;
using CleanCode.Application.UseCase.SimulateFreight;
using System.Net.Http;
using System.Text.Json;

namespace CleanCode.Test.Integration;

[TestClass]
public class ApiTest
{
    private readonly HttpClient _httpClient;
    public ApiTest()
    {
        _httpClient = new HttpClient();
    }

    [TestMethod]
    [Ignore]
    public async Task Deve_Testar_A_Api_ORDERS_POST()
    {
        var input = new PlaceOrderInput
        {
            Cpf = "839.435.452-10",
            OrderItems = new List<OrderItemInput>
            {
                new OrderItemInput{IdItem = 1, Quantity = 1},
                new OrderItemInput{IdItem = 2, Quantity = 1},
                new OrderItemInput{IdItem = 3, Quantity = 3},
            },
            Date = new DateTime(2024, 08, 07),
            Coupon = "VALE20"

        };
        var httpResponse = await _httpClient.PostAsJsonAsync("http://localhost:5182/api/orders", input);
        var jsonAsString = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<PlaceOrderOutput>(jsonAsString);

        Assert.AreEqual(138, response.Total);
    }
    
    [TestMethod]
    [Ignore]
    public async Task Deve_Testar_A_Api_SIMULATE_FREIGHT_POST()
    {
        var input = new SimulateFreightInput
        {
            Items = new List<OrderItemInput>
            {
                new() { IdItem = 4, Quantity = 1},
                new() { IdItem = 5, Quantity = 1},
                new() { IdItem = 6, Quantity = 3},
            }
        };
        var httpResponse = await _httpClient.PostAsJsonAsync("http://localhost:5182/api/freights/simulateFreight", input);
        var jsonAsString = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<SimulateFreightOutput>(jsonAsString);

        Assert.AreEqual(260, response.Amount);
    }
}
