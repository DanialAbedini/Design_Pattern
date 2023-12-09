using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Design_Pattern.Model;

namespace Design_Pattern.Patterns
{
    public interface IInventory
    {
        void Update(Product product);
        bool IsAvailable(int count);
    }
    public interface IPayment
    {
        bool Charge(double amount);
    }
    public interface ISend
    {
        bool Send(string address);
    }

    public class Inventory : IInventory
    {
        public bool IsAvailable(int count)
        {
            if (count >= 1)
                return true;
            return false;
        }

        public void Update(Product product)
        {
            product.Quantity--;
        }
    }

    class Payment : IPayment
    {
        public bool Charge(double amount)
        {
            System.Console.WriteLine($"{amount}$ Payed!");
            return true;
        }
    }

    class Ship : ISend
    {
        public bool Send(string address)
        {
            System.Console.WriteLine($"Has Been Sent By {address} Address");
            return true;
        }
    }

    class OrderFacade
    {
        private bool success;
        private IInventory _inventory;
        private IPayment _payment;
        private ISend _send;
        public OrderFacade()
        {
            success = false;
            _inventory = new Inventory();
            _payment = new Payment();
            _send = new Ship();
        }

        public bool Success
        {
            get
            {
                return success;
            }
        }

        public void PlaceOrder(Product product, double amount, string address)
        {
            if (_inventory.IsAvailable(product.Quantity))
            {
                _inventory.Update(product);
                _payment.Charge(amount);
                _send.Send(address);
                success = true;
            }
            else
            {
                System.Console.WriteLine("Can't Buy");
                success = false;
            }
        }
    }


}