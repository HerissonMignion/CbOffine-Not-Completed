using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CbOffice.PowerPoint.SlideControl;

namespace CbOffice.PowerPoint
{
	public class oSlideDrawer
	{

		
		public Bitmap GetImage(oSlide s, int suiHeight)
		{
			int suiWidth = (int)(s.Rap * (float)suiHeight + 0.5f);

			Bitmap img = new Bitmap(suiWidth, suiHeight);
			Graphics g = Graphics.FromImage(img);
			g.Clear(s.BackColor);


			foreach (oSlideControl sc in s.listControl)
			{
				if (sc.TheType == scType.Label)
				{
					scLabel l = (scLabel)sc;

					int uix = (int)(l.Left * (float)suiWidth + 0.5f);
					int uiy = (int)(l.Top * (float)suiHeight + 0.5f);
					int uiwidth = (int)(l.Width * (float)suiWidth + 0.5f);
					int uiheight = (int)(l.Height * (float)suiHeight + 0.5f);

					//test
					g.DrawRectangle(Pens.Blue, uix, uiy, uiwidth - 1, uiheight - 1);



				}

			}


			//end
			g.Dispose();
			return img;
		}

		//cette function retourne une image de moindre qualité de la slide.
		public Bitmap GetThumbnailImage(oSlide s, int suiHeight)
		{
			int suiWidth = (int)(s.Rap * (float)suiHeight + 0.5f);

			Bitmap img = new Bitmap(suiWidth, suiHeight);
			Graphics g = Graphics.FromImage(img);
			g.Clear(s.BackColor);


			foreach (oSlideControl sc in s.listControl)
			{
				if (sc.TheType == scType.Label)
				{
					scLabel l = (scLabel)sc;

					int uix = (int)(l.Left * (float)suiWidth + 0.5f);
					int uiy = (int)(l.Top * (float)suiHeight + 0.5f);
					int uiwidth = (int)(l.Width * (float)suiWidth + 0.5f);
					int uiheight = (int)(l.Height * (float)suiHeight + 0.5f);

					//une zone de texte ne remplit pas tout son rectangle, alors il fait la moyenne des couleur de l'arriere plan avec celle du texte
					Color bc = s.BackColor;
					Color fc = l.ForeColor;
					Color FillColor = Color.FromArgb((bc.R + fc.R) / 2, (bc.G + fc.G) / 2, (bc.B + fc.B) / 2);

					//remplit la zone
					g.FillRectangle(new SolidBrush(FillColor), uix, uiy, uiwidth - 1, uiheight - 1);



				}

			}


			//end
			g.Dispose();
			return img;
		}






	}
}
