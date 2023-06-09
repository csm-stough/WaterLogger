using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Models;

namespace WaterLogger.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IConfiguration _configuration;
        [BindProperty]
        public DrinkingWaterModel DrinkingWater { get; set; }
        private WaterLoggerContext waterLoggerContext;

        public CreateModel(IConfiguration configuration)
        {
            _configuration = configuration;
            waterLoggerContext = new WaterLoggerContext(configuration);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            waterLoggerContext.Add(new DrinkingWaterModel()
            {
                Date = DrinkingWater.Date,
                Quantity = DrinkingWater.Quantity,
            });

            waterLoggerContext.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
