using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ttem2.Models;
using ttem2.Models.CauThuModels;

namespace ttem2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CauThuAPIController : ControllerBase
    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();


        [HttpGet("{matrandau}")]

        public IEnumerable<CauThuTheoMaTD> GetCauThuTheoMaTD(string matrandau)
        {
            var lstMaCauThuTranDau = db.TrandauCauthus.AsNoTracking()
               .Where(x => x.TranDauId == matrandau)
               .Select(x => x.CauThuId)
               .ToList();

            var cauthus = (from p in db.Cauthus
                             where lstMaCauThuTranDau.Contains(p.CauThuId)
                             select new CauThuTheoMaTD
                             {
                                 HoVaTen = p.HoVaTen,
                                 Anh = p.Anh,
                                 ViTri = p.ViTri,
                                 QuocTich= p.QuocTich,
                                 SoAo= p.SoAo,
                                 Ngaysinh= p.Ngaysinh,
                                 CauThuId= p.CauThuId
                             }).ToList();

            return cauthus;

        }
    }
}
