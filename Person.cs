namespace personItem
{
    public class Person
    {
        private int personID;
        private string email;
        private static int count;

        public Person(int personID, string email)
        {
            this.personID = personID;
            this.email = email;
            int i = count;
        }
        public Person()
        {
            
        }

        public void SetPersonID(int personID)
        {
            this.personID = personID;
        }
        public int GetPersonID()
        {
            return personID;
        }
    
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public string GetEmail()
        {
            return email;
        }
        public static void SetCount(int count)
        {
            Person.count = count;
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
            if(i == personID) return 0;
            if(i < personID) return -1;
            return i;
        }
        public int NewCompare(int i)
        {
            if(i > personID) return 0;
            if(i == -1) return -1;
            return i;
        }

        public override string ToString()
        {
            return personID + "\t" + email;
        }
        
        public string ToFile()
        {
            return personID + "#" + email;
        }
    }
}