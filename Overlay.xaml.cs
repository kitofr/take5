using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace Take5
{
	public partial class Overlay : Window
	{
		private readonly Screen screen;
		public bool IsClosing = false;

		public Overlay(Screen screen)
		{
			this.screen = screen;
			InitializeComponent();
			Left = screen.Bounds.Left;
			Top = screen.Bounds.Top;
			Width = screen.Bounds.Width;
			Height = screen.Bounds.Height;
		}

		public new void Close()
		{
			if(IsClosing) return;
			IsClosing = true;
			base.Close();
		}

		public double ScaleX { get { return screen.Bounds.Width / Width; } }
		public double ScaleY { get { return screen.Bounds.Height / Height; } }
		
		private void Window_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
				Close();
		}
	}
}
