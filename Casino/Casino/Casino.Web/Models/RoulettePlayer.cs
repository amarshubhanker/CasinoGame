using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casino.Web.Models
{
    public class RoulettePlayer
    {
        public int CustomerId { get; set; }
        public decimal AccountBalance { get; set; }
        public decimal BlockedAmount { get; set; }
        public decimal WinAmount { get; set; }
        public decimal BetAmount { get; set; }
    }
}