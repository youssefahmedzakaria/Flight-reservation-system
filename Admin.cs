using System;
using System.Data.SqlClient;

public class Admin
{
    public int AdminId;
    public string Role;
    public string PhoneNo;
    public string Email;
    public string Password;
    public string FirstName;
    public string LastName;
    public string Username;
    public string connString;

    public Admin(){}

    public Admin(string CString)
    {
        connString = CString;
        AdminId = 0;
        Role = "";
        PhoneNo = "";
        Email = "";
        Password = "";
        FirstName = "";
        LastName = "";
        Username = "";
    }

    public void SignUp()
    {
        Console.Write("Enter Admin ID: ");
        AdminId = int.Parse(Console.ReadLine());

        Console.Write("Enter Role: ");
        Role = Console.ReadLine();

        Console.Write("Enter Phone Number: ");
        PhoneNo = Console.ReadLine();

        Console.Write("Enter Email: ");
        Email = Console.ReadLine();

        Console.Write("Enter Password: ");
        Password = Console.ReadLine();

        Console.Write("Enter First Name: ");
        FirstName = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        LastName = Console.ReadLine();

        Console.Write("Enter Username: ");
        Username = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();

            string insertQuery = "INSERT INTO ADMIN (ADMIN_ID ,ROLE, PHONE_NO, EMAIL, PASSWORD, F_NAME, L_NAME, USERNAME) VALUES (@AdminID ,@Role, @PhoneNo, @Email, @Password, @FirstName, @LastName, @Username)";

            SqlCommand command = new SqlCommand(insertQuery, connection);

            // Set parameter values
            command.Parameters.AddWithValue("@AdminID", AdminId);
            command.Parameters.AddWithValue("@Role", Role);
            command.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Username", Username);

            // Execute the insert query
            int rowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"{rowsAffected} row(s) inserted.");
        }
    }
    
    
    public void LogIn(){}
    public void UpdatingUserDetails(){}
    public void AddAirCraft(){}
    public void UpdateAirCraftDetails(){}
    public void AddFlight(){}
    public void UpdateFlightDetails(){}
    public void ChangeFlightsStatus(){}
    public void LogOut(){}

    public void AdminMenu()
    {
        bool back = false;
        bool loggedIn = false;

        while (!back)
        {
            Console.WriteLine("=== Admin Menu ===");
            if (!loggedIn)
            {
                Console.WriteLine("1. Admin Sign Up");
                Console.WriteLine("2. Admin Login");
            }
            else
            {
                Console.WriteLine("3. Add Aircraft");
                Console.WriteLine("4. Update Aircraft Details");
                Console.WriteLine("5. Add Flight");
                Console.WriteLine("6. Update Flight Details");
                Console.WriteLine("7. Change Flight Status");
                Console.WriteLine("8. Logout");
            }
            Console.WriteLine("0. Back");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    SignUp();
                    break;
                case "2":
                    LogIn();
                    break;
                case "3":
                    AddAirCraft();
                    break;
                case "4":
                    UpdateAirCraftDetails();
                    break;
                case "5":
                    AddFlight();
                    break;
                case "6":
                    UpdateFlightDetails();
                    break;
                case "7":
                    ChangeFlightsStatus();
                    break;
                case "8":
                    LogOut();
                    break;                        
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
