using movieItem;
using personItem;
using paymentItem;
using movieUtility;
using paymentUtility;
using fileItem;
using personUtility;

namespace calculations
{
    //////////////MOVIE REPORT CLASS//////////////
    public class MovieReports
    {
        private Movie[] myMovies;

        public MovieReports(Movie[] myMovies)
        {
            this.myMovies = myMovies;
        }


        //////print all movies//////
        //prints all movies by ID
        public void PrintAllMovies(Movie[] myMovies, FileItem file)
        {
            Console.Clear();
            myMovies = file.GetAllMovies();
            file.GetAllMovies();
            System.Console.WriteLine("********************Movies Listed by ID********************");
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                System.Console.WriteLine(myMovies[i].ToString());
            }
            System.Console.WriteLine("***************************************************************");
        }
        //print movie by genre
        public void PrintByGenre(Movie[] myMovies, MovieUtility movieUtility, FileItem file)
        {
            Console.Clear();
            myMovies = file.GetAllMovies();
            file.GetAllMovies();
            movieUtility.SortGenre();
            System.Console.WriteLine("********************Movies Listed by Genre********************");
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                System.Console.WriteLine(myMovies[i].GetTitle() + "\t\t" + myMovies[i].GetGenre());
            }
            System.Console.WriteLine("***************************************************************");
        }
        //print movie by alphabetical title
        public void PrintByTitle(Movie[] myMovies, MovieUtility movieUtility, FileItem file)
        {
            Console.Clear();
            myMovies = file.GetAllMovies();
            file.GetAllMovies();
            movieUtility.SortTitle();
            System.Console.WriteLine("********************Movies Listed by Title********************");
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                System.Console.WriteLine(myMovies[i].GetMovieID() + "\t\t" +myMovies[i].GetTitle());
            }
            System.Console.WriteLine("***************************************************************");
        }
        //print movie by year
        public void PrintByYear(Movie[] myMovies, MovieUtility movieUtility, FileItem file)
        {
            Console.Clear();
            myMovies = file.GetAllMovies();
            file.GetAllMovies();
            movieUtility.SortYear();
            System.Console.WriteLine("********************Movies Listed by Year********************");
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                System.Console.WriteLine(myMovies[i].GetTitle() + "\t\t" + myMovies[i].GetYear());
            }
            System.Console.WriteLine("***************************************************************");
        }
        //print movie by total rating
        public void PrintByRating(Movie[] myMovies, MovieUtility movieUtility, FileItem file)
        {
            Console.Clear();
            myMovies = file.GetAllMovies();
            file.GetAllMovies();
            movieUtility.SortRating();
            System.Console.WriteLine("********************Movies Listed by Rating********************");
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                System.Console.WriteLine(myMovies[i].GetTitle() + "\t\t" + myMovies[i].GetRating());
            }
            System.Console.WriteLine("***************************************************************");
        }

        //////movies currently AVAILIBLE//////
        //part of bool function, admin must see what movies are available
        public void CurrentlyAvailable(Movie[] myMovies, FileItem file)
        {
            Console.Clear();
            myMovies = file.GetAllMovies();
            file.GetAllMovies();
            System.Console.WriteLine("********************Currently Available Movies********************");
            System.Console.WriteLine("*****If TRUE, then movie is availible to rent. If FALSE, then movie is rented.*****");
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                if(myMovies[i].GetAvailibility() == true)
                {
                    System.Console.WriteLine(myMovies[i].GetTitle() + "\t\t" + myMovies[i].GetAvailibility());
                }
                
            }
            System.Console.WriteLine("***************************************************************");
        }
        //////movies currently RENTED//////
        //part of the bool availability, the admin must see what movies are rented and what emails have the movies that are rented
        public void CurrentlyRented(Movie[] myMovies, FileItem file)
        {
            Console.Clear();
            myMovies = file.GetAllMovies();
            file.GetAllMovies();
            System.Console.WriteLine("********************Currently Rented Movies********************");
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                if(myMovies[i].GetAvailibility() == false)
                {
                    System.Console.WriteLine(myMovies[i].GetTitle() + "\t\t" + myMovies[i].GetAvailibility());
                }
            }
            System.Console.WriteLine("***************************************************************");
        }

        public void MoviesByRating(Movie[] myMovies, MovieUtility movieUtility, FileItem file)
        {
            int count = 1;
            string currMovie = myMovies[0].GetTitle();
            double sum = myMovies[0].GetRating();
            file.GetAllMovies();
            movieUtility.SortRating();
            for(int i = 1; i < Movie.GetCount(); i++)
            {
                if(currMovie == myMovies[i].GetTitle())
                {
                    sum += myMovies[i].GetRating();
                    count++;
                }
                else
                {
                    ProcessBreakMoviesByRating(ref currMovie, ref sum, ref count, i);
                }
            }
            ProcessBreakMoviesByRating(ref currMovie, ref sum, ref count, 0);
        }
        private void ProcessBreakMoviesByRating(ref string currMovie, ref double sum, ref int count, int i)
        {
            count = 1;
            sum = myMovies[i].GetRating();
            currMovie = myMovies[i].GetTitle();
        }

        // public void MoviesByTitle()
        // {
        //     int count = 1;
            
        // }

        //top five movies per genre
        public void TopFivePerGenre()
        {
            
        }

        static int BinarySearch(Movie[] myMovies, MovieUtility movieUtility, MovieReports movieReports, int searchVal)
        {
            int find = -1;
            int first = 0;
            int last = Movie.GetCount() - 1;
            int middle;
            bool found = false;

            while(!found && first <= last)
            {
                middle = (first + last) / 2;
                if(myMovies[middle].GetMovieID() == searchVal)
                {
                    found = true;
                    find = middle;
                }
                else
                {
                    if(myMovies[middle].GetMovieID() > searchVal)
                    {
                        last = middle - 1;
                    }
                    else
                    {
                        first = middle + 1;
                    }
                }
            }
            return find;
        }

    }

    //////////////PAYMENT REPORT CLASS//////////////
    public class PaymentReports
    {
        private Payment[] myPayments;
        public PaymentReports(Payment[] myPayments)
        {
            this.myPayments = myPayments;
        }
        
        //////rentals per genre//////
        //required part, need to find the amount of rentals in the genre
        public void RentalsPerGenre(Payment[] myPayments, PaymentUtility paymentUtility, FileItem file)
        {
            Console.Clear();
            int count = 1; //start with first genre, say its one
            myPayments = file.GetAllPayments();
            file.GetAllPayments(); //get payments
            paymentUtility.SortGenre(); //sort
            System.Console.WriteLine("********************Rentals Per Genre********************");
            string currGenre = myPayments[0].GetGenre(); //current genre that the reader is on, pins a specific genre for the for loop
            for(int i = 1; i < Payment.GetCount(); i++)
            {
                if(currGenre == myPayments[i].GetGenre())
                {
                    count++; //add count to the current genre
                }
                else
                {
                    ProcessBreakRentalsPerGenre(ref currGenre, ref count, i, myPayments); //break out of current genre, start counting the next
                }
            }
            ProcessBreakRentalsPerGenre(ref currGenre, ref count, 0, myPayments);
            System.Console.WriteLine("***************************************************************");
        }
        //process break
        private void ProcessBreakRentalsPerGenre(ref string currGenre, ref int count, int i, Payment[] myPayments)
        {
            currGenre = myPayments[i].GetGenre(); //makes genre a new one
            System.Console.WriteLine(currGenre + "\t\t" + count); //print results
        }

        public void RentalsPerTitle(Payment[] myPayments, PaymentUtility paymentUtility, FileItem file)
        {
            Console.Clear();
            int count = 1; //start with first title, say its one
            myPayments = file.GetAllPayments();
            file.GetAllPayments(); //get payments
            paymentUtility.SortTitle(); //sort
            System.Console.WriteLine("********************Rentals Per Title********************");
            string currTitle = myPayments[0].GetTitle(); //current title that the reader is on, pins a specific genre for the for loop
            for(int i = 1; i < Payment.GetCount(); i++)
            {
                if(currTitle == myPayments[i].GetTitle())
                {

                    count++; //add count to the current title
                }
                else
                {
                    ProcessBreakRentalsPerTitle(ref currTitle, ref count, i, myPayments); //break out of current title, start counting the next
                }
            }
            ProcessBreakRentalsPerTitle(ref currTitle, ref count, 0, myPayments);
            System.Console.WriteLine("***************************************************************");
        }
        //process break
        private void ProcessBreakRentalsPerTitle(ref string currTitle, ref int count, int i, Payment[] myPayments)
        {
            currTitle = myPayments[i].GetTitle(); //makes genre a new one
            System.Console.WriteLine(currTitle + "\t\t" + count); //print results
        }

        ////top five movies//////

        public void TopFiveMovies(Payment[] myPayments, PaymentUtility paymentUtility, FileItem file)
        {
            Console.Clear();
            myPayments = file.GetAllPayments();
            paymentUtility.SortGenre();
            string currTitle = myPayments[0].GetTitle();
            int count = 1;
            for(int i = 0; i < Payment.GetCount(); i++)
            {
                if(myPayments[i].GetTitle() == currTitle)
                {
                    count++;
                }
                else
                {
                    ProcessBreak3(ref currTitle, ref count, ref i, myPayments);
                }
            }
        }

        static void ProcessBreak3(ref string currTitle, ref int count, ref int i, Payment[] myPayments)
        {
            int[] saveCount = new int [Payment.GetCount()];
            string[] title = new string[Payment.GetCount()];
            currTitle = myPayments[i].GetTitle();
            title[i] = currTitle;
            count = 1;
            for(int j = 0; j < saveCount.Length + 1; j++)
            {
                int min = j;
                for(int k = 0; k < saveCount.Length; k++)
                {
                    if(saveCount[k] < saveCount[min])
                    {
                        min = j;
                    }
                    if(min != j)
                    {
                        SwapTwo(saveCount, min, j);
                    }
                }
                for(int m = 0; m < 5; m++)
                {
                    System.Console.WriteLine(title[m]);
                }
            }
        }

        static void SwapTwo(int[] saveCount, int x, int y)
        {
            int temp = saveCount[x];
            saveCount[x] = saveCount[y];
            saveCount[y] = temp;
        }
        //adds total amount of transactions that have taken place, without the price
        public int TotalPayments(Payment[] myPayments, FileItem file)
        {
            file.GetAllPayments();
            System.Console.WriteLine("**********Total PAYMENT Count**********");
            for(int i = 0; i < Payment.GetCount(); i++)
            {
                Payment.GetCount();
            }
            System.Console.WriteLine($"There are {Payment.GetCount()} total payments on file.");
            return -1;
        }
    

        //adds total prices of movies together from all trasactions that have taken place
        public void TotalRevenue(Payment[] myPayments, FileItem file)
        {
            double totalRevenue = 0.0;
            file.GetAllPayments();
            System.Console.WriteLine("**********Total Revenue**********");
            for(int i = 0; i < Payment.GetCount(); i++)
            {
                totalRevenue += myPayments[i].GetPrice(); 
            }
            System.Console.WriteLine($"Total revenue from this machine is ${totalRevenue}");
        }

        //print all payments with their information from payments.txt
        public void PrintAllPayments(Payment[] myPayments, FileItem file)
        {
            myPayments = file.GetAllPayments(); 
            file.GetAllPayments();
            System.Console.WriteLine("********************Transactions listed by ID********************");
            for(int i = 0; i < Payment.GetCount(); i++)
            {
                System.Console.WriteLine(myPayments[i].ToString());
            }
            System.Console.WriteLine("***************************************************************");
        }

    }

    //////////////PERSON REPORT CLASS//////////////
    public class PersonReports
    {
        private Person[] myPersons;
        public PersonReports(Person[] myPersons)
        {
            this.myPersons = myPersons;
        }

        //same logic as trying to find the top five movies, I am trying to rank the customers by how many times they have purchased a movie
        // public void TopFiveCustomers(Person[] myPersons, Payment[] myPayments, Movie[] myMovies)
        // {
        //     for(int i = 0; i < Person.GetCount() - 1; i++)
        //     {
        //         for(int j = i + 1; j < Person.GetCount(); j++)
        //         {
        //             if((myPersons[i].GetPastRentals() + myPersons[j].GetPastRentals()) > 10)
        //             {
        //                 System.Console.WriteLine();
        //             }
        //         }
        //     }
        // }

        public void RentalsPerPerson(Person[] myPersons, PersonUtility personUtility, FileItem file)
        {
            int count = 1; //start with first title, say its one
            myPersons = file.GetAllPersons();
            file.GetAllPayments(); //get payments
            personUtility.SortPersonByEmail(); //sort
            System.Console.WriteLine("********************Rentals Per Person********************");
            string currTitle = myPersons[0].GetEmail(); //current title that the reader is on, pins a specific genre for the for loop
            for(int i = 1; i < Payment.GetCount(); i++)
            {
                if(currTitle == myPersons[i].GetEmail())
                {
                    count++; //add count to the current title
                }
                else
                {
                    ProcessBreakRentalsPerPerson(ref currTitle, ref count, i); //break out of current title, start counting the next
                }
            }
            ProcessBreakRentalsPerPerson(ref currTitle, ref count, 0);
            System.Console.WriteLine("***************************************************************");
        }
        //process break
        private void ProcessBreakRentalsPerPerson(ref string currTitle, ref int count, int i)
        {
            currTitle = myPersons[i].GetEmail(); //makes genre a new one
            System.Console.WriteLine(currTitle + "\t" + count); //print results
        }

        //this is a function to print all of the persons from the persons.txt file separted by a tab, this will appear in the console
        public void PrintAllPersons(Person[] myPersons, FileItem file)
        {
            myPersons = file.GetAllPersons();
            file.GetAllPersons();
            System.Console.WriteLine("********************Persons listed by ID********************");
            for(int i = 0; i < Person.GetCount(); i++)
            {
                System.Console.WriteLine(myPersons[i].ToString());
            }
            System.Console.WriteLine("***************************************************************");
            
        }

        public int TotalPersons(Person[] myPersons, FileItem file)
        {
            file.GetAllPersons();
            System.Console.WriteLine("**********Total PERSON Count**********");
            for(int i = 0; i < Person.GetCount(); i++)
            {
                Person.GetCount();
            }
            System.Console.WriteLine($"There are {Person.GetCount()} total users on file.");
            return -1;
        }
    }
}