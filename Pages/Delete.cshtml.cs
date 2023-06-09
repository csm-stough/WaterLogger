using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Models;

namespace WaterLogger.Pages
{
    public class DeleteModel : PageModel
    {
        private IConfiguration _configuration;
        [BindProperty]
        public DrinkingWaterModel DrinkingWater { get; set; }
        private WaterLoggerContext waterLoggerContext { get; set; }

        public DeleteModel(IConfiguration configuration)
        {
            _configuration = configuration;
            waterLoggerContext = new WaterLoggerContext(configuration);
        }

        public IActionResult OnGet(int Id)
        {
            DrinkingWater = waterLoggerContext.Find<DrinkingWaterModel>(Id);

            return Page();
        }

        public IActionResult OnPost(int Id)
        {
            waterLoggerContext.Remove(DrinkingWater);
            waterLoggerContext.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
