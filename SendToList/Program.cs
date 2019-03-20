using System;
using System.Windows.Forms;

namespace SendToList
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			// Просто инициализируем этот чёртов синглтон пока не поздно.
			MessageCache.Instance();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
