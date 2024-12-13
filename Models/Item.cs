using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string? name { get; set; } 

        public double price { get; set; }

        public int? SerialNumberID { get; set; }
        public SerialNumber? SerialNumber { get; set;}

        public int? CatogeryId { get; set; }
        [ForeignKey("CatogeryId")]
        public Catogery? Catogery { get; set; }


        public List<ItemClient> ItemClients { get; set; }

    }
}