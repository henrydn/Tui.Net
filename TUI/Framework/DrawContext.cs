using System;
using System.Collections.Generic;

namespace TUI
{
	public class DrawContext
	{
		private Pixel[,] drawBuffer;
		private Pixel[,] screenBuffer;

		private Position cursor;
		public List<Control> ControlStack;

		public ConsoleColor ForeColor;
		public ConsoleColor BackColor;

		public DrawContext()
		{
			drawBuffer = new Pixel[Console.WindowWidth, Console.WindowHeight];
			screenBuffer = new Pixel[Console.WindowWidth, Console.WindowHeight];
			ControlStack = new List<Control>();

			BackColor = ConsoleColor.Black;
			ForeColor = ConsoleColor.White;
		}

		public Position GetAbsolutePosition()
		{
			var position = new Position();

			foreach (var control in ControlStack)
			{
				position.Y += control.Position.Y;
				position.X += control.Position.X;
			}

			return position;
		}


		public void SetCursorPosition(int x, int y)
		{
			cursor = new Position(x + GetAbsolutePosition().X, y + GetAbsolutePosition().Y);
		}

		public void Write(char charater)
		{
			try
			{
				drawBuffer[cursor.X, cursor.Y] = new Pixel
				{Character = charater, BackColor = BackColor, ForeColor = ForeColor};
			}
			catch (IndexOutOfRangeException)
			{
			}
			
		}

		public void SwopBuffers()
		{
			for (int col = 0; col < drawBuffer.GetLength(0); col++)
			{
				for (int row = 0; row < drawBuffer.GetLength(1); row++)
				{
					if (!drawBuffer[col, row].Equals(screenBuffer[col, row]))
					{
						screenBuffer[col, row] = drawBuffer[col, row];

						System.Console.ForegroundColor = drawBuffer[col, row].ForeColor;
						System.Console.BackgroundColor = drawBuffer[col, row].BackColor;
						System.Console.SetCursorPosition(col, row);
						System.Console.Write(drawBuffer[col, row].Character);
					}
				}
			}
		}

		internal void Write(string title)
		{
			foreach (var c in title)
			{
				Write(c);
				cursor.X ++;
			}
		}

		public void SetColor(ConsoleColor backColor, ConsoleColor foreColor)
		{
			ForeColor = foreColor;
			BackColor = backColor;
		}

		public ConsoleColor[] InvertedColors = new[]
		{
			ConsoleColor.White,
			ConsoleColor.Yellow,
			ConsoleColor.Magenta,
			ConsoleColor.Red,
			ConsoleColor.Cyan,
			ConsoleColor.Green,
			ConsoleColor.Blue,
			ConsoleColor.DarkGray,
			ConsoleColor.Gray,
			ConsoleColor.DarkYellow,
			ConsoleColor.DarkMagenta,
			ConsoleColor.DarkRed,
			ConsoleColor.DarkCyan,
			ConsoleColor.DarkGreen,
			ConsoleColor.DarkBlue,
			ConsoleColor.Black,
		};

		public void Invert()
		{
			drawBuffer[cursor.X, cursor.Y].BackColor = InvertedColors[(int)drawBuffer[cursor.X, cursor.Y].BackColor];
			drawBuffer[cursor.X, cursor.Y].ForeColor = InvertedColors[(int)drawBuffer[cursor.X, cursor.Y].ForeColor];
		}

		public void Dark()
		{
			try
			{
				drawBuffer[cursor.X, cursor.Y].BackColor = ConsoleColor.DarkGray;
				drawBuffer[cursor.X, cursor.Y].ForeColor = ConsoleColor.Black;
			}
			catch (IndexOutOfRangeException)
			{
			}
		}
	}
}