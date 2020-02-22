using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1001Rezepti.Models
{
    public class RecProd
    {
        [Key]
        [ForeignKey("Recepie")]
        [Column(Order = 1)]
        [Display(Name ="Номер на рецептата")]
        public int RecepieId { get; set; }

        [Key]
        [ForeignKey("Product")]
        [Column(Order = 2)]
        [Display(Name = "Номер на продукта")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Въведете количество.")]
       [Display(Name = "Количество")]
       public int Quantity { get; set; }

        public virtual Recepie Recepie { get; set; }
        public virtual Product Product { get; set; }

    }
}
