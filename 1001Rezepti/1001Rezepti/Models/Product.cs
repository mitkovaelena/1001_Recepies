using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _1001Rezepti.Models
{
    public class Product 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Въведете номер на продукта."),
            Display(Name = "Номер")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Въведете името на продукта."),
            StringLength(100), Display(Name = "Име")]
        public string ProductName { get; set; }

        [Display(Name = "Рецепти")]
        public virtual ICollection<RecProd> Recepies { get; set; }

    }
}