using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TUI.Framework;

namespace TUI
{
	class Program
	{
		static void Main(string[] args)
		{

			DrawContext context = new DrawContext();

			Application app = new Application();

			Console.CursorVisible = false;
			app.Controls.Add(new CustomerForm() { Position = new Position(1, 2)});

			while (true)
			{
				app.Paint(context);
				app.CheckInput(context);
				context.SwopBuffers();
				app.DoInvokeActions();

				Thread.Sleep(1);
			}
		}
	}
}
