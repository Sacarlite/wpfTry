using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace wpfTry.Model.Entities
{
    public class Product
    {
        public Product(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public ProductType Type { get; set; } = null!;
        public string Color { get; set; }
        public string Discription { get; set; }
        public string HeatResistance { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double length { get; set; }
        public double volume { get; set; }
        public string manufacturer { get; set; }
        public string Image { get; set; }
        public List<Specifications> Specifications { get; set; } = null!;
    }
}
