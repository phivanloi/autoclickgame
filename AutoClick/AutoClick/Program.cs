using System.Runtime.InteropServices;
using System.Text;

[DllImport("user32.dll")]
static extern bool GetCursorPos(out POINT lpPoint);

[DllImport("user32.dll")]
static extern bool SetCursorPos(int X, int Y);

[DllImport("user32.dll", SetLastError = true)]
static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
const uint MOUSEEVENTF_LEFTUP = 0x0004;

Console.OutputEncoding = Encoding.UTF8;
while (true)
{
    // Lấy vị trí hiện tại của con trỏ chuột
    GetCursorPos(out POINT oldPos);

    // Nhấn chuột trái
    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);

    Thread.Sleep(100); // Đợi một chút

    // Di chuyển chuột lên trên 300 px
    SetCursorPos(oldPos.X, oldPos.Y - 250);

    // Nhấn chuột trái
    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);

    Thread.Sleep(100); // Đợi một chút

    // Di chuyển sang bên phải 50 px
    SetCursorPos(oldPos.X + 80, oldPos.Y - 30);

    // Nhấn chuột trái
    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);

    Thread.Sleep(100); // Đợi một chút

    // Di chuyển chuột về vị trí cũ
    SetCursorPos(oldPos.X, oldPos.Y);

    Thread.Sleep(5000); // Lặp lại sau 5 giây
}

[StructLayout(LayoutKind.Sequential)]
struct POINT
{
    public int X;
    public int Y;
}