namespace paymentItem
{
    public class Payment
    {
        private int transID;
        private string email;
        private int movieID;
        private string title;
        private string genre;
        public DateTime buyDate;
        public DateTime returnDate;
        private static int count;

        public Payment(int transID, string email, int movieID, string title, string genre, DateTime buyDate, DateTime returnDate)
        {
            this.transID = transID;
            this.email= email;
            this.movieID = movieID;
            this.title = title;
            this.genre = genre;
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
        public void SetBuy(DateTime buyDate) //gets current day
        {
            this.buyDate = DateTime.Today;
        }
        public DateTime GetBuy()
        {
            return buyDate;
        }
        public void SetReturn(DateTime returnDate) //adds one week onto buy date, punishes customer for returning late
        {
            this.returnDate = DateTime.Today;
        }
        public DateTime GetReturn()
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

        //int transID, string email, int movieID, string title, string genre, int cardNumber, int buyDate, int returnDate
        
        public override string ToString()
        {
            return transID + "\t" + email + "\t" + movieID + "\t" + title + "\t" + genre + "\t" + buyDate + "\t" + returnDate;
        }

        public string ToReturnString()
        {
            return transID + "#" + email + "#" + movieID + "***RETURN***";
        }

        public string ToFile()
        {
            return transID + "#" + email + "#" + movieID + "#" + title + "#" + genre + "#" + buyDate + "#" + returnDate;
        }
    }
}