using RepoDb;
using System.Data.SQLite;

namespace SimpleGenealogicalTree.DataAccess;

public class DbConnector
{
    string connectionString = new SQLiteConnectionStringBuilder() {
        DataSource = "family_tree.db",
        ForeignKeys = true,
    }.ToString();

    public DbConnector()
    {
        GlobalConfiguration.Setup().UseSQLite();
        using var connection = new SQLiteConnection(connectionString);
        DbSchema.Update(connection);
    }
}
