using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces;
using Infrastructure.Services;
using UserInterface.Models;

namespace UserInterface.Controllers
{
    [Route("calculator")]
    public class CalculatorController : Controller
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(new CalculationResult());
        }

        [HttpPost("")]
        public IActionResult Index(CalculationResult model)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(model.Operation))
            {
                try
                {
                    switch (model.Operation)
                    {
                        case "Add":
                            model.Result = _calculator.Add(model.A, model.B).ToString();
                            break;
                        case "Subtract":
                            model.Result = _calculator.Subtract(model.A, model.B).ToString();
                            break;
                        case "Multiply":
                            model.Result = _calculator.Multiply(model.A, model.B).ToString();
                            break;
                        case "Divide":
                            model.Result = _calculator.Divide(model.A, model.B).ToString();
                            break;
                        default:
                            model.Result = "Invalid operation";
                            break;
                    }
                }
                catch (DivideByZeroException ex)
                {
                    model.Result = ex.Message;
                }
            }

            return View(model);
        }
    }
}

