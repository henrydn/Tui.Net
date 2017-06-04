using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Framework
{
	public class MouseEvent
	{
		public Position Position = new Position();

		public bool IsHandled = false;
		public int ButtonState { get; set; }

		public MouseEvent Clone()
		{
			return new MouseEvent
			{
				IsHandled = IsHandled,
				ButtonState = ButtonState,
				Position = Position.Clone()
			};
		}
	}
}
