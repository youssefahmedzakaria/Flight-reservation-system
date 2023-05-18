using System;
using System.Data;
using System;

public class Program
{
    string connectionString = "Data Source=DESKTOP-LTOVK9O;Initial Catalog=EmployeeData;Integrated Security=True";
        //string connectionString = "Data Source=DESKTOP-5TIKJIL;Initial Catalog=EmployeeData;Integrated Security=True";
    private static Admin admin = new Admin(connectionString);
    private static User user = new User(connectionString);

    public static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("=== Flight Management System ===");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. User");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AdminMenu();
                    break;
                case "2":
                    UserMenu();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }
}
