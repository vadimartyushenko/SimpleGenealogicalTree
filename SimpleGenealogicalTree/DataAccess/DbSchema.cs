using RepoDb;
using System.Data.SQLite;

namespace SimpleGenealogicalTree.DataAccess;

public class DbSchema
{
    const int VERSION = 1;

    //record Setting(string Key, string Value);

    public static void Update(SQLiteConnection connection)
    {
        var emptyDb = connection.ExecuteScalar("SELECT name FROM sqlite_master WHERE type='table' AND name='Setting'") == null;
        if (emptyDb)
        {
            connection.ExecuteNonQuery(@"CREATE TABLE IF NOT EXISTS Setting (
                    [Key] TEXT NOT NULL
                                 PRIMARY KEY,
                    Value TEXT NOT NULL
                );");

            connection.ExecuteNonQuery(@"CREATE TABLE IF NOT EXISTS Member (
                    Id             INTEGER PRIMARY KEY AUTOINCREMENT
                                           NOT NULL,
                    Name           TEXT    NOT NULL,
                    Surname        TEXT    NOT NULL,
                    BirthDateTicks INTEGER NOT NULL,
                );");
        }
    }
}
