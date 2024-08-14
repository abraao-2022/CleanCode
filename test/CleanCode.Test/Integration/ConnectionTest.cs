using Microsoft.Data.Sqlite;

namespace CleanCode.Test.Integration;

[TestClass]
public class ConnectionTest
{
    [TestMethod]
    public void Deve_Criar_Conexao_Com_Banco_De_Dados()
    {
        var connection = new SqliteConnection("Data Source=CleanCodeDb.db");
        connection.Open();
        var state = connection.State;
        Assert.AreEqual("Open", state.ToString());
        connection.Close();
    }
}
