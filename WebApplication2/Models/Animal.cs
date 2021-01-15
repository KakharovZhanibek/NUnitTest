using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table("Animal")]
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}