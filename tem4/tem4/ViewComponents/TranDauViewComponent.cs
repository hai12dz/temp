using Microsoft.AspNetCore.Mvc;
using tem4.Models;

namespace ttem2.ViewComponents
{
    public class TranDauViewComponent : ViewComponent
    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();

        public TranDauViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

          var  trandaus = db.Trandaus.Take(7).ToList();

            return View("TranDau", trandaus);
        }

    }
}