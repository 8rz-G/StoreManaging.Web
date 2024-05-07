using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManaging.Web.Models.Entities
{
	public class Products
	{
		[Key]
		public int ProductCode { get; set; }
		public string Name { get; set; }
		[ForeignKey("CategoryId")]
		[ValidateNever]
		public int Category { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}