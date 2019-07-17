using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiHome.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Card Card { get; set; }
    }
}