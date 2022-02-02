using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace My2Cents.DataInfrastructure.Models
{
    public class IncomeDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public int? Account { get; set; }

        [Required]
        public decimal? Amount { get; set; }
    
    }
}
