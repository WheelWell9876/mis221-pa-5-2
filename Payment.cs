namespace paymentItem
{
    public class Payment
    {
        private int transID;
        private string email;
        private int movieID;
        private string title;
        private string genre;
        private double price;
        public DateOnly buyDate;
        public DateOnly returnDate;
        private static int count;

        public Payment(int transID, string email, int movieID, string title, string genre, double price, DateOnly buyDate, DateOnly returnDate)
        {
            this.transID = transID;
            this.email= email;
            this.movieID = movieID;
            this.title = title;
            this.genre = genre;
            this.price = price;
            this.buyDate = buyDate;
            this.returnDate = returnDate;
            int i = count;
        }

        public Payment()
        {

        }

        public void SetTransID(int transID) //sets new transaction, this ID will track users and movies
        {
            this.transID = transID;
        }
        public int GetTransID()
        {
            return transID;
        }
        public void SetEmail(string email) //user will enter email for a login
        {
            this.email = email;
        }
        public string GetEmail()
        {
            return email;
        }
        
        public void SetMovieID(int movieID) //used to track who the movie is with and how many times it has been rented
        {
            this.movieID = movieID;
        }
        public int GetMovieID()
        {
            return movieID;
        }
        public void SetTitle(string title) //movie title, linked with movieID, acts more as a display function so customer picks title of movie rather than an ID
        {
            this.title = title;
        }
        public string GetTitle()
        {
            return title;
        }
        public void SetGenre(string genre) //tracks movieIDs and how many times it has been rented
        {
            this.genre = genre;
        }
        public string GetGenre()
        {
            return genre;
        }
        public void SetPrice(double price) //tracks movieIDs and how many times it has been rented
        {
            this.price = price;
        }
        public double GetPrice()
        {
            return price;
        }
        public void SetBuy(DateOnly buyDate) //gets current day
        {
            this.buyDate = DateOnly.FromDateTime(DateTime.Today);
        }
        public DateOnly GetBuy()
        {
            return buyDate;
        }
        public void SetReturn(DateOnly returnDate) //adds one week onto buy date, punishes customer for returning late
        {
            this.returnDate = DateOnly.FromDateTime(DateTime.Today);
        }
        public DateOnly GetReturn()
        {
            return returnDate;
        }

        public static void SetCount(int count) //count function
        {
            Payment.count = count;
        }
        public static int GetCount()
        {
            return count;
        }
        public static void IncCount()
        {
            count++;
        }
        public int CompareToTrans(int i) //used to compare transaction entered by user or admin
        {
            if(i == transID) return 0;
            if(i < transID) return -1;
            return i;
        }
        public int NewCompare(int i) //used to add new payments
        {
            if(i > transID) return 0;
            if(i == transID) return -1;
            return i;
        }
        
        public override string ToString()
        {
            return transID + "\t" + email + "\t" + movieID + "\t" + title + "\t" + genre + "\t" + price + "\t" +buyDate + "\t" + returnDate;
        }

        public string ToReturnString()
        {
            return transID + "#" + email + "#" + movieID + "***RETURN***";
        }

        public string ToFile()
        {
            return transID + "#" + email + "#" + movieID + "#" + title + "#" + genre + "#" + price + "#" + buyDate + "#" + returnDate;
        }
        //int transID, string email, int movieID, string title, string genre, double price, DateOnly buyDate, DateOnly returnDate
    }
}