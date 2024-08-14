using CleanCode.Infra.CleanCodeContext;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.Test.Integration;

[TestClass]
public class ConnectionTest
{
    [TestMethod]
    public void Deve_Criar_Conexao_Com_Banco_De_Dados()
    {
        //var dale = new DataContext(new DbContextOptions<DataContext>());
        var connection = new SqliteConnection("Data Source=CleanCodeDb.db");
        connection.Open();
        var state = connection.State;
        Assert.AreEqual("Open" ,state.ToString());
        connection.Close();
    }
}
