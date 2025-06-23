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
Thread.Sleep(1000);

// Nhấn chuột tại ví trí hiện tại, Nút bắt đầu game, người dùng sẽ đặt sẵn vào nút bắt đầu game
GetCursorPos(out POINT oldPos);
var i = 1;
while (true)
{
    ClickLeftMouse();
    Thread.Sleep(100);

    // Chọn kỹ năng 3
    SetCursorPos(oldPos.X + 150, oldPos.Y - 300);
    ClickLeftMouse();
    Thread.Sleep(100);

    // Chọn kỹ năng 2
    SetCursorPos(oldPos.X, oldPos.Y - 300);
    ClickLeftMouse();
    Thread.Sleep(100);

    // Chọn kỹ năng 1
    SetCursorPos(oldPos.X - 150, oldPos.Y - 300);
    ClickLeftMouse();
    Thread.Sleep(100);

    // Nhấn nút xác nhận
    SetCursorPos(oldPos.X, oldPos.Y - 120);
    ClickLeftMouse();
    Thread.Sleep(500);

    // Nhấn nút chọn quái 1
    SetCursorPos(oldPos.X + 80, oldPos.Y - 110);
    ClickLeftMouse();
    Thread.Sleep(500);

    // Nhấn nút chọn quái 2
    SetCursorPos(oldPos.X, oldPos.Y - 110);
    ClickLeftMouse();
    Thread.Sleep(500);

    // Nhấn nút chọn quái 3
    SetCursorPos(oldPos.X - 80, oldPos.Y - 110);
    ClickLeftMouse();
    Thread.Sleep(500);

    // Nhấn nút chọn quái 4
    SetCursorPos(oldPos.X - 155, oldPos.Y - 110);
    ClickLeftMouse();
    Thread.Sleep(500);

    // Nhấn nút thoát game
    SetCursorPos(oldPos.X + 150, oldPos.Y + 40);
    ClickLeftMouse();
    Thread.Sleep(100);

    // Nhất nút bắt đầu game mới hoặc tìm trận
    SetCursorPos(oldPos.X, oldPos.Y + 100);
    ClickLeftMouse();
    Thread.Sleep(100);

    // Di chuyển chuột về vị trí cũ
    SetCursorPos(oldPos.X, oldPos.Y);

    Thread.Sleep(3000);
    Console.WriteLine("Chay lần thứ {0}.", i++);
}

static void ClickLeftMouse()
{
    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
}

[StructLayout(LayoutKind.Sequential)]
struct POINT
{
    public int X;
    public int Y;
}