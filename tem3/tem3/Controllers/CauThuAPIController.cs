using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tem3.Models;
using tem3.Models.CauThuModels;

namespace tem3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CauThuAPIController : ControllerBase
    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();

        [HttpGet("{tenSVD}")]
        public IEnumerable<CauThuTheoSVD> GetCauThuTheoMa(string tenSVD)
        {
            var lstIdSVDTheoTenSan = db.Sanvandongs.AsNoTracking()
                .Where(x => x.TenSan==tenSVD)
                .Select(x => x.SanVanDongId)
                .ToList();

            var lstIdCLBTheoIdSVD = db.Caulacbos.AsNoTracking()
                .Where(p => lstIdSVDTheoTenSan.Contains(p.SanVanDongId))
                .Select(p => p.CauLacBoId)  // Giả sử TranDauId là thuộc tính của TrandauCauthus
                .Distinct()
                .ToList();


            var cauthus = db.Cauthus.AsNoTracking()
       .Where(x => lstIdCLBTheoIdSVD.Contains(x.CauLacBoId))
       .Select(x => new CauThuTheoSVD
       {
           CauThuId=x.CauThuId,
           HoVaTen=x.HoVaTen,
           CauLacBoId=x.CauLacBoId,
           Ngaysinh=x.Ngaysinh,
           ViTri = x.ViTri,
           QuocTich=x.QuocTich,
           SoAo=x.SoAo,
           Anh=x.Anh
           
       })
       .ToList();

         


            return cauthus;
        }

    }
}
