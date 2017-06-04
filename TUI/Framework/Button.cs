using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Framework
{
	public class Button: Control
	{
		public string Text { get; set; }

		public Button(string text)
		{
			BackColor = ConsoleColor.Gray;
			Text = text;

			Size = new Size(text.Length + 4, 3);

			Controls.Add(new Frame());
			Controls.Add(new Label(Text) { Position = new Position(2, 1)});
		}
	}
}
