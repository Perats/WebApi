using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiHome.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public int OwnerId { get; set; }
        public decimal CardBalance { get; set; }
    }
}