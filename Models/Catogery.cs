using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class Catogery
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Item>? Items { get; set; }
    }
}