using System;
using System.Data;
using System.Diagnostics;

namespace TUI
{
	public class Window : Control
	{
		private Label TitleLabel;

		public Label CloseButton;

		public Window(string title)
		{
			Title = title;
			BackColor = ConsoleColor.Gray;
			ForeColor = ConsoleColor.White;
			Background = ' ';
			Controls.Add(new Frame());
			Controls.Add(TitleLabel = new Label(Title)
			{
				Position = new Position(3, 0),
				BackColor = ConsoleColor.Blue,
				ForeColor = ConsoleColor.White
			});

			Controls.Add(CloseButton = new Label("x")
			{
				BackColor = ConsoleColor.Blue,
				ForeColor = ConsoleColor.White,
			});

			SizeChanged += Window_SizeChanged;
		}

		private void Window_SizeChanged()
		{
			CloseButton.Position = new Position(Size.Width - 4, 0);
		}

		public string Title { get; set; }

		public override void Paint(DrawContext context)
		{
			base.Paint(context);


			context.SetCursorPosition(1, 0);
			context.Write('┤');

			context.SetCursorPosition(Size.Width - 2, 0);
			context.Write('├');

			context.SetColor(ConsoleColor.Blue, ConsoleColor.White);
			for (int col = 2; col < Size.Width - 2; col++)
			{
				context.SetCursorPosition(col, 0);
				context.Write(' ');
			}

			context.SetCursorPosition(Size.Width - 8, 0);
			context.Write('-');

			context.SetCursorPosition(Size.Width - 6, 0);
			context.Write('↕');

			TitleLabel.Paint(context);
			CloseButton.Paint(context);
			for (int col = 1; col <= Size.Width; col++)
			{
				context.SetCursorPosition(col, Size.Height);
				context.Dark();
			}

			for (int row = 1; row <= Size.Height; row++)
			{
				context.SetCursorPosition(Size.Width, row);
				context.Dark();
			}
		}
	}
}