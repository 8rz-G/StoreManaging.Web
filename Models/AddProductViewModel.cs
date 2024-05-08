using Microsoft.AspNetCore.Mvc.Rendering;
using StoreManaging.Web.Models.Entities;

namespace StoreManaging.Web.Models
{
    public class AddProductViewModel
    {
        public string Name { get; set; }
        public int Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
