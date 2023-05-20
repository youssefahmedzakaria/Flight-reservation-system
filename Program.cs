using System;

public class Program
{
    private static string connectionString = "Data Source=DESKTOP-LTOVK9O;Initial Catalog=flightSystem;Integrated Security=True";
    //  private static string connectionString = "Data Source=DESKTOP-5TIKJIL;Initial Catalog=flightSystem;Integrated Security=True";
    private static Admin admin = new Admin(connectionString);
    private static Customer customer = new Customer(connectionString);
    private static Validate validate = new Validate();
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
                    admin.AdminMenu();
                    break;
                case "2":
                    customer.UserMenu();
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
