using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageEngine
{
	public interface iPage
	{

		void Initialize(PForm MyPParent); //est caller lors de PForm.Navigate()
		void Start(); //indique que la session doit commencer, ou reprendre si elle avait ete suspendu/mis en pause
		void Pause(); //indique que la session est mis en pause/suspendu
		void Destroy(); //indique que la page doit etre detruite parce que la session ne va jamais reprendre




	}
}
