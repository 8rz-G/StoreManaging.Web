using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StoreManaging.Web.Models.Entities
{
	public class Products
	{
		[Key]
		public int ProductCode { get; set; }
		public string Name { get; set; }
		public int Category { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}