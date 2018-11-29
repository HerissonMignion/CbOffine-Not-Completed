using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CbOffice.PowerPoint.SlideControl;

namespace CbOffice.PowerPoint
{

	//toute les information ~non-importante d'edition / action d'edition de l'utilisateur dont il n'est pas "logique" qu'elles soient dans oPowerPointProject sont ici.
	//cette object permet la communication entre tout les élément qui servent à éditer le project.

	public class oEditContext
	{
		private oPowerPointProject zzzTheProject;
		public oPowerPointProject TheProject { get { return this.zzzTheProject; } }





		public int UserEditingSlide = 0; //index de la slide en cour d'édition
		public void SetEditingSlide(int newslide)
		{
			if (this.ActualEditState == EditState.Adding)
			{
				this.CancelAddMode();
			}

			this.UserEditingSlide = newslide;
			this.Raise_EditingSlideChanged();
			//Program.wdebug("Editing Slide Changed : " + this.UserEditingSlide);
		}
		public event EventHandler EditingSlideChanged;
		private void Raise_EditingSlideChanged()
		{
			if (this.EditingSlideChanged != null)
			{
				this.EditingSlideChanged(this, new EventArgs());
			}
		}

		

		//void new()
		public oEditContext(oPowerPointProject StartProject)
		{
			this.zzzTheProject = StartProject;


		}






		public enum EditState
		{
			none,
			Adding,
			//Editing
		}
		private EditState zzzActualEditState = EditState.none;
		public EditState ActualEditState
		{
			get { return this.zzzActualEditState; }
		}
		public event EventHandler EditStateChanged;
		private void Raise_EditStateChanged()
		{
			if (this.EditStateChanged != null)
			{
				this.EditStateChanged(this, new EventArgs());
			}
		}

		public oSlideControl addmodeNewSC = null; //during add mode, c'est le control à ajouter

		public void SetToAddMode(oSlideControl newsc)
		{
			this.addmodeNewSC = newsc;

			this.zzzActualEditState = EditState.Adding;
			this.Raise_EditStateChanged();
		}
		public void CancelAddMode()
		{
			if (this.ActualEditState == EditState.Adding)
			{
				this.addmodeNewSC = null;
				this.zzzActualEditState = EditState.none;
				this.Raise_EditStateChanged();
			}
		}
		public void FinishAddMode()
		{
			//meme chose que CancelAddMode
			if (this.ActualEditState == EditState.Adding)
			{
				this.addmodeNewSC = null;
				this.zzzActualEditState = EditState.none;
				this.Raise_EditStateChanged();
			}
		}






	}
}
