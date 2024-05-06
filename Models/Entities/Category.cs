using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManaging.Web.Models.Entities
{
    public class Category
    {
        [Key]
		public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
