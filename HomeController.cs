using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalculatorWebsite.Models;

namespace CalculatorWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SquareRoot()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Squareroot(string firstNumber, string secondNumber)
        {
            ViewBag.Result = SqrtMethod(firstNumber, secondNumber);
             return View();
        }  
       private static String SqrtMethod(string firstNum, string secondNum)
       {
           int firstNumber;
           int secondNumber;
           string display = string.Empty;
           bool firstconvertednumber = int.TryParse(firstNum, out firstNumber);
           bool secondconvertednumber= int.TryParse(secondNum, out secondNumber);


           if (firstNum == "" || secondNum == "")
           {
               display = "Please input a value";
           }

           else if (firstconvertednumber && secondconvertednumber)
           {
               if(firstNumber < 0 || secondNumber < 0)
               {
                   display = "Error! Your input was invalid,it is a negative number";
               }
               else
               {
                  double Sqr1 = Math.Sqrt(firstNumber);
                  double Sqr2 = Math.Sqrt(secondNumber);

                  if (Sqr1 > Sqr2)
                  {
                      display = "The number " + firstNumber + " with squareroot " + Sqr1 + " has a higher square root number";
                  }
                  else if (Sqr1 < Sqr2)
                  {
                      display = "The number " + secondNumber + " with squareroot " + Sqr2 + " has a higher square root number";
                  }
                  else if (Sqr1 == Sqr2)
                  {
                      display = "The values entered have equal squareroots. You can enter another value";
                  }
               }
           }
           else
           {
               display = "Error! Please enter a valid number";
           }

           return display;
       }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
