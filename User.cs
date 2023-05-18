public class User{
    public void SignUp();
    public void LogIn();
    public List<Flight> GetAvailableFlights(string condition);
    public void BookFlight();
    public void CancelFlight();
    private static void UserMenu()
{
    User user = new User(); 
    bool back = false;
    bool loggedIn = false;

    while (!back)
    {
        Console.WriteLine("=== User Menu ===");
        if (!loggedIn)
        {
            Console.WriteLine("1. User Sign Up");
            Console.WriteLine("2. User Login");
        }
        else
        {
            Console.WriteLine("3. Get Available Flights");
            Console.WriteLine("4. Book Flight");
            Console.WriteLine("5. Cancel Flight");
            Console.WriteLine("6. Logout");
        }
        Console.WriteLine("0. Back");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        Console.WriteLine();

        switch (choice)
        {
            case "1":
                user.SignUp();
                break;
            case "2":
                if (!loggedIn)
                {
                    user.LogIn();
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
                    Console.WriteLine("Enter search condition :");
                    string condition = Console.ReadLine();
                    var availableFlights = user.GetAvailableFlights(condition);
                    foreach (var flight in availableFlights)
                    {
                        Console.WriteLine($"Flight ID: {flight.FlightId}, Source: {flight.Source}, Destination: {flight.Destination}, Departure Time: {flight.DepartureTime}, Available Seats: {flight.AvailableSeats}");
                    }
                }
                else
                {
                    Console.WriteLine("You must log in first.");
                }
                break;
            case "4":
                if (loggedIn)
                {
                    user.BookFlight();
                }
                else
                {
                    Console.WriteLine("You must log in first.");
                }
                break;
            case "5":
                if (loggedIn)
                {
                    user.CancelFlight();
                }
                else
                {
                    Console.WriteLine("You must log in first.");
                }
                break;
            case "6":
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
