using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Take5
{
	public class Program : ApplicationContext
	{
		[STAThread]
		public static void Main()
		{
			using (var program = new Program())
			{
				Application.Run(program);
			}
		}

		public Program()
		{
			components = new Container();
			new NotifyIcon(components)
			{
				Text = "Take5",
				Icon = new Icon("Main.ico"),
				ContextMenu = new ContextMenu(new[] { 
					new MenuItem("&Preview", (_,__) => Break.Current.TakeABreak()),
					new MenuItem("E&xit", (_,__) => Application.Exit())
				}),
				Visible = true,
			};
		}

		protected override void Dispose(bool disposing)
		{
			if(disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private readonly Container components;
	}
}
