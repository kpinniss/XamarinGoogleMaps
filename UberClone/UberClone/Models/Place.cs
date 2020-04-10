using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace UberClone.Models
{
    public class Place
    {
        public Position Position { get; set; }
        public string Address { get; set; }
        public string PlaceName { get; set; }
    }
}
