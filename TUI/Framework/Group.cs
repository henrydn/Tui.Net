using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Framework
{
	public class Group: Control
	{
		private string Title { get; set; }

		public Group(string Title)
		{
			Title = Title;

			BackColor = ConsoleColor.Gray;
			ForeColor = ConsoleColor.White;
			Background = ' ';
			Controls.Add(new Frame());
			//Controls.Add(TitleLabel = new Label(Title)
			//{
			//	Position = new Position(3, 0),

			//});
		}

		public Label TitleLabel { get; set; }
	}
}
