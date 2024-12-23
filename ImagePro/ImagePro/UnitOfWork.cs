using System;
using System.Data;
using System.Data.SqlClient;

public class UnitOfWork : IDisposable
{
    private readonly SqlConnection _connection;
    private SqlTransaction _transaction;
    private bool _disposed;

    public UnitOfWork(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
        _connection.Open();
        _transaction = _connection.BeginTransaction();
    }

    public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
    {
        using (var command = new SqlCommand(query, _connection, _transaction))
        {
            command.Parameters.AddRange(parameters);
            using (var adapter = new SqlDataAdapter(command))
            {
                var resultTable = new DataTable();
                try
                {
                    adapter.Fill(resultTable);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Request execution error: {ex.Message}");
                }
                return resultTable;
            }
        }
    }

    public void ExecuteNonQuery(string query, SqlParameter[] parameters)
    {
        using (var command = new SqlCommand(query, _connection, _transaction))
        {
            command.Parameters.AddRange(parameters);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Request execution error: {ex.Message}");
            }
        }
    }

    public void Commit()
    {
        try
        {
            _transaction?.Commit();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error during commit execution: {ex.Message}");
        }
        finally
        {
            Dispose();
        }
    }

    public void Rollback()
    {
        try
        {
            _transaction?.Rollback();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error when performing a rollback: {ex.Message}");
        }
        finally
        {
            Dispose();
        }
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _transaction?.Dispose();
            _connection?.Dispose();
            _disposed = true;
        }
    }
}
