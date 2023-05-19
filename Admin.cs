public class Admin {    
    public int AdminId;
    public string Role;
    public string PhoneNo;
    public string Email ;
    public string Password;
    public string FirstName ;
    public string LastName ;
    public string Username ;

    
    public void SignUp();
    public void LogIn();
    public void UpdatingUserDetails();
    public void AddAirCraft();
    public void UpdateAirCraftDetails();
    public void AddFlight();
    public void UpdateFlightDetails();
    public void ChangeFlightsStatus();

    private static void AdminMenu()
{
    Admin admin = new Admin(); 
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
                admin.SignUp();
                break;
            case "2":
                if (!loggedIn)
                {
                    admin.LogIn();
                    loggedIn = true;
                    Console.WriteLine("Login successful!");
                }
                else
                {
                    Console.WriteLine("You are already logged in.");
                }
                break;
            case "3":
                if (loggedIn)
                {
                    admin.AddAirCraft();
                }
                else
                {
                    Console.WriteLine("You must log in first.");
                }
                break;
            case "4":
                if (loggedIn)
                {
                    admin.UpdateAirCraftDetails();
                }
                else
                {
                    Console.WriteLine("You must log in first.");
                }
                break;
            case "5":
                if (loggedIn)
                {
                    admin.AddFlight();
                }
                else
                {
                    Console.WriteLine("You must log in first.");
                }
                break;
            case "6":
                if (loggedIn)
                {
                    admin.UpdateFlightDetails();
                }
                else
                {
                    Console.WriteLine("You must log in first.");
                }
                break;
            case "7":
                if (loggedIn)
                {
                    admin.ChangeFlightStatus();
                }
                else
                {
                    Console.WriteLine("You must log in first.");
                }
                break;
            case "8":
                if (loggedIn)
                {
                    loggedIn = false;
                    Console.WriteLine("Logged out successfully.");
                }
                else
                {
                    Console.WriteLine("You are not logged in.");
                }
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