using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankSystem.Services.Models
{
    public class Account
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public decimal balance { get; set; }
    }
}