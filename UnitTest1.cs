using System.Data.SQLite;

namespace SQLiteError;

public class Tests
{
    [Test]
    public async Task InMemoryTest()
    {
        var connection = "Data Source=file:abc?mode=memory&cache=shared;";
        await CreateDummyTable(connection);

        _ = Assert.ThrowsAsync<Exception>(async () => await CreateDummyTable(connection));
    }

    private static async Task CreateDummyTable(string conStr)
    {
        using var connection = new SQLiteConnection(conStr);
        await connection.OpenAsync();
        var command = connection.CreateCommand();
        command.CommandText = "CREATE TABLE MyTable (MyColumn int);";
        _ = await command.ExecuteNonQueryAsync();
        await connection.CloseAsync();
    }
}
