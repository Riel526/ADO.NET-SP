using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDSolutionsExam.Models
{
    public class TypeEntity
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        public decimal Rate { get; set; }

        [DisplayName("Minumum Kg")]
        public decimal MinKg { get; set; }

        [DisplayName("Maximum Kg")]
        public decimal MaxKg { get; set; }
    }
}