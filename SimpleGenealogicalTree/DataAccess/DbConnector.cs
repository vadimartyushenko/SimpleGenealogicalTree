using RepoDb;
using RepoDb.Extensions;
using SimpleGenealogicalTree.Models;
using SimpleGenealogicalTree.Utils;
using System.Data.SQLite;

namespace SimpleGenealogicalTree.DataAccess;

public class DbConnector
{
    readonly string _connectionString;

    public DbConnector()
    {
        GlobalConfiguration.Setup().UseSQLite();

        var baseDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        var builder = new SQLiteConnectionStringBuilder {
            DataSource = Path.Combine(baseDirectory, "family_tree.db"),
            ForeignKeys = true
        };

        _connectionString = builder.ToString();
        using var connection = new SQLiteConnection(_connectionString);
        DbSchema.Update(connection);
    }

    // Generalized interface for CRUD operations
    public List<T> GetAllEntities<T>() where T : Entity
    {
        using var connection = new SQLiteConnection(_connectionString).EnsureOpen();
        return connection.QueryAll<T>().AsList();
    }

    public T GetEntity<T>(long id) where T : Entity
    {
        using var connection = new SQLiteConnection(_connectionString).EnsureOpen();
        var entity = connection.Query<T>(x => x.Id == id).FirstOrDefault();
        return entity ?? throw new EntityNotFoundException();
    }

    public T InsertEntity<T>(T entity) where T : Entity
    {
        using var connection = new SQLiteConnection(_connectionString).EnsureOpen();
        try{
            entity.Id = connection.Insert<T, long>(entity);
            return entity;
        } catch (SQLiteException e) {
            if (e.Message.Contains("constraint failed"))
                throw new ConstraintFailedException(e.Message);
            throw;
        }
    }
}
