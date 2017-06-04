using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Framework;

namespace TUI
{
	public class PolicyDetails: Form
	{
		public PolicyDetails()
		{
			Size = new Size(40, 18);

			var window = new Window("Policy Details")
			{
				Position = new Position(0, 0),
				Size = Size,
			};

			window.CloseButton.Click += e => Close();

			//window.Controls.Add(GeneralGroup = new Group("General") { Position = new Position(1, 2), Size = new Size(38, 16) });
			//window.Controls.Add(AddressGroup = new Group("Address") { Position = new Position(39, 2), Size = new Size(38, 16) });

			window.Controls.Add(new Label("Policy No:") { Position = new Position(2, 5) });
			window.Controls.Add(new Label("Product:") { Position = new Position(2, 7) });
			window.Controls.Add(new Label("Commenced:") { Position = new Position(2, 9) });
			window.Controls.Add(new Label("Status:") { Position = new Position(2, 11) });
			window.Controls.Add(new Label("Payment By:") { Position = new Position(2, 13) });
			window.Controls.Add(new Label("Premium:") { Position = new Position(2, 15) });

			window.Controls.Add(new Textbox() { Position = new Position(15, 5), Size = new Size(20, 1), Text = "PL000001" });
			window.Controls.Add(new Textbox() { Position = new Position(15, 7), Size = new Size(20, 1), Text = "Term Life 5" });
			window.Controls.Add(new Textbox() { Position = new Position(15, 9), Size = new Size(20, 1), Text = "12/09/2016" });
			window.Controls.Add(new Dropdown() { Position = new Position(15, 11), Size = new Size(20, 1), Text = "Awaiting Collection" });
			window.Controls.Add(new Dropdown() { Position = new Position(15, 13), Size = new Size(20, 1), Text = "Debit Order" });
			window.Controls.Add(new Textbox() { Position = new Position(15, 15), Size = new Size(20, 1), Text = "$ 198.12" });

			window.Controls.Add(new Button("PL000001") { Position = new Position(2, 1) });
			window.Controls.Add(new Button("PL000002") { Position = new Position(14, 1) });

			Controls.Add(window);
		}
	}
}
