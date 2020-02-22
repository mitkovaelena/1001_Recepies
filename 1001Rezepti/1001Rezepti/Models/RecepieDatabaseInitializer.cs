using System.Collections.Generic;
using System.Linq;

namespace _1001Rezepti.Models
{
    public class RecepieDatabaseInitializer
    {
        public static void Seed(RecepieContext context)
        {
          /*  if (!context.Categories.Any())
            {
                GetCategories().ForEach(c => context.Categories.Add(c));
                context.SaveChanges();
            } */
            if (!context.Products.Any())
            {
                GetProducts().ForEach(p => context.Products.Add(p));
                context.SaveChanges();
            }
            if (!context.Recepies.Any())
            {
                GetRecepies().ForEach(r => context.Recepies.Add(r));
                context.SaveChanges();
            }
            if (!context.RecProds.Any())
            {
                GetRecProds().ForEach(r => context.RecProds.Add(r));
                context.SaveChanges();
            }
        }
      /*  private static List<Category> GetCategories()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    CategoryID = 1, CategoryName = "Закуска"
                },
                new Category
                {
                    CategoryID = 2, CategoryName = "Обед" },
                new Category
                {
                    CategoryID = 3, CategoryName = "Вечеря"
                },
            };
            return categories;
        } */

        private static List<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Сирене",
                },
               new Product
                {
                    ProductID = 2,
                    ProductName = "Олио",
                },new Product
                {
                    ProductID = 3,
                    ProductName = "Яйца",
                },new Product
                {
                    ProductID = 4,
                    ProductName = "Кори",
                },new Product
                {
                    ProductID = 5,
                    ProductName = "Кисело Мляко",
                },new Product
                {
                    ProductID = 6,
                    ProductName = "Шоколад",
                },new Product
                {
                    ProductID = 7,
                    ProductName = "Захар",
                },
            };
            return products;
        }
        private static List<Recepie> GetRecepies()
        {
            var recepies = new List<Recepie>
            {
                new Recepie
                {
                    RecepieID = 1,
                    RecepieName = "Баница",
                    Description = "Първата стъпка от рецептата за баница със сирене и готови кори е подготовката на плънката. Разбърквате яйцата (предварително извадени от хладилника), киселото мляко, изварата / сиренето, ½ чаена чаша олио и содата за хляб. Може да ползвате и извара. Ако сте ползва извара добавете и около една равна чаена лъжица сол. Разбъркайте продуктите добре до получаване на хомогенна смес." +
                                    "В намазнена тавичка сложeте 1-2 листа от корите, върху които сложете около един черпак (за супа) от сместа. След което поръсете с няколко капки от останалото олио. Отгоре отново сложете лист-два от корите и отново от сместа, а накрая олио. Повтаряйте процедурата в тази последователност докато корите и сместа свършат."+
                                    "Последният лист от корите намажете с олио и много внимателно нарежете с остър нож на парчета, за да можете след изпичане на по-лесно да разрежете баницата на парчета. Печете баницата в предварително загрята на 200 градуса фурна за около 30 минути, докато баницата придобие златист цвят."+
                                    "След като извадите баницата от фурната покрийте с памучна кърпа докато поизстине.",
                    ImagePath ="images/b1.jpg",
                    TimeToCook = 50,
                },
                
            };
            return recepies;
        }
        private static List<RecProd> GetRecProds()
        {

            var recprods = new List<RecProd>{
            new RecProd{RecepieId=1, ProductId=1, Quantity=500},
            new RecProd{RecepieId=1, ProductId=2, Quantity=100},
            new RecProd{RecepieId=1, ProductId=3, Quantity=200},
            new RecProd{RecepieId=1, ProductId=4, Quantity=300},
            new RecProd{RecepieId=1, ProductId=5, Quantity=100}
            };                                  
            return recprods;
        }
       
    }
}