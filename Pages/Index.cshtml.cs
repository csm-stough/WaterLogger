using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Models;

namespace WaterLogger.Pages
{
    public class IndexModel : PageModel
    {
        public readonly IConfiguration configuration;
        public List<DrinkingWaterModel> Records { get; set; }
        private WaterLoggerContext waterLoggerContext;

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
            waterLoggerContext = new WaterLoggerContext(configuration);
        }

        public void OnGet()
        {
            Records = GetAllRecords();
            ViewData["Total"] = Records.AsEnumerable().Sum(record => record.Quantity);
        }

        private List<DrinkingWaterModel> GetAllRecords()
        {
            return waterLoggerContext.Records.OrderBy(record => record.Date).ToList();
        }
    }
}