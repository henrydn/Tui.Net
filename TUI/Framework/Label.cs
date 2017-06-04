using System;
using System.Linq;

namespace TUI
{
	public class Label : Control
	{
		private string Title;

		public Label(string title)
		{
			Title = title;

			Background = ' ';
			BackColor = ConsoleColor.Gray;
			ForeColor = ConsoleColor.Black;
			Size = new Size(title.Length, 1);
		}

		public override void Paint(DrawContext context)
		{
			base.Paint(context);

			context.SetCursorPosition(Position.X, Position.Y);

			context.Write(Title);
		}
	}
}