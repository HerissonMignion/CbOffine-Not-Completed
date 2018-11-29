using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CbOffice.PowerPoint.Resource
{

	public enum ResourceType
	{
		none,
		Image
	}


	public abstract class oResource
	{

		public string name = "noname";

		protected ResourceType zzzTheType = ResourceType.none;
		public ResourceType TheType { get { return this.zzzTheType; } }
		

	}
}
