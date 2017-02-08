using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestGAP.Models
{
    public class Store
    {
        public Store()
        {
            this.Article = new List<Article>();
        }
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        public String name { get; set; }
        [Display(Name = "Address")]
        [Required]
        public String address { get; set; }

        public virtual ICollection<Article> Article { get; set; }
    }
}