using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Framework
{
	public class Dropdown: Textbox
	{
		public override void Paint(DrawContext context)
		{
			base.Paint(context);

			context.SetCursorPosition(Position.X + Size.Width - 1, Position.Y);

			context.Write('▼');
		}
	}
}
