using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models
{
    public class Tariff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string CityCode { get; set; } // Уникальный код города
        [Required]
        public string CityName { get; set; } // Название города
        [Required]
        public decimal CostPerMinute { get; set; } // Стоимость за минуту разговора
    }
}