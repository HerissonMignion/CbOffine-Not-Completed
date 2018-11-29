using System;
using System.Windows.Forms;
using System.Drawing;
using PageEngine;


namespace CbOffice
{
	static class Program
	{
		public static void wdebug(object text) { System.Diagnostics.Debug.WriteLine(text); }

		public static PForm MainForm;


		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(true);

			PForm mf = new PForm();
			Program.MainForm = mf;

			//MainForm
			mf.Title = "CB Office";
			mf.Size = new Size(950, 600); // 800 , 600

			//page de depart
			pageMain StartPage = new pageMain();
			mf.Navigate(StartPage);

			


			mf.ShowDialog();

		}


	}
	
	static class module
	{

		public static Size GetTextSize(string text, Font font)
		{
			Size rep = new Size(1, 1);
			using (Bitmap img = new Bitmap(10, 10))
			{
				using (Graphics g = Graphics.FromImage(img))
				{
					rep = module.GetTextSize(text, font, g);
				}
			}
			return rep;
		}
		public static Size GetTextSize(string text, Font font, Graphics g)
		{
			Size rep = new Size(1, 1);
			rep.Width = (int)(g.MeasureString(text, font).Width);
			rep.Height = (int)(g.MeasureString("IMKUNJYHBTRCFWEDqtyplkjhgfdb", font).Height);
			return rep;
		}

		public static Point GetCenteredTextPos(string text, Font font, Graphics g, Point center)
		{
			Size textsize = module.GetTextSize(text, font, g);
			Point rep = new Point(0, 0);
			rep.X = center.X - (textsize.Width / 2);
			rep.Y = center.Y - (textsize.Height / 2);
			return rep;
		}
		public static Point GetCenteredTextPos(string text, Font font, Point center)
		{
			Size textsize = module.GetTextSize(text, font);
			Point rep = new Point(0, 0);
			rep.X = center.X - (textsize.Width / 2);
			rep.Y = center.Y - (textsize.Height / 2);
			return rep;
		}
		public static Point GetCenteredTextPos(string text, Font font, Graphics g, Rectangle rec)
		{
			Size textsize = module.GetTextSize(text, font, g);
			Point rep = new Point(0, 0);
			rep.X = rec.X + (rec.Width / 2) - (textsize.Width / 2);
			rep.Y = rec.Y + (rec.Height / 2) - (textsize.Height / 2);
			return rep;
		}
		public static Point GetCenteredTextPos(string text, Font font, Rectangle rec)
		{
			Size textsize = module.GetTextSize(text, font);
			Point rep = new Point(0, 0);
			rep.X = rec.X + (rec.Width / 2) - (textsize.Width / 2);
			rep.Y = rec.Y + (rec.Height / 2) - (textsize.Height / 2);
			return rep;
		}




	}
}