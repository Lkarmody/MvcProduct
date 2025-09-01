using Microsoft.AspNetCore.Mvc;
using MvcProduct.Models;
using MvcProduct.Services.Interfaces;

namespace MvcProduct.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public IActionResult Add(int a, int b)
        {
            var model = new CalculationResult
            {
                A = a,
                B = b,
                Operation = "Add",
                Result = _calculator.Add(a, b).ToString()
            };
            return View("Result", model);
        }

        public IActionResult Subtract(int a, int b)
        {
            var model = new CalculationResult
            {
                A = a,
                B = b,
                Operation = "Subtract",
                Result = _calculator.Subtract(a, b).ToString()
            };
            return View("Result", model);
        }

        public IActionResult Multiply(int a, int b)
        {
            var model = new CalculationResult
            {
                A = a,
                B = b,
                Operation = "Multiply",
                Result = _calculator.Multiply(a, b).ToString()
            };
            return View("Result", model);
        }

        public IActionResult Divide(int a, int b)
        {
            var model = new CalculationResult
            {
                A = a,
                B = b,
                Operation = "Divide"
            };

            try
            {
                model.Result = _calculator.Divide(a, b).ToString("0.##");
            }
            catch (DivideByZeroException)
            {
                model.Result = "Error: Cannot divide by zero.";
            }

            return View("Result", model);
        }
    }
}

