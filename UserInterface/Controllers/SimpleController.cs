using Microsoft.AspNetCore.Mvc;
using UserInterface.ViewData;
using UserInterface.ViewModels;

namespace UserInterface.Controllers
{
    public class SimpleController : Controller
    {
        private readonly ILogger<SimpleController> _logger;

        public SimpleController(ILogger<SimpleController> logger)
        {
            _logger = logger;
        }

        // Display page (GET)
        public IActionResult Display()
        {
            var model = SimpleMemory.CurrentItem;
            // Read TempData message 
            if (TempData.TryGetValue("SuccessMessage", out var msgObj))
            {
                var msg = msgObj as string;
                if (!string.IsNullOrEmpty(msg) && msg == "Success")
                {
                    // confirm message and log to debug 
                    _logger.LogDebug("PRG success message verified: {Message}", msg);
                    ViewBag.SuccessMessage = "Operation completed successfully.";
                }
            }

            return View("~/Views/SimpleItem/Display.cshtml", model); // views/SimpleItem/Display.cshtml
        }

        // Create - GET
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new SimpleViewModel();
            return View("~/Views/SimpleItem/Create.cshtml", vm); // views/SimpleItem/Create.cshtml
        }

        // Create - POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SimpleViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                // return view with validation errors 
                return View(vm);
            }

            // assign Id and save to in-memory store
            vm.Id = 1;
            SimpleMemory.CurrentItem = vm;

            // set TempData message and redirect (PRG)
            TempData["SuccessMessage"] = "Success";
            return RedirectToAction("Display");
        }

        // Edit - GET
        [HttpGet]
        public IActionResult Edit()
        {
            var current = SimpleMemory.CurrentItem;
            if (current == null)
            {
                // nothing to edit - redirect to create
                return RedirectToAction(nameof(Create));
            }
            return View("~/Views/SimpleItem/Edit.cshtml", current); // views/SimpleItem/Edit.cshtml
        }

        // Edit - POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SimpleViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            // update store
            SimpleMemory.CurrentItem = vm;

            // PRG success message
            TempData["Success Message"] = "Success";
            return RedirectToAction(nameof(Display));
           
        }
    }
}
