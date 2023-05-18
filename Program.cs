using System;
using System.Data;

public static class Program
{
    static void Main()
    {
        string connectionString = "Data Source=DESKTOP-5TIKJIL;Initial Catalog=EmployeeData;Integrated Security=True";
        DBManipulation dbManipulation = new DBManipulation(connectionString);

        // Insert data
        Console.WriteLine("Inserting data...");
        dbManipulation.Insert("test2", "name", "John Doe");
        Console.WriteLine("Data inserted successfully.");

        // Select data
        Console.WriteLine("Selecting data...");
        DataTable result = dbManipulation.Select("test2", "name = 'John Doe'");
        Console.WriteLine("Data selected successfully.");

        // Display selected data
        Console.WriteLine("Selected data:");
        foreach (DataRow row in result.Rows)
        {
            Console.WriteLine($"Name: {row["name"]}");
        }

        // Update data
        Console.WriteLine("Updating data...");
        dbManipulation.Update("test2", "name", "Jane Smith", "name = 'John Doe'");
        Console.WriteLine("Data updated successfully.");

        // Select updated data
        Console.WriteLine("Selecting updated data...");
        result = dbManipulation.Select("test2", "name = 'Jane Smith'");
        Console.WriteLine("Updated data selected successfully.");

        // Display selected updated data
        Console.WriteLine("Selected updated data:");
        foreach (DataRow row in result.Rows)
        {
            Console.WriteLine($"Name: {row["name"]}");
        }

        // Delete data
        Console.WriteLine("Deleting data...");
        dbManipulation.Delete("test2", "name = 'Jane Smith'");
        Console.WriteLine("Data deleted successfully.");

        Console.WriteLine("Program completed.");
        Console.ReadLine();
    }
}
