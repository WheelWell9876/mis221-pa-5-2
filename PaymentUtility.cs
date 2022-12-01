using paymentItem;

namespace paymentUtility
{
    public class PaymentUtility
    {
        private Payment[] myPayments;

        public PaymentUtility(Payment[] myPayments)
        {
            this.myPayments = myPayments;
        }

        //find payments
        public int FindPayments(int searchVal)
        {
            for(int i = 0; i < Payment.GetCount(); i++)
            {
                if(myPayments[i].CompareToTrans(searchVal) == 0) return i;
            }
            return -1;
        }

        // public string FindPersonInPayment()
        // {
        //     for(int i = 0; i < Payment.GetCount(); i++)
        //     {
        //         myPayments[i].CompareToTrans().GetEmail();
        //     }
        //     return myPayments[i].GetEmail();
        // }

        //get transactions by genre
        public void BubbleSort()
        {
            for(int i = 0; i < Payment.GetCount(); i++)
            {
                int min = i;
                for(int j = i + 1; j < myPayments[i].GetGenre().CompareTo(myPayments[min]); i++)
                {
                    myPayments[i].GetGenre().CompareTo(myPayments[min]);
                }
            }
        }

        //selection for used to sort payemnts
        // static void SelectionSortPayment(Payment[] myPayments)
        // {
        //     int min;
        //     int max;

        //     for(int i = 0; i < Payment.GetCount(); i++)
        //     {
        //         min = i;
        //         for(int j = 0; j < Payment.GetCount(); i++)
        //         {
        //             max = j;
        //             if(myPayments);
        //         }
        //     }
        // }

        public int NewPayment(int newValue) 
        {
            for(int i = 0; i < Payment.GetCount() + 1; i++) //same as find payment, except there is a +1 to add a new line
            {
                if(myPayments[i].NewCompare(newValue) == 0) return i;
            }
            return -1;
        }


        public void SortGenre()
        {
            for(int i = 0; i < Payment.GetCount(); i++)
            {
                int min = i;
                for(int j = i + 1; j < Payment.GetCount(); j++)
                {
                    if(myPayments[j].GetGenre().CompareTo(myPayments[min].GetGenre()) < 0)
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
            for(int i = 0; i < Payment.GetCount(); i++)
            {
                int min = i;
                for(int j = i + 1; j < Payment.GetCount(); j++)
                {
                    if(myPayments[j].GetTitle().CompareTo(myPayments[min].GetTitle()) < 0)
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
            Payment temp = myPayments[x];
            myPayments[x] = myPayments[y];
            myPayments[y] = temp;
        }

        // public static int ReadInteger() 
        // {
        //     bool nice = true;
        //     while(nice == true) 
        //     {
        //         var input = Console.ReadLine();
        //         var num = input;
        //         if(int.TryParse(input, out num))
        //         {
        //             return num;
        //         }
        //     }
        // }
        public static DateOnly PromptDateOnly()
        {
            Console.WriteLine("Day: ");
            var day = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Month: ");
            var month = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Year: ");
            var year = Convert.ToInt32(Console.ReadLine());

            return new DateOnly(year, month, day);
        }
    }
}