using System;
using Microsoft.VisualBasic;

namespace ExenoApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
