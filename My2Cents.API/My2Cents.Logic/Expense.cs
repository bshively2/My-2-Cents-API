using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.Logic
{
    public class Expense
    {
            public string? name { get; set; }
            public int? account { get; set; }
            public string? itemName { get; set; }
            public decimal? price { get; set; }
            public string? detail { get; set; }
            public string? date { get; set; }

       
        public Expense(string name, int account, string itemName, decimal price, string detail, string date)
        {
            
            this.name = name;
            this.account = account;
            this.itemName = itemName;
            this.price = price;
            this.detail = detail;
            this.date = date;
        }
    }
}
