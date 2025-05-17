using System.Runtime.InteropServices;
using System.Text;

[DllImport("user32.dll", SetLastError = true)]
static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);
bool isRunning = true;

const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
const uint MOUSEEVENTF_LEFTUP = 0x0004;
ManualResetEventSlim exitEvent = new();

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Auto-Clicker đã khởi động (nhấn \"s\" dừng, \"r\" chạy tiếp, Ctrl+C thoát).");

await Task.Run(ClickLoop);

while (!exitEvent.IsSet)
{
    var key = Console.ReadKey(true).Key;

    switch (key)
    {
        case ConsoleKey.S:
            isRunning = false;
            Console.WriteLine("[Tạm dừng]");
            break;

        case ConsoleKey.R:
            isRunning = true;
            Console.WriteLine("[Tiếp tục]");
            break;
    }
}


/// <summary>
/// Vòng lặp tự động click.  
/// Nếu đang chạy → click rồi ngủ 5 s.  
/// Nếu tạm dừng  → chỉ ngủ ngắn để phản hồi nhanh khi được bật lại.
/// </summary>
void ClickLoop()
{
    Console.CancelKeyPress += (sender, e) =>
    {
        e.Cancel = true;
        exitEvent.Set();
    };

    while (!exitEvent.IsSet)
    {
        if (isRunning)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
            Thread.Sleep(5000);
        }
        else
        {
            Thread.Sleep(100);
        }
    }
}