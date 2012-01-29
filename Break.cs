using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Take5
{
	public class Break
	{
		public static readonly Break Current = new Break();

		private Break()
		{
			breakTimer.Elapsed += (_, __) => TakeABreak();
			closeTimer.Elapsed += (_, __) => TheBreakIsOver();
		}
		private Timer breakTimer = new Timer { Interval = 55 * 60 * 1000, Enabled = true };
		private Timer closeTimer = new Timer { Interval = 5 * 60 * 1000, Enabled = false };

		private List<Overlay> currentOverlays;

		public void TakeABreak()
		{
			breakTimer.Enabled = false;
			currentOverlays = Screen.AllScreens.Select(screen => new Overlay(screen)).ToList();
			currentOverlays.Each(overlay => overlay.Closing += (_, __) => TheBreakIsOver());
			currentOverlays.Each(overlay => overlay.Show());
			closeTimer.Enabled = true;
		}

		public void TheBreakIsOver()
		{
			closeTimer.Enabled = false;
			currentOverlays.Each(overlay => overlay.Close());
			currentOverlays.Clear();
			breakTimer.Enabled = true;
		}
	}
}