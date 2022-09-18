using ExpensesControlApp.DTOs;
using ExpensesControlApp.Models;
using ExpensesControlApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpensesControlApp.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ILogger<ExpenseController> _logger;
        private readonly IExpenseService _expenseService;

        public ExpenseController(ILogger<ExpenseController> logger, IExpenseService expenseService)
        {
            _logger = logger;
            _expenseService = expenseService;
        }

        public async Task<IActionResult> Index()
        {
            var listExpenseDTO = new ListExpenseDTO();
            listExpenseDTO.Items = await _expenseService.FindBy(listExpenseDTO.InitialDate, listExpenseDTO.FinalDate);

            return View(listExpenseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ListExpenseDTO listExpenseDTO)
        {
            try
            {
                listExpenseDTO.Items = await _expenseService.FindBy(listExpenseDTO.InitialDate, listExpenseDTO.FinalDate);

                return View(listExpenseDTO);
            }
            catch (Exception e)
            {

                ModelState.AddModelError("CustomError", e.Message);
                return View(listExpenseDTO);
            }
        }

        public async Task<IActionResult> Create()
        {
            var createExpenseDTO = new CreateExpenseDTO();

            return View(createExpenseDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateExpenseDTO createExpenseDTO)
        {
            try
            {
                await _expenseService.Create(createExpenseDTO);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError("CustomError", e.Message);
                return View(createExpenseDTO);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}