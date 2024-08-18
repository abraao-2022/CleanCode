using CleanCode.Application.UseCase;
using CleanCode.Application.UseCase.PlaceOrder;
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
    public async Task Deve_Testar_A_Api()
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

        Assert.AreEqual("202400000003", response.Code);
    }
}
