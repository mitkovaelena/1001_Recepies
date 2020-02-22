using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _1001Rezepti.Models;

namespace _1001Rezepti.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Любимите рецепти на малки и големи"; 
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "1001 рецепти е кулинарен сайт с много рецепти, статии и полезни приложения, акцентиращ върху здравословното хранене и начин на живот. Като наследник на списанието „1001 рецепти” продължава успешно да ангажира аудиторията онлайн от 2010 година насам. Насочен е към женската аудитория на възраст между 25 и 55 години и е единственият български кулинарен сайт, който предлага изпитани рецепти, приготвени, заснети и дегустирани от екипа. Сред отличаващите го функции са хранителният калкулатор, с който се изчисляват калории, белтъчини, мазнини и въглехидрати на всяко ястие, подробната информация за хранителния състав на всяка рецепта и възможността за въвеждане и съхраняване на рецепти в лично пространство. Сайтът предлага и статии, свързани не само с кулинарията и здравословния начин на живот, а и с теми, вълнуващи потребителската група – козметика, грижа за детето, диети, мода, цветя и градина, известни личности.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
