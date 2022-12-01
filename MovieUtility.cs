using System;
using System.Collections.Generic;
using movieItem;

namespace movieUtility
{
    public class MovieUtility
    {
        private Movie[] myMovies;

        public MovieUtility(Movie[] myMovies)
        {
            this.myMovies = myMovies;
        }

        public int FindMovie(int searchVal)
        {
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                if(myMovies[i].CompareTo(searchVal) == 0) return i;
            }
            return -1;
        }
        
        public int NewFind(int searchVal)
        {
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                if(myMovies[i].GetMovieID().CompareTo(searchVal) == 0) return i;
            }
            return -1;
        }

        //tool to get admin to add new movie to text file
        public int NewMovie(int newValue)
        {
            for(int i = 0; i < Movie.GetCount(); i++) //same as find movie, except there is a +1 to add a new line
            {
                if(myMovies[i].NewCompare(newValue) == Movie.GetCount()) return i;
            }
            return -1;
        }


        //attempting to sort the genre by the times it has been rented
        public void SortGenre()
        {
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                int min = i;
                for(int j = i + 1; j < Movie.GetCount(); j++)
                {
                    if(myMovies[j].GetGenre().CompareTo(myMovies[min].GetGenre()) < 0)
                    {
                        min = j;
                    }
                    if(min != i)
                    {
                        Swap(min, i);
                    }
                }
            }
        }

        public void SortTitle()
        {
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                int min = i;
                for(int j = i + 1; j < Movie.GetCount(); j++)
                {
                    if(myMovies[j].GetTitle().CompareTo(myMovies[min].GetTitle()) > 0)
                    {
                        min = j;
                    }
                    if(min != i)
                    {
                        Swap(min, i);
                    }
                }
            }
        }

        public void SortYear()
        {
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                int min = i;
                for(int j = i + 1; j < Movie.GetCount(); j++)
                {
                    if(myMovies[j].GetYear().CompareTo(myMovies[min].GetYear()) < 0)
                    {
                        min = j;
                    }
                    if(min != i)
                    {
                        Swap(min, i);
                    }
                }
            }
        }

        public void SortRating()
        {
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                int min = i;
                for(int j = i + 1; j < Movie.GetCount(); j++)
                {
                    if(myMovies[j].GetRating().CompareTo(myMovies[min].GetRating()) < 0)
                    {
                        min = j;
                    }
                    if(min != i)
                    {
                        Swap(min, i);
                    }
                }
            }
        }
        
        public void Swap(int x, int y)
        {
            Movie temp = myMovies[x];
            myMovies[x] = myMovies[y];
            myMovies[y] = temp;
        }

        public void MovieRating()
        {
            double rating = 0.0;
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                rating += myMovies[i].GetRating();
            }
            System.Console.WriteLine(rating/Movie.GetCount());
        }
    }
}