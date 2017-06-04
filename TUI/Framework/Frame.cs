using System;
using System.Linq;

namespace TUI
{
	public class Frame : Control
	{
		public const string STYLE1 = "═║╔╗╚╝";
		public const string STYLE2 = "─│┌┐└┘";

		public string Style { get; set; } = STYLE2;

		public Frame()
		{
			 ForeColor = ConsoleColor.Black;
			 BackColor = ConsoleColor.Gray;
		}

		public override void Paint(DrawContext context)
		{
			base.Paint(context);

			var parent = context.ControlStack.First();

			for (int col = 0; col < parent.Size.Width; col++)
			{
				context.SetCursorPosition(col, 0);
				context.Write(Style[0]);
			}

			for (int col = 0; col < parent.Size.Width; col++)
			{
				context.SetCursorPosition(col, 0 + parent.Size.Height - 1);
				context.Write(Style[0]);
			}

			for (int row = 0; row < parent.Size.Height; row++)
			{
				context.SetCursorPosition(parent.Size.Width - 1, row);
				context.Write(Style[1]);
			}

			for (int row = 0; row < parent.Size.Height; row++)
			{
				context.SetCursorPosition(0, row);
				context.Write(Style[1]);
			}

			context.SetCursorPosition(0, 0);
			context.Write(Style[2]);

			context.SetCursorPosition(parent.Size.Width - 1, 0);
			context.Write(Style[3]);

			context.SetCursorPosition(0, parent.Size.Height - 1);
			context.Write(Style[4]);

			context.SetCursorPosition( + parent.Size.Width - 1, 0 + parent.Size.Height - 1);
			context.Write(Style[5]);
		}
	}
}