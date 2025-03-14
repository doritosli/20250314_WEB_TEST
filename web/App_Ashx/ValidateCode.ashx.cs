using System;
using System.Web;
using System.Drawing;
using System.Web.SessionState;

namespace GWDB.App_Ashx
{
    public class ValidateCode : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            CreateCheckCodeImage(GenerateCheckCode(context), context);
        }

        private string GenerateCheckCode(HttpContext context)
        {
            int numberA;
            int numberB;
            int numberC;
            string CheckShow = "";
            string CheckValue = "";
            System.Random random = new Random();
            numberA = random.Next(1, 10); numberB = random.Next(1, 10);
            if (numberB > numberA) { numberC = numberA; numberA = numberB; numberB = numberC; }
            numberC = random.Next(2);

            switch (numberC)
            {
                case 0: CheckShow += numberA.ToString() + "+" + numberB.ToString(); CheckValue = (numberA + numberB).ToString(); context.Session["CheckText"] = numberA.ToString() + " + " + numberB.ToString(); break;
                case 1: CheckShow += numberA.ToString() + "+" + numberB.ToString(); CheckValue = (numberA + numberB).ToString(); context.Session["CheckText"] = numberA.ToString() + " + " + numberB.ToString(); break;
            }

            //儲存在session

            context.Session["CheckCode"] = CheckValue;
            return CheckShow;
        }

        private void CreateCheckCodeImage(string checkCode, HttpContext context)
        {
            if (checkCode == null || checkCode.Trim() == String.Empty) { return; }

            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 23.0)), 44);
            Graphics g = Graphics.FromImage(image);

            try
            {
                //背景色
                g.Clear(Color.White);
                Font font = new System.Drawing.Font("Arial", 24, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Black, Color.Black, 1.2f, true);
                g.DrawString(checkCode, font, brush, 2, 2);

                //圖片邊框
                g.DrawRectangle(new Pen(Color.Black), 0, 0, image.Width - 1, image.Height - 1);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                context.Response.ClearContent();
                context.Response.ContentType = "image/Gif";
                context.Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}