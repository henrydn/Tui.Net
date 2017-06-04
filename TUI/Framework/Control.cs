using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TUI.Framework;

namespace TUI
{
	public delegate void Click(MouseEvent @event);

	public delegate void PositionChanged(Position position);

	public delegate void Event();

	public abstract class Control
	{
		public event Click Click;
		public event Click Release;
		public event PositionChanged Dragged;

		public event Event SizeChanged;
		private bool _isMouseDown = false;

		private MouseEvent previousMouseEvent = new MouseEvent()
		{
			Position = new Position(0, 0)
		};

		protected Control()
		{
			Position = new Position();
			Size = new Size();

			Controls = new List<Control>();
			ForeColor = ConsoleColor.White;

			Dragged += position => { Trace.WriteLine("Dragged"); };
		}

		public void Hide()
		{
			Hidden = true;
		}

		public bool Hidden { get; set; }

		private Position _position;
		private Size _size;

		public Position Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position = value;
			}
		}

		public ConsoleColor BackColor { get; set; }
		public ConsoleColor ForeColor { get; set; }

		public Size Size
		{
			get { return _size; }
			set
			{
				_size = value; 
				SizeChanged?.Invoke();
			}
		}

		public char Background { get; set; }

		public virtual void Paint(DrawContext context)
		{
			if (Hidden)
			{
				return;
			}

			context.SetColor(BackColor, ForeColor);
			context.ControlStack.Insert(0, this);
			DrawBackground(context);

			foreach (var control in Controls)
			{
				control.Paint(context);
				
			}
			context.ControlStack.RemoveAt(0);
		}

		public List<Control> Controls { get; set; } 

		public void MouseEvent(MouseEvent @event)
		{
			@event.Position.X -= Position.X;
			@event.Position.Y -= Position.Y;

			foreach (var Control in Controls)
			{
				Control.MouseEvent(@event);
				if (@event.IsHandled) break;
			}

			if (@event.IsHandled) return;

			if (@event.Position.X >= 0 && @event.Position.Y >= 0 && @event.Position.X < Size.Width &&
			    @event.Position.Y < Size.Height)
			{
				if (@event.ButtonState > 0 && previousMouseEvent.ButtonState == 0)
				{
					_isMouseDown = true;
					Click?.Invoke(@event);
				}
				else if (@event.ButtonState == 0 && previousMouseEvent.ButtonState == 1)
				{
					_isMouseDown = false;
					Release?.Invoke(@event);
				}

				//if (_isMouseDown && !@event.Position.Equals(previousMouseEvent.Position))
				//{
				//	Dragged?.Invoke(previousMouseEvent.Position - @event.Position);
				//}

				previousMouseEvent = @event.Clone();
			}

			@event.Position.X += Position.X;
			@event.Position.Y += Position.Y;
		}

		private void DrawBackground(DrawContext context)
		{
			for (int col = 0; col < Size.Width; col++)
			{
				for (int row = 0; row < Size.Height; row++)
				{
					context.SetCursorPosition(col, row);
					context.Write(Background);
				}
			}
		}
	}
}
