using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace My2Cents.DataInfrastructure.Models
{
    public class ExpenseDto
    {

        [Required]
        public string? Name { get; set; }

        [Required]
        public int? Account { get; set; }    

        [Required]
        public string? ItemName { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public string? Detail { get; set; }

        [Required]
        public string?  Date { get; set; }


    }
}
