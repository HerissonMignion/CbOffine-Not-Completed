using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CbOffice.PowerPoint.Resource
{
	public class rImage : oResource
	{

		public Bitmap Image = null;

		//void new()
		public rImage(Bitmap StartImage)
		{
			this.zzzTheType = ResourceType.Image;
			this.Image = StartImage;
		}

	}
}
