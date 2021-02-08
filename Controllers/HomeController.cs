using Microsoft.AspNetCore.Mvc;
using qrcode.Utils;

namespace qrcode.Controllers
{
  public class HomeController : Controller
  {
    private readonly QrCodeGenerator _qrcode;
    public HomeController(QrCodeGenerator qrcode)
    {
      _qrcode = qrcode;
    }

    [HttpGet("qrcode")]
    public IActionResult GetQrCode()
    {
      var image = _qrcode.GenerateByteArray("https://google.com");
      return File(image, "image/jpeg");
    }
  }
}
