using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Models;

namespace WaterLogger.Pages
{
    public class UpdateModel : PageModel
    {
        private IConfiguration _configuration;
        [BindProperty]
        public DrinkingWaterModel DrinkingWater { get; set; }
        private WaterLoggerContext waterLoggerContext;

        public UpdateModel(IConfiguration configuration)
        {
            _configuration = configuration;
            waterLoggerContext = new WaterLoggerContext(configuration);
        }

        public IActionResult OnGet(int Id)
        {
            DrinkingWater = waterLoggerContext.Find<DrinkingWaterModel>(Id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            waterLoggerContext.Update(DrinkingWater);
            waterLoggerContext.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
