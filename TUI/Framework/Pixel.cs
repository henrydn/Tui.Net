using System;

namespace TUI
{
	public struct Pixel
	{
		public char Character { get; set; }

		public ConsoleColor ForeColor { get; set; }

		public ConsoleColor BackColor { get; set; }

		public override bool Equals(object obj)
		{
			var other = (Pixel)obj;

			return Character == other.Character
			       && ForeColor == other.ForeColor
			       && BackColor == other.BackColor;
		}
	}
}