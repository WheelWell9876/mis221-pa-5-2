using paymentItem;
using personItem;
using movieItem;
using paymentUtility;
using movieUtility;
using personUtility;
using calculations;
using fileItem;
using System.Linq;

Movie[] myMovies = new Movie[100];
MovieUtility movieUtility = new MovieUtility(myMovies);
MovieReports movieReports = new MovieReports(myMovies);
Payment[] myPayments = new Payment[100];
PaymentUtility paymentUtility = new PaymentUtility(myPayments);
PaymentReports paymentReports = new PaymentReports(myPayments);
Person[] myPersons = new Person[100];
PersonUtility personUtility = new PersonUtility(myPersons);
PersonReports personReports = new PersonReports(myPersons);
FileItem file = new FileItem(myMovies, myPayments, myPersons);
StartMenu(myMovies, myPayments, myPersons, movieUtility, paymentUtility, personUtility, movieReports, paymentReports, personReports, file);
// file.GetAllMovies();
// file.GetAllPayments();
// file.GetAllPersons();
// EditMovie(myMovies, movieUtility, movieReports, file);
// EditPayment(myPayments, paymentUtility, paymentReports, file);
// EditPerson(myPersons, personUtility, personReports, file);
// Console.BackgroundColor = ConsoleColor.Red;


//WELCOME TA'S!
/////TABLE OF CONTENTS/////

//Start Menu line:      33
//Customer Rents menu:
//Admin Menu line:      208

static bool StartMenu(Movie[] myMovies, Payment[] myPayments, Person[] myPersons, MovieUtility movieUtility, PaymentUtility paymentUtility, PersonUtility personUtility, MovieReports movieReports, PaymentReports paymentReports, PersonReports personReports, FileItem file)
{
    Console.Clear();
    bool SelectOption = true;
    while(SelectOption == true)
    {
        System.Console.WriteLine("Welcome to Video Mart!");
        System.Console.WriteLine("Please select an option below.");
        System.Console.WriteLine("1. Existing Customer");
        System.Console.WriteLine("2. New Customer");
        System.Console.WriteLine("3. Admin");
        System.Console.WriteLine("4. Exit");
        System.Console.WriteLine(" ");
        switch(Console.ReadLine())
        {
            case "1":
                ExistingCustomerMenu(myMovies, myPayments, myPersons, movieUtility, paymentUtility, personUtility, movieReports, paymentReports, personReports, file);
                SelectOption = true;
                break;
            case "2":
                NewCustomerMenu(myPersons, personUtility, personReports, file);
                SelectOption = true;
                break;
            case "3":
                AdminMenu(myMovies, myPayments, myPersons, movieUtility, paymentUtility, personUtility, movieReports, paymentReports, personReports, file);
                SelectOption = true;
                break;
            case "4":
                SelectOption = false;
                break;
            default:
                System.Console.WriteLine("Invalid Response! Please Select 1, 2, 3, or 4.");
                break;
        }
    }
    return SelectOption;
}


static bool ExistingCustomerMenu(Movie[] myMovies, Payment[] myPayments, Person[] myPersons, MovieUtility movieUtility, PaymentUtility paymentUtility, PersonUtility personUtility,  MovieReports movieReports, PaymentReports paymentReports, PersonReports personReports, FileItem file)
{
    bool SelectEmail = true;
    myPersons = file.GetAllPersons();
    file.GetAllPersons();
    System.Console.WriteLine("Please enter your email.");
    string userEmail = Console.ReadLine();
    for(int i = 0; i < Person.GetCount(); i++)
    {
        if(userEmail == myPersons[i].GetEmail())
        {
            SelectEmail = true;
        }
    }
    bool SelectOption = true;
    bool CustomerOption = true;
    if(SelectEmail == true){
        // SelectOption = true;
        System.Console.WriteLine(" ");
        while(SelectOption == true)
        {   
            while(CustomerOption == true)
            {
                System.Console.WriteLine(" ");
                System.Console.WriteLine($"Welcome {userEmail}. What would you like to do?");
                System.Console.WriteLine("1. View all movies by ID");
                System.Console.WriteLine("2. View currently available movies.");
                System.Console.WriteLine("3. View our top 5 most rented movies");
                System.Console.WriteLine("4. View movies by Genre");
                System.Console.WriteLine("5. View movies by Title");
                System.Console.WriteLine("6. View movies by Year released.");
                System.Console.WriteLine("7. View movies by Rating");
                System.Console.WriteLine("*************************");
                System.Console.WriteLine("8. Rent a movie");
                System.Console.WriteLine("9. View currently rented movies.");
                System.Console.WriteLine("10. Return movie");
                System.Console.WriteLine("11. Exit to Main Menu");
                System.Console.WriteLine("*************************");
                System.Console.WriteLine(" ");
                switch(Console.ReadLine())
                {
                    case "1":
                        movieReports.PrintAllMovies(myMovies, file);
                        CustomerOption = true;
                        break;
                    case "2":
                        movieReports.CurrentlyAvailable(myMovies, file);
                        CustomerOption = true;
                        break;
                    // case "3":
                    //     movieReports.TopFiveMovies(myMovies, myPayments, paymentUtility, paymentReports, file);
                    //     SelectOption = true;
                    //     break;
                    case "4":
                        movieReports.PrintByGenre(myMovies, movieUtility, file);
                        CustomerOption = true;
                        break;
                    case "5":
                        paymentReports.RentalsPerTitle(myPayments, paymentUtility, file);
                        CustomerOption = true;
                        break;
                    case "6":
                        movieReports.PrintByYear(myMovies, movieUtility, file);
                        CustomerOption = true;
                        break;
                    case "7":
                        movieReports.PrintByRating(myMovies, movieUtility, file);
                        CustomerOption = true;
                        break;
                    case "8":
                        RentMovie(myMovies, myPayments, myPersons, movieUtility, paymentUtility, personUtility, movieReports, paymentReports, personReports, file);
                        CustomerOption = true;
                        break;
                    case "9":
                        ViewCurrentMovies(myPayments, paymentUtility);
                        CustomerOption = true;
                        break;
                    case "10":
                        ReturnMovie(myMovies, movieUtility, movieReports, file);
                        CustomerOption = true;
                        break;
                    case "11":
                        CustomerOption = false;
                        break;
                    default:
                        System.Console.WriteLine("Invalid Response! Please Select 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, or type 11 to exit.");
                        break;
                }
            }
            return CustomerOption;
        }
        return SelectOption;
    }
    else if(SelectEmail == false)
    {
        System.Console.WriteLine("You must have an account to rent a movie");
        AddPerson(myPersons, personUtility, personReports, file);
    }
    return SelectOption;
}

static bool NewCustomerMenu(Person[] myPersons, PersonUtility personUtility, PersonReports personReports, FileItem file)
{
    Console.Clear();
    bool SelectOption = true;
    while(SelectOption == true)
    {
        System.Console.WriteLine("Welcome new customer!");
        System.Console.WriteLine("Please create an account or exit if you have already shopped with us.");
        System.Console.WriteLine("1. Create new account");
        System.Console.WriteLine("2. Exit to main menu");

        switch(Console.ReadLine())
        {
            case "1":
                AddPerson(myPersons, personUtility, personReports, file);
                SelectOption = true;
                break;
            case "2":
                SelectOption = false;
                break;
            default:
                System.Console.WriteLine("Invalid input. Please type '1' or '2'");
                break;
        }
    }
    return SelectOption;
}

static bool AdminMenu(Movie[] myMovies, Payment[] myPayments, Person[] myPersons, MovieUtility movieUtility, PaymentUtility paymentUtility, PersonUtility personUtility, MovieReports movieReports, PaymentReports paymentReports, PersonReports personReports, FileItem file)
{
    Console.Clear();
    bool SelectEmail = false;
    System.Console.WriteLine("Please enter the admin email. It's 'adminemail'");
    string userEmail = Console.ReadLine();
    if(userEmail == "adminemail")
    {
        SelectEmail = true;
    }
    bool AdminOption = true;
    if(SelectEmail == true)
    {
        while(AdminOption == true)
        {
            System.Console.WriteLine(" ");
            System.Console.WriteLine("Welcome admin! What would you like to do?");
            System.Console.WriteLine("1. View all movies by ID.");
            System.Console.WriteLine("2. Add new movie to inventory.");
            System.Console.WriteLine("3. Remove movie from inventory.");
            System.Console.WriteLine("4. Re-add movie on file.");
            System.Console.WriteLine("5. Edit movie information.");
            System.Console.WriteLine("6. Edit payment information.");
            System.Console.WriteLine("7. Edit person information.");
            System.Console.WriteLine("8. Add new person.");
            System.Console.WriteLine("9. Access Report Menu.");
            System.Console.WriteLine("10. Exit to Main Menu.");
            System.Console.WriteLine(" ");

            switch(Console.ReadLine())
            {
                case "1":
                    movieReports.PrintAllMovies(myMovies, file);
                    AdminOption = true;
                    break;
                case "2":
                    AddMovie(movieReports, myMovies, movieUtility, file);
                    AdminOption = true;
                    break;
                case "3":
                    RemoveMovie(movieReports, myMovies, movieUtility, file);
                    AdminOption = true;
                    break;
                case "4":
                    UndoDeleteMovie(myMovies, movieUtility, movieReports, file);
                    AdminOption = true;
                    break;
                case "5":
                    EditMovie(myMovies, movieUtility, movieReports, file);
                    AdminOption = true;
                    break;
                case "6":
                    EditPayment(myPayments, paymentUtility, paymentReports, file);
                    AdminOption = true;
                    break;
                case "7":
                    EditPerson(myPersons, personUtility, personReports, file);
                    AdminOption = true;
                    break;
                case "8":
                    AddPerson(myPersons, personUtility, personReports, file);
                    AdminOption = true;
                    break;
                case "9":
                    AccessReports(myMovies, myPayments, myPersons, movieUtility, paymentUtility, personUtility, movieReports, paymentReports, personReports, file);
                    AdminOption = true;
                    break;
                case "10":
                    AdminOption = false;
                    break;
                default:
                    System.Console.WriteLine("Invalid input. Please type 1, 2, 3, 4, 5, or 6.");
                    break;
            }
        }
        return AdminOption;
    }
    else if(SelectEmail == false)
    {
        System.Console.WriteLine("You must enter the correct admin email.");
    }
    return AdminOption;
    
}


////ADMIN ACCESSES REPORTS////
static bool AccessReports(Movie[] myMovies, Payment[] myPayments, Person[] myPersons, MovieUtility movieUtility, PaymentUtility paymentUtility, PersonUtility personUtility, MovieReports movieReports, PaymentReports paymentReports, PersonReports personReports, FileItem file)
{
    Console.Clear();
    bool AdminOption = true;
    while(AdminOption == true)
    {
        System.Console.WriteLine(" ");
        System.Console.WriteLine("What reports would you like to see?");
        System.Console.WriteLine("1. Print all movies by ID.");
        System.Console.WriteLine("2. Print all movies listed by Genre.");
        System.Console.WriteLine("3. Print all movies listed by Title.");
        System.Console.WriteLine("4. Print all movies listed by Year.");
        System.Console.WriteLine("5. Print all movies listed by Rating.");
        System.Console.WriteLine("6. Currently available movies.");
        System.Console.WriteLine("7. Currently rented movies.");
        System.Console.WriteLine("8. Rentals per Genre.");
        System.Console.WriteLine("9. Rentals per Title.");
        System.Console.WriteLine("10. Top five movies rented.(Does not work)");
        System.Console.WriteLine("11. Top five movies rented per genre.(Does not work)");
        System.Console.WriteLine("12. Print all transactions.");
        System.Console.WriteLine("13. Total tansactions.");
        System.Console.WriteLine("14. Total revenue.");
        System.Console.WriteLine("15. Print all persons.");
        System.Console.WriteLine("16. Total persons.");
        System.Console.WriteLine("17. Exit to Admin menu.");
        switch(Console.ReadLine())
        {
            case "1":
                movieReports.PrintAllMovies(myMovies, file);
                AdminOption = true;
                break;
            case "2":
                movieReports.PrintByGenre(myMovies, movieUtility, file);
                AdminOption = true;
                break;
            case "3":
                paymentReports.RentalsPerTitle(myPayments, paymentUtility, file);
                AdminOption = true;
                break;
            case "4":
                movieReports.PrintByYear(myMovies, movieUtility, file);
                AdminOption = true;
                break;
            case "5":
                movieReports.PrintByRating(myMovies, movieUtility, file);
                AdminOption = true;
                break;
            case "6":
                movieReports.CurrentlyAvailable(myMovies, file);
                AdminOption = true;
                break;
            case "7":
                movieReports.CurrentlyRented(myMovies, file);
                AdminOption = true;
                break;
            case "8":
                paymentReports.RentalsPerGenre(myPayments, paymentUtility, file);
                AdminOption = true;
                break;
            case "9":
                paymentReports.RentalsPerTitle(myPayments, paymentUtility, file);
                AdminOption = true;
                break;
            // case "10":
            //     movieReports.TopFiveMovies(myMovies, myPayments, paymentUtility, paymentReports, file);
            //     AdminOption = true;
            //     break;
            // case "11":
            //     movieReports.TopFivePerGenre(myMovies, myPayments, paymentUtility, paymentReports, file);
            //     AdminOption = true;
            //     break;
            case "12":
                paymentReports.PrintAllPayments(myPayments, file);
                AdminOption = true;
                break;
            case "13":
                paymentReports.TotalPayments(myPayments, file);
                AdminOption = true;
                break;
            case "14":
                paymentReports.TotalRevenue(myPayments, file);
                AdminOption = true;
                break;
            case "15":
                personReports.PrintAllPersons(myPersons, file);
                AdminOption = true;
                break;
            case "16":
                personReports.TotalPersons(myPersons, file);
                AdminOption = true;
                break;
            case "17":
                AdminOption = false;
                break;
            default:
                System.Console.WriteLine("Invalid Response! Please Select 1, 2, 3, 4 or 5");
                break;
        }
    }
    return AdminOption;
}

////USER RENTS A MOVIE////
static void RentMovie(Movie[] myMovies, Payment[] myPayments, Person[] myPersons, MovieUtility movieUtility, PaymentUtility paymentUtility, PersonUtility personUtility, MovieReports movieReports, PaymentReports paymentReports, PersonReports personReports, FileItem file)
{
    System.Console.WriteLine("entered method");
    myPayments = file.GetAllPayments();
    // file.GetAllPayments();
    myMovies = new Movie[100];
    myMovies = file.GetAllMovies();
    // file.GetAllMovies();
    // myPersons = file.GetAllPersons();
    // file.GetAllPersons();

    System.Console.WriteLine("***********Here is our list of movies.***********");
    movieReports.PrintAllMovies(myMovies, file);
    System.Console.WriteLine("Please select the movie you would like by typing the movie ID.");

    int newID = (int.Parse(Console.ReadLine()));
    int index = movieUtility.NewFind(newID);

    System.Console.WriteLine(newID);
    System.Console.WriteLine(myMovies[index].GetTitle());
    // System.Console.WriteLine(Payment.GetCount());
    Console.ReadKey();

    int transID = Payment.GetCount();
    string payEmail = myPersons[newID].GetEmail();
    string movTitle = myMovies[index].GetTitle();
    int payID = Movie.GetCount();
    string movGenre = myMovies[index].GetGenre();
    int movYear = myMovies[index].GetYear();
    double goodPrice = myMovies[index].GetPrice();
    int rate = (int)myMovies[index].GetRating();
    DateOnly rentingDate = DateOnly.FromDateTime(DateTime.Today);
    DateOnly returningDate = DateOnly.FromDateTime(DateTime.Today);
    returningDate = returningDate.AddDays(7);
    myMovies[index].SetAvailibility(false);
    bool inventory = false;
    bool deleted = false;
    System.Console.WriteLine(rate + "\t" + goodPrice);

    myMovies[newID] = new Movie(newID, movTitle, movGenre, movYear, goodPrice, rate, inventory, deleted);
    myPayments[Payment.GetCount()] = new Payment(transID, payEmail, payID, movTitle, movGenre, goodPrice, rentingDate, returningDate);
    

    myPayments[newID] = new Payment();
    Payment.IncCount();

    // myPayments[index].SetPrice(9.99)

    // StreamWriter outFile = new StreamWriter("payments.txt", true);
    // File.AppendAllText("payments.txt", outFile.ToString() + Environment.NewLine);
    file.SavePayment(myPayments); //writes new transaction to file on a new line
    System.Console.WriteLine("****************************************************");
    System.Console.WriteLine($"Congradulations! You have rented a movie! Return it on {returningDate} .......Or you will be fined one million dollars per day!");
    System.Console.WriteLine("****************************************************");
}

////USER RETURNS CURRENTLY RENTED MOVIE////
static void ReturnMovie(Movie[] myMovies, MovieUtility movieUtility, MovieReports movieReports, FileItem file)
{
    myMovies = file.GetAllMovies();
    file.GetAllMovies();
    movieReports.PrintAllMovies(myMovies, file);
    System.Console.WriteLine("Pick the ID of the movie that you would like to return. Press -1 to cancel");
    int editId = int.Parse(Console.ReadLine());
    int index = movieUtility.FindMovie(editId); //finds movie
    if(index != -1)
    {
        myMovies[index].SetAvailibility(true); //soft add
        System.Console.WriteLine("What would you rate this movie? Please select 1-10 (1 is terrible, 10 is excellent)");
        int addRating = int.Parse(Console.ReadLine());
        myMovies[index].SetRating(addRating);
    }
    StreamWriter outFile = new StreamWriter("movieinventory.txt", true);
    outFile.WriteLine(myMovies[index].ToFile());
    file.SaveMovie(myMovies);
    //give rating system
}

static void ViewCurrentMovies(Payment[] myPayments, PaymentUtility paymentUtility)
{
    System.Console.WriteLine("Enter your email.");
    string userEmail = Console.ReadLine();
    // string index = paymentUtility.FindPersonInPayment(userEmail);
}

//ADMIN ADDS BRAND MOVIE TO INVENTORY////
static void AddMovie(MovieReports movieReports, Movie[] myMovies, MovieUtility movieUtility, FileItem file)
{
    myMovies = file.GetAllMovies();
    file.GetAllMovies();
    movieReports.PrintAllMovies(myMovies, file); //prints all current movies, not the one thats about to be created
    System.Console.WriteLine("Pick an ID for your new movie. Type -1 to cancel.");
    int newID = int.Parse(Console.ReadLine()); //calls method in MovieUtility
    int index = Movie.GetCount(); //index to create a new movie where (Movie.GetCount + 1) differs from (Movie.GetCount) used in the FindMovie function
    // System.Console.WriteLine(index);
    if(index != -1) //if user does not type -1, a new movie will be created
    {
        myMovies[index] = new Movie();
        Movie.IncCount();
        //movieID + "#" + title + "#" + genre + "#" + year + "#" + price + "#" + rating + "#" + totalRating + "#" + timesRented + "#" + availibility + "#" + deleted;
        System.Console.WriteLine("Here's the current values: ");
        // System.Console.WriteLine(myMovies[index].ToString()); //prints current values of movieID
        System.Console.WriteLine("What should the Title be?"); //title
        myMovies[index].SetMovieID(index + 1);
        myMovies[index].SetTitle(Console.ReadLine());
        System.Console.WriteLine("What should the Genre be?"); //genre
        myMovies[index].SetGenre(Console.ReadLine());
        System.Console.WriteLine("What is the year is was released?");
        myMovies[index].SetYear(int.Parse(Console.ReadLine()));
        System.Console.WriteLine("What is the price?");
        myMovies[index].SetPrice(double.Parse(Console.ReadLine()));
        myMovies[index].SetRating(0);
        System.Console.WriteLine("Would you like to make this movie availible for purchase? Type 'true' or 'false'"); //availability
        myMovies[index].SetAvailibility(bool.Parse(Console.ReadLine()));
        myMovies[index].SetDeleted(false);

    }
    StreamWriter outFile = new StreamWriter("movieinventory.txt", true);
    outFile.WriteLine(myMovies[index].ToFile());
    file.SaveMovie(myMovies);
}


//ADMIN REMOVES MOVIE FROM INVENTORY////
static void RemoveMovie(MovieReports movieReports, Movie[] myMovies, MovieUtility movieUtility, FileItem file)
{
    myMovies = file.GetAllMovies();
    file.GetAllMovies();
    movieReports.PrintAllMovies(myMovies, file);
    System.Console.WriteLine("Pick the ID of the movie that you would like to remove. Press ENTER to cancel.");
    int editId = int.Parse(Console.ReadLine());
    int index = movieUtility.FindMovie(editId); //finds movie
    if(index != -1)
    {
        myMovies[index].SetDeleted(true); //soft delete
    }
    StreamWriter outFile = new StreamWriter("movieinventory.txt", true);
    File.AppendAllText("movieinventory.txt", outFile.ToString()); 
}
//ADMIN READDS MOVIE TO INVENTORY//
static void UndoDeleteMovie(Movie[] myMovies, MovieUtility movieUtility, MovieReports movieReports, FileItem file)
{
    myMovies = file.GetAllMovies();
    file.GetAllMovies();
    movieReports.PrintAllMovies(myMovies, file);
    System.Console.WriteLine("Pick the ID of the movie that you would like to remove. Press -1 to cancel.");
    int editID = int.Parse(Console.ReadLine());
    int index = movieUtility.FindMovie(editID);
    if(index != -1)
    {
        myMovies[index].SetDeleted(false);
    }
    StreamWriter outFile = new StreamWriter("movieinventory.txt", true);
    File.AppendAllText("movieinventory.txt", outFile.ToString());
}

static void AddPerson(Person[] myPersons, PersonUtility personUtility, PersonReports personReports, FileItem file)
{
    myPersons = file.GetAllPersons();
    file.GetAllPersons();
    personReports.PrintAllPersons(myPersons, file);
    System.Console.WriteLine("Pick an ID for your new username. Must be an INTEGER and ID that is not currently listed.");
    int newID = int.Parse(Console.ReadLine());
    int index = Person.GetCount();
    if(index != -1)
    {
        myPersons[index] = new Person();
        Person.IncCount();
        System.Console.WriteLine("What is your email?");
        myPersons[index].SetPersonID(index + 1);
        myPersons[index].SetEmail(Console.ReadLine()); 
    }
    StreamWriter outFile = new StreamWriter("persons.txt", true);
    outFile.WriteLine(myPersons[index].ToFile());
    file.SavePerson(myPersons);
    // File.AppendAllText("persons.txt", outFile.ToString() + Environment.NewLine); //setup to write new movie to 'persons.txt'
}

////ADMIN EDITS MOVIE////
static void EditMovie(Movie[] myMovies, MovieUtility movieUtility, MovieReports movieReports, FileItem file)
{
    movieReports.PrintAllMovies(myMovies, file);
    System.Console.WriteLine("Which movie ID would you like to update?");
    int editId = int.Parse(Console.ReadLine());
    int index = movieUtility.FindMovie(editId);
    if(index != -1)
    {
        System.Console.WriteLine("Here's the current values: ");
        System.Console.WriteLine(myMovies[index].ToString());
        System.Console.WriteLine("What should the title be?");
        myMovies[index].SetTitle(Console.ReadLine());
        System.Console.WriteLine("What should the genre be?");
        myMovies[index].SetGenre(Console.ReadLine());
        System.Console.WriteLine("What should the price be?");
        myMovies[index].SetPrice(double.Parse(Console.ReadLine()));
        System.Console.WriteLine("Is the movie availible for purchase? Type 'true' for 'YES' or 'false' for 'NO'.");
        myMovies[index].SetAvailibility(bool.Parse(Console.ReadLine()));
    }
    file.SaveMovie(myMovies);
    // StreamWriter outFile = new StreamWriter("persons.txt", true);
    // File.AppendAllText("persons.txt", outFile.ToString());
}

static void EditPayment(Payment[] myPayments, PaymentUtility paymentUtility, PaymentReports paymentReports, FileItem file)
{
    myPayments = file.GetAllPayments();
    file.GetAllPayments();
    paymentReports.PrintAllPayments(myPayments, file);
    System.Console.WriteLine("Which transaction ID would you like to update?");
    int editId = int.Parse(Console.ReadLine());
    int index = paymentUtility.FindPayments(editId);
    if(index != -1)
    {
        System.Console.WriteLine("Here's the current values: ");
        System.Console.WriteLine(myPayments[index].ToString());
        System.Console.WriteLine("What should the email be?");
        myPayments[index].SetEmail(Console.ReadLine());
        System.Console.WriteLine("What should the movie ID be?");
        myPayments[index].SetMovieID(int.Parse(Console.ReadLine()));
        System.Console.WriteLine("What should the title be?");
        myPayments[index].SetTitle(Console.ReadLine());
        System.Console.WriteLine("What should the genre be?");
        myPayments[index].SetGenre(Console.ReadLine());
        System.Console.WriteLine("What should the last purchased date be? (type: MM/DD/YYYY)");
        myPayments[index].SetBuy(paymentUtility.PromptDateOnly());
        System.Console.WriteLine("What should the last returned date be? (type: MM/DD/YYYY)");
        myPayments[index].SetReturn(paymentUtility.PromptDateOnly());
    }
    file.SavePayment(myPayments);
}

static void EditPerson(Person[] myPersons, PersonUtility personUtility, PersonReports personReports, FileItem file)
{
    myPersons = file.GetAllPersons();
    file.GetAllPersons();
    personReports.PrintAllPersons(myPersons, file);
    System.Console.WriteLine("Which person ID would you like to edit?");
    int editID = int.Parse(Console.ReadLine());
    int index = personUtility.FindPerson(editID);
    if(index != -1)
    {
        System.Console.WriteLine("Where's the current values: ");
        System.Console.WriteLine(myPersons[index].ToString());
        System.Console.WriteLine("What should the email be?");
        myPersons[index].SetEmail(Console.ReadLine());
    }
    file.SavePerson(myPersons);
}
