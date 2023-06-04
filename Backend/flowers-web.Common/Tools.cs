using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Common
{
    public class Tools
    {
        public static string CreateValidateString(){
            string chars = "abcdefghijklmnopqrstuvwxyz";
            Random r = new(DateTime.Now.Millisecond);
            string vaildateString = string.Empty;
            int length = 4;
            for (int i = 0; i < length; i++)
            {
                vaildateString += chars[r.Next(chars.Length)];
            }
            return vaildateString;
        }

        public static Byte[] CreateValidateCodeBuffer(string validateCode) {
            // 创建画布
            using Bitmap bitmap = new(200,60);
            // 画笔
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            Font font = new("微软雅黑", 12, FontStyle.Bold | FontStyle.Italic);

            var size = graphics.MeasureString(validateCode, font);

            using Bitmap bitmapText = new(Convert.ToInt32(Math.Ceiling(size.Width)), Convert.ToInt32(Math.Ceiling(size.Height)));
            // 文字嵌入 生成图片
            Graphics graphicsText = Graphics.FromImage(bitmapText);

            // 将图片缩放到原画布上
            RectangleF rf = new(0, 0, bitmap.Width, bitmap.Height);
            LinearGradientBrush brush = new(rf, Color.Red, Color.DarkBlue, 1.2f, true);

            // 将字符绘制到场景上
            graphicsText.DrawString(validateCode, font, brush, 0, 0);
            graphics.DrawImage(bitmapText, 10, 10, 190, 50);

            // 将图片放到缓冲区中
            MemoryStream memoryStream = new();
            bitmap.Save(memoryStream, ImageFormat.Jpeg);

            // 图片在缓冲区后 dispose 掉 bitmap
            return memoryStream.ToArray();
        }
    }
}
