using System.Data;
using System.Data.SqlClient;

public class DBManipulation
{
    private string connectionString; // Connection string for the SQL Server database

    public DBManipulation(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Insert(string tableName, string columnName, object value)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = $"INSERT INTO {tableName} ({columnName}) VALUES (@value)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@value", value);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public void Delete(string tableName, string condition)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = $"DELETE FROM {tableName} WHERE {condition}";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public DataTable Select(string tableName, string condition)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = $"SELECT * FROM {tableName} WHERE {condition}";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }

    public void Update(string tableName, string columnName, object value, string condition)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = $"UPDATE {tableName} SET {columnName} = @value WHERE {condition}";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@value", value);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
