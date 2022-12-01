using personItem;

namespace personUtility
{
    public class PersonUtility
    {
        private Person[] myPersons;

        public PersonUtility(Person[] myPersons)
        {
            this.myPersons = myPersons;
        }

        // string sortKey = lastName + firstName;


        //find people
        public int FindPerson(int searchVal)
        {
            for(int i = 0; i < Person.GetCount(); i++)
            {
                if(myPersons[i].CompareTo(searchVal) == 0) return i;
            }
            return -1;
        }

        public int NewPerson(int newValue)
        {
            for(int i = 0; i < Person.GetCount() + 1; i++) //same as find person, except there is a +1 to add a new line
            {
                if(myPersons[i].NewCompare(newValue) == 0) return i;
            }
            return -1;
        }
        public void SortPersonByEmail()
        {
            for(int i = 0; i < Person.GetCount() - 1; i++)
            {
                int min = i;
                for(int j = i + 1; j < Person.GetCount(); j++)
                {
                    if(myPersons[j].GetEmail().CompareTo(myPersons[min].GetEmail()) < 0)
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    Swap(min, i);
                }
            }
        }
        public void Swap(int x, int y)
        {
            Person temp = myPersons[x];
            myPersons[x] = myPersons[y];
            myPersons[y] = temp;
        }
    }
}