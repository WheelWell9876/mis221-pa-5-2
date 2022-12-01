using movieItem;
using personItem;
using paymentItem;

namespace fileItem
{
    public class FileItem
    {
        ///////////////////////////MOVIES///////////////////////////
        private Movie[] myMovies;
        private Payment[] myPayments;
        private Person[] myPersons;

        public FileItem(Movie[] myMovies, Payment[] myPayments, Person[] myPersons)
        {
            this.myMovies = myMovies;
            this.myPayments = myPayments;
            this.myPersons = myPersons;
        }
        //reading information from file
        public Movie[] GetAllMovies()
        {
            int count = 0;
            count++;
            Movie.SetCount(0);
            StreamReader infile = new StreamReader("movieinventory.txt");
            string line = infile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split("#");
                myMovies[Movie.GetCount()] = new Movie((int.Parse(temp[0])), temp[1], temp[2], (int.Parse(temp[3])),
                (double.Parse(temp[4])), (int.Parse(temp[5])), (double.Parse(temp[6])), (int.Parse(temp[7])), (bool.Parse(temp[8])), (bool.Parse(temp[9])));
                //movie count
                Movie.IncCount();
                line = infile.ReadLine(); //update read
            }
            infile.Close();
            return myMovies;
        }
        //movie save
        public void SaveMovie(Movie[] myMovies)
        {
            
            StreamWriter outFile = new StreamWriter("movieinventory.txt");
            for(int i = 0; i < Movie.GetCount(); i++)
            {
                outFile.WriteLine(myMovies[i].ToFile());
            }
            outFile.Close();
        }


        ///////////////////////////PAYMENTS///////////////////////////
        //read all payments
        public Payment[] GetAllPayments()
        {
            int count = 0;
            count++;
            Payment.SetCount(0);
            StreamReader inFile = new StreamReader("payments.txt");
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split("#");
                myPayments[Payment.GetCount()] = new Payment(int.Parse(temp[0]), temp[1], int.Parse(temp[2]), 
                temp[3], temp[4], (double.Parse(temp[5])), DateTime.Parse(temp[6]), DateTime.Parse(temp[7]));
                //item count
                Payment.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
            return myPayments;
        }
        //payment save
        public void SavePayment(Payment[] myPayments)
        {
            StreamWriter outFile = new StreamWriter("payments.txt");
            for(int i = 0; i < Payment.GetCount(); i++)
            {
                outFile.WriteLine(myPayments[i].ToFile());
            }
            outFile.Close();
        }


        ///////////////////////////PEOPLE///////////////////////////
        //read all persons
        public Person[] GetAllPersons()
        {
            int count = 0;
            count++;
            Person.SetCount(0);
            StreamReader infile = new StreamReader("persons.txt");
            string line = infile.ReadLine();

            while(line != null)
            {
                string[] temp = line.Split("#");
                myPersons[Person.GetCount()] = new Person((int.Parse(temp[0])), temp[1]);
                //person count
                Person.IncCount();
                line = infile.ReadLine(); //update read
            }
            infile.Close();
            return myPersons;
        }
        //person save
        public void SavePerson(Person[] myPersons)
        {
            StreamWriter outFile = new StreamWriter("persons.txt");

            for(int i = 0; i < Person.GetCount(); i++)
            {
                outFile.WriteLine(myPersons[i].ToFile());
            }
            outFile.Close();
        }
    }
}