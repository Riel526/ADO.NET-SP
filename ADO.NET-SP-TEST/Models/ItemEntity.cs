using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDSolutionsExam.Models
{
    public class ItemEntity
    {

        [Key]
        public int Id { get; set; }

        [DisplayName("Recycable Type Id")]
        public int RecycableTypeId { get; set; }

        public decimal Weight { get; set; }

        [DisplayName("Computed Weight")]
        public decimal ComputedWeight { get; set; }


        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }

    }
}