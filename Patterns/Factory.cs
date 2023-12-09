using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Design_Pattern.pattern
{
    public interface IPayment
    {
        void Pay();
        void Name();
    }
    public enum BankSelect { Saman = 1, Melat, Sepah };
    //! Bank Saman
    class Saman : IPayment
    {
        public void Name()
        {
            Console.WriteLine($"Name of Bank: {typeof(Saman).Name}");
        }

        public void Pay()
        {
            Console.WriteLine("Payment by Saman");
        }
    }
    //! Bank Melat
    class Melat : IPayment
    {
        public void Name()
        {
            Console.WriteLine($"Name of Bank: {typeof(Melat).Name}");
        }

        public void Pay()
        {
            Console.WriteLine("Payment by Melat");
        }
    }
    //! Bank Sepah
    class Sepah : IPayment
    {
        public void Name()
        {
            Console.WriteLine($"Name of Bank: {typeof(Sepah).Name}");
        }

        public void Pay()
        {
            Console.WriteLine("Payment by Sepah");
        }
    }
    //!Banks Class
    public class PaymentFactory
    {
        public IPayment payment(BankSelect bankSelect)
        {
            switch (bankSelect)
            {
                case BankSelect.Saman:
                    return new Saman();
                case BankSelect.Melat:
                    return new Melat();
                case BankSelect.Sepah:
                    return new Sepah();
                default:
                    throw new ArgumentException("Not Valid");
            }
        }
    }
}