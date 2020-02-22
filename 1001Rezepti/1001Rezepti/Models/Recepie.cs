using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _1001Rezepti.Models
{
    public class Recepie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Въведете номер на рецептата."),
            Display(Name = "Номер")]
       // [Unique(ErrorMessage = "Този номер вече съществува")]
        public int RecepieID { get; set; }

        [Required(ErrorMessage = "Въведете името на рецептата."),
            StringLength(100, ErrorMessage = "Максималната дължина на името е 100 символа."), Display(Name = "Име")]
        public string RecepieName { get; set; }

        [Required(ErrorMessage = "Въведете описание"), 
            StringLength(10000, ErrorMessage = "Максималната дължина на името е 10000 символа."), Display(Name = "Рецепта"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Снимка")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Въведете време на приготвяне."),
            Display(Name = "Време на приготвяне")]
        public int TimeToCook { get; set; }

        [Display(Name = "Продукти")]
        public virtual ICollection<RecProd> Products { get; set; }

        /*   [Required(ErrorMessage = "Категорията е задължителна"), Display(Name = "Категория")]
           public int CategoryID { get; set; }

           public virtual Category Category { get; set; } */
        public virtual string DescriptionShort
        {
            get { return Description != null ? (Description.Length >= 300 ? Description.Substring(0, 300) : Description) : ""; }
        }

    }
}