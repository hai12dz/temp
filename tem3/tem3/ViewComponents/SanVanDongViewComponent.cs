using Microsoft.AspNetCore.Mvc;
using tem3.Models;

namespace ttem2.ViewComponents
{
    public class SanVanDongViewComponent : ViewComponent
    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();

        public SanVanDongViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

          var  sanvandongs = db.Sanvandongs.Take(7).ToList();

            return View("SanVanDong", sanvandongs);
        }

    }
}