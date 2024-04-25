using System;
using System.Runtime.InteropServices;
using System.Threading;


public static class MessageBoxExample
{
    // MessageBox 함수를 가져오기 위한 준비
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);


    static void ShowMessageBox(object state)
    {
        Tuple<string,string> message = (Tuple<string,string>)state;
        MessageBox(IntPtr.Zero, message.Item1, message.Item2, 0);
    }

    public static void windowError(string text, string caption)
    {
        MessageBox(IntPtr.Zero, text, caption, (uint)0x00000030L);
        // // 메시지 박스 정보를 담은 튜플 생성
        // Tuple<string, string> msg1 = new Tuple<string, string>(text, caption);
        // Tuple<string, string> msg2 = new Tuple<string, string>(text, caption);
        // Tuple<string, string> msg3 = new Tuple<string, string>(text, caption);

        // // 쓰레드 생성 및 시작
        // new Thread(ShowMessageBox).Start(msg1);
        // new Thread(ShowMessageBox).Start(msg2);
        // new Thread(ShowMessageBox).Start(msg3);
    }

}