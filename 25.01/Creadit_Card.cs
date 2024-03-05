using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._01
{
    internal class Creadit_Card
    {
        public delegate void RefillEventHandler(double amount);
        public delegate void SpendingEventHandler(double amount);
        public delegate void CreditStartEventHandler(double amount);
        public delegate void LimitReachedEventHandler(double amount);
        public delegate void PinChangedEventHandler(int oldPin, int newPin);
        public event RefillEventHandler RefillEvent;
        public event SpendingEventHandler SpendingEvent;
        public event CreditStartEventHandler CreditStartEvent;
        public event LimitReachedEventHandler LimitReachedEvent;
        public event PinChangedEventHandler PinChangedEvent;
        public struct PIP
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FatherName { get; set; }
            public PIP(string firstName, string lastName, string fatherName)
            {
                FirstName = firstName;
                LastName = lastName;
                FatherName = fatherName;
            }
        }
        public PIP pip { get; set; }
        public DateTime CardValid { get; set; }
        public int PIN { private get; set; }
        public double CreaditLimit { get; set; }
        public double MoneyCount { get; set; }
        public Creadit_Card(string firstName, string lastName, string fatherName, string cardValid, int pIN, int creaditLimit, double moneyCount)
        {
            pip = new PIP(firstName, lastName, fatherName);
            CardValid = DateTime.Parse(cardValid);
            PIN = pIN;
            CreaditLimit = creaditLimit;
            MoneyCount = Math.Abs(moneyCount);
        }
        public void Refill(double count)
        {
            if (count > 0)
            {
                MoneyCount += count;
                RefillEvent?.Invoke(count);
            }
            else
            {
                Console.WriteLine("Invalid Count");
            }
        }
        public void Spending(double count)
        {
            if (MoneyCount >= count)
            {
                MoneyCount -= count;
            }
            else if (MoneyCount + CreaditLimit >= count)
            {
                double boof = 0;
                boof = count - MoneyCount;
                count -= boof;
                MoneyCount -= count;
                CreaditStart(boof);
            }
            else
            {
                Limit(count);
            }
        }
        private void CreaditStart(double count)
        {
            CreaditLimit -= count;
            Console.WriteLine($"{count} credits were debited from the card");
        }
        private void Limit(double count)
        {
            if (MoneyCount + CreaditLimit < count)
            {
                Console.WriteLine("The cost is too high");
            }
        }
        public void ChangePIN()
        {
            Console.Write("Enter old PIN: ");
            int oldpin;
            Int32.TryParse(Console.ReadLine(), out oldpin);
            while (oldpin != PIN)
            {
                Console.Write("Enter old PIN: ");
                Int32.TryParse(Console.ReadLine(), out oldpin);
            }
            Console.Write("Enter new PIN: ");
            int newpin;
            Int32.TryParse(Console.ReadLine(), out newpin);
            PIN = newpin;
        }
        public override string ToString()
        {
            return $"Name: {pip.FirstName} {pip.LastName}, Father's Name: {pip.FatherName}\n" +
                   $"Card Valid: {CardValid.ToShortDateString()}\n" +
                   $"Credit Limit: {CreaditLimit}\n" +
                   $"Money Count: {MoneyCount}";
        }
    }
}
