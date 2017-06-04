using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Framework
{
	public class Textbox: Control
	{
		public string Text { get; set; }

		public Textbox()
		{
			BackColor = ConsoleColor.White;
			ForeColor = ConsoleColor.Black;
		}

		public override void Paint(DrawContext context)
		{
			base.Paint(context);

			context.SetCursorPosition(Position.X, Position.Y);

			context.Write(Text);
		}
	}
}
