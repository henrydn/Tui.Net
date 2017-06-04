using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Framework
{
	public class Form: Control
	{
		public void Show()
		{
			Application.Instance.Invoke(() =>
			{
				Application.Instance.Controls.Add(this);
			});
		}

		public void Close()
		{
			Application.Instance.Invoke(() =>
			{
				Application.Instance.Controls.Remove(this);
			});
		}
	}
}
