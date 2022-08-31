using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeekseatWitchSaga.Models
{
    public class VillagerData
    {
        public int ID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
        [Display(Name = "Age of Death")]
        public int iAge { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
        [Display(Name = "Year of Death")]
        public int iYear { get; set; }
    }

    public interface IVillager
    {
        decimal GetAverageNumberOfKilledVillager();
    }
}
