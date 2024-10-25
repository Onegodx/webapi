using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models
{
    public class CallRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string OwnerName { get; set; } // ФИО владельца
        [Required]
        public string CityCode { get; set; } // Код города
        [Required]
        public string CityName { get; set; } // Название города
        [Required]
        public int DurationInMinutes { get; set; } // Продолжительность разговора
        public decimal TotalCost { get; set; } // Общая стоимость разговора
    }
}