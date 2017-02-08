using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestGAP.Models
{
    public class Article
    {
        public Article()
        {
           
        }
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        public String name { get; set; }
        [Display(Name = "Description")]
        public String description { get; set; }
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal price { get; set; }
        [Display(Name = "Total in Shelf")]
        public int total_in_shelf { get; set; }
        [Display(Name = "Total in Vault")]
        public int total_in_vault { get; set; }
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}