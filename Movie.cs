namespace movieItem
{
    public class Movie
    {
        private int movieID;
        private string title;
        private string genre;
        private int year;
        private double price;
        private int rating;
        private bool availibility;
        private static int count;
        private bool deleted;

        public Movie(int movieID, string title, string genre, int year, double price, int rating, bool availibility, bool deleted)
        {
            this.movieID = movieID;
            this.title = title;
            this.genre = genre;
            this.year = year;
            this.price = price;
            this.rating = rating;
            this.availibility = availibility;
            this.deleted = deleted;
            int i = count;
        }

        public Movie()
        {

        }

        public void SetMovieID(int movieID) //linked with person when they rent a movie
        {
            this.movieID = movieID;
        }
        public int GetMovieID()
        {
            return movieID;
        }
        public void SetTitle(string title) //person will select this instead of an id
        {
            this.title = title;
        }
        public string GetTitle()
        {
            return title;
        }
        
        public void SetGenre(string genre) //
        {
            this.genre = genre;
        }
        public string GetGenre()
        {
            return genre;
        }
        public void SetYear(int year)
        {
            this.year = year;
        }
        public int GetYear()
        {
            return year;
        }
        public void SetPrice(double price) //I want this to have a fluctation, as in I want there to be a price for a childrens movie, discount for new releases, and a normal movie prices
        {
            this.price = price;
        }
        public double GetPrice()
        {
            return price;
        }
        public void SetRating(int rating)
        {
            this.rating = rating;
        }
        public double GetRating()
        {
            return rating;
        }
        public void SetAvailibility(bool availibility) //movie is either available or it is not, I am not sure how this is going to appear in movieinventory.txt
        {
            this.availibility = availibility;
        }
        public bool GetAvailibility()
        {
            return availibility;
        }
        public void SetDeleted(bool deleted)
        {
            this.deleted = deleted;
        }
        public bool GetDeleted()
        {
            return deleted;
        }
        public static void SetCount(int count)
        {
            Movie.count = count;
        }
        public static int GetCount()
        {
            return count;
        }
        public static void IncCount()
        {
            count++;
        }
        public int CompareTo(int i)
        {
            if(i == movieID) return 0;
            if(i < movieID) return -1;
            return i;
        }
        //this helps in writing a new movie to file
        public int NewCompare(int i)
        {
            if(i > movieID) return i;
            if(i == movieID) return -1;
            return i;
        }

        public override string ToString()
        {
            return movieID + "\t" + title + "\t" + genre + "\t" + year + "\t" + price + "\t" + rating + "\t" + availibility + "\t" + deleted;
        }

        public string ToFile()
        {
            return movieID + "#" + title + "#" + genre + "#" + year + "#" + price + "#" + rating + "#" + availibility + "#" + deleted;
        }
    }    
}