using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models.Value
{
    public class Money
    {
        public decimal Amount { get; set; }
        public Money(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount cannot be negative.");
            }
            Amount = amount;
        }
        public Currency Currency { get; set; } = Currency.EUR;

        public override string ToString()
        {
            return $" {Amount} {Currency}";
        }

    }


}