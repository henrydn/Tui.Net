using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Framework;

namespace TUI
{
	public class CustomerForm: Form
	{
		public CustomerForm()
		{
			Size = new Size(78, 21);

			var window = new Window("Customer Information")
			{
				Position = new Position(0, 0),
				Size = Size,
			};

			Dragged += position =>
			{
				Trace.WriteLine("TitleWasDragged");
				Position = Position - position;
			};

			window.Controls.Add(GeneralGroup = new Group("General") { Position = new Position(1, 2), Size = new Size(38, 15) });
			window.Controls.Add(AddressGroup = new Group("Address") { Position = new Position(39, 2), Size = new Size(38, 15) });

			GeneralGroup.Controls.Add(new Label("First Name:") { Position = new Position(2, 2) });
			GeneralGroup.Controls.Add(new Label("Last Name:") { Position = new Position(2, 4) });
			GeneralGroup.Controls.Add(new Label("Mobile:") { Position = new Position(2, 6) });
			GeneralGroup.Controls.Add(new Label("Email:") { Position = new Position(2, 8) });
			GeneralGroup.Controls.Add(new Label("ID Number:") { Position = new Position(2, 10) });
			GeneralGroup.Controls.Add(new Label("MaritalStat:") { Position = new Position(2, 12) });

			GeneralGroup.Controls.Add(new Textbox() { Position = new Position(15, 2), Size = new Size(20, 1), Text = "Harvey" });
			GeneralGroup.Controls.Add(new Textbox() { Position = new Position(15, 4), Size = new Size(20, 1), Text = "Marshall" });
			GeneralGroup.Controls.Add(new Textbox() { Position = new Position(15, 6), Size = new Size(20, 1), Text = "07058919779" });
			GeneralGroup.Controls.Add(new Textbox() { Position = new Position(15, 8), Size = new Size(20, 1), Text = "harvey@constoso.com" });
			GeneralGroup.Controls.Add(new Textbox() { Position = new Position(15, 10), Size = new Size(20, 1), Text = "98879456322" });
			GeneralGroup.Controls.Add(new Dropdown() { Position = new Position(15, 12), Size = new Size(20, 1), Text = "Maried" });

			AddressGroup.Controls.Add(new Label("Line 1:") { Position = new Position(2, 2) });
			AddressGroup.Controls.Add(new Label("Line 2:") { Position = new Position(2, 4) });
			AddressGroup.Controls.Add(new Label("Suburb:") { Position = new Position(2, 6) });
			AddressGroup.Controls.Add(new Label("City:") { Position = new Position(2, 8) });
			AddressGroup.Controls.Add(new Label("Code:") { Position = new Position(2, 10) });

			AddressGroup.Controls.Add(new Textbox() { Position = new Position(15, 2), Size = new Size(20, 1), Text = "Flat 11B" });
			AddressGroup.Controls.Add(new Textbox() { Position = new Position(15, 4), Size = new Size(20, 1), Text = "23 Leicester Road" });
			AddressGroup.Controls.Add(new Textbox() { Position = new Position(15, 6), Size = new Size(20, 1), Text = "" });
			AddressGroup.Controls.Add(new Textbox() { Position = new Position(15, 8), Size = new Size(20, 1), Text = "AYLESHAM" });
			AddressGroup.Controls.Add(new Textbox() { Position = new Position(15, 10), Size = new Size(20, 1), Text = "CT3 7ZQ" });

			window.Controls.Add(SaveButton = new Button("Save") { Position = new Position(1, 17) });
			window.Controls.Add(PolicyDetailsButton = new Button("View Policies") { Position = new Position(9, 17) });

			PolicyDetailsButton.Click += @event =>
			{
				var policyDetails = new PolicyDetails { Position = new Position(20, 4) };

				policyDetails.Show();
			}; 

			Controls.Add(window);
		}

		public Button PolicyDetailsButton { get; set; }

		public Button SaveButton { get; set; }

		public Group AddressGroup { get; set; }


		public Group GeneralGroup { get; set; }
	}
}
