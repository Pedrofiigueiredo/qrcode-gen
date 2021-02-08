using System.Drawing;
using System.IO;
using QRCoder;

namespace qrcode.Utils
{
  public class QrCodeGenerator
  {
    public Bitmap GenerateImage(string url)
    {
      QRCodeGenerator qrGenerator = new QRCodeGenerator();
      QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
      QRCode qrCode = new QRCode(qrCodeData);
      Bitmap qrCodeImage = qrCode.GetGraphic(20);
      return qrCodeImage;
    }

    public byte[] GenerateByteArray(string url)
    {
      var image = GenerateImage(url);
      return ImageToByte(image);
    }

    private byte[] ImageToByte(Image img)
    {
      using var stream = new MemoryStream();
      img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
      return stream.ToArray();
    }
  }
}