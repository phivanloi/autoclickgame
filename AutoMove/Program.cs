using System.Runtime.InteropServices;
using System.Text;

[DllImport("user32.dll")]
static extern bool GetCursorPos(out POINT lpPoint);

[DllImport("user32.dll")]
static extern bool SetCursorPos(int X, int Y);

[DllImport("user32.dll")]
static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

const int MOUSEEVENTF_LEFTDOWN = 0x02;
const int MOUSEEVENTF_LEFTUP = 0x04;
const int MOUSEEVENTF_MOVE = 0x0001;

Console.OutputEncoding = Encoding.UTF8;
Thread.Sleep(2000);
while (true)
{
    // Nhấn chuột tại ví trí hiện tại, Nút bắt đầu game, người dùng sẽ đặt sẵn vào nút bắt đầu game
    GetCursorPos(out POINT oldPos);

    int steps = 5;
    for (int i = 1; i <= steps; i++)
    {
        DragMouse(100, 0);
        SetCursorPos(oldPos.X, oldPos.Y);
        Thread.Sleep(200);
    }

    for (int i = 1; i <= steps; i++)
    {
        DragMouse(0, 100);
        SetCursorPos(oldPos.X, oldPos.Y);
        Thread.Sleep(200);
    }

    SetCursorPos(oldPos.X, oldPos.Y);
    Thread.Sleep(5000);
}

static void DragMouse(int endX, int endY)
{
    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
    Thread.Sleep(1000);
    mouse_event(MOUSEEVENTF_MOVE, (uint)endX, (uint)endY, 0, UIntPtr.Zero);
    Thread.Sleep(1000);
    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
}

[StructLayout(LayoutKind.Sequential)]
struct POINT
{
    public int X;
    public int Y;
}