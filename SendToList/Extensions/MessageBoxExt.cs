using System.Threading;
using System.Windows.Forms;

namespace SendToList.Extensions
{
	public static class MessageBoxExt
	{
		public static void ShowInNewThread(string text, string title = "")
		{
			new Thread(() => MessageBox.Show(text)).Start();
		}
	}
}
