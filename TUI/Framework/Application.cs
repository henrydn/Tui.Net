using System;
using System.Collections.Generic;
using System.ComponentModel;
using TUI.Framework;

namespace TUI
{
	public class Application : Control
	{
		public List<Action> InvokeActions = new List<Action>();
		private static NativeMethods.ConsoleHandle eventHandle;

		public static Application Instance { get; set; }

		public Application()
		{
			Instance = this;

			BackColor = ConsoleColor.Cyan;
			ForeColor = ConsoleColor.Cyan;
			Background = '▒';

			Size = new Size(Console.WindowWidth, Console.WindowHeight - 1);

			Controls.Add(new Label("  Policies  Customers  Documents  Payments  Setup                       Logoff  "));

			InitialiseMouse();
		}

		private static void InitialiseMouse()
		{
			eventHandle = NativeMethods.GetStdHandle(NativeMethods.STD_INPUT_HANDLE);

			int mode = 0;
			if (!(NativeMethods.GetConsoleMode(eventHandle, ref mode)))
			{
				throw new Win32Exception();
			}

			mode |= NativeMethods.ENABLE_MOUSE_INPUT;
			mode &= ~NativeMethods.ENABLE_QUICK_EDIT_MODE;
			mode |= NativeMethods.ENABLE_EXTENDED_FLAGS;

			if (!(NativeMethods.SetConsoleMode(eventHandle, mode)))
			{
				throw new Win32Exception();
			}
		}

		public void Invoke(Action action)
		{
			InvokeActions.Add(action);
		}

		public void DoInvokeActions()
		{
			foreach (var invokeAction in InvokeActions)
			{
				invokeAction.Invoke();
			}

			InvokeActions.Clear();
		}

		public override void Paint(DrawContext context)
		{
			base.Paint(context);

		}

		public void CheckInput(DrawContext context)
		{
			var record = new NativeMethods.INPUT_RECORD();
			uint recordLen = 0;
			if (!(NativeMethods.ReadConsoleInput(eventHandle, ref record, 1, ref recordLen))) { throw new Win32Exception(); }
			switch (record.EventType)
			{
				case NativeMethods.MOUSE_EVENT:
					//do something
					context.SetCursorPosition(record.MouseEvent.dwMousePosition.X, record.MouseEvent.dwMousePosition.Y);

					MouseEvent(new MouseEvent()
					{
						Position = new Position(record.MouseEvent.dwMousePosition.X, record.MouseEvent.dwMousePosition.Y),
						ButtonState = record.MouseEvent.dwButtonState,
					});

					context.Invert();
					break;
				case NativeMethods.KEY_EVENT:
					if (record.KeyEvent.wVirtualKeyCode == (int)ConsoleKey.Escape) { return; }
					break;
			}
		}
	}
}