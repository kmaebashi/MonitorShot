using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace MonitorShot
{
    delegate void KeyHookCallback();

    static class KeyHook
    {
        delegate int delegateHookCallback(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SetWindowsHookEx(int idHook, delegateHookCallback lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        private static IntPtr hookPtr = IntPtr.Zero;
        private static Keys captureKey;
        private static KeyHookCallback keyHookCallback;

        public static void StartHook(Keys key, KeyHookCallback callback)
        {
            captureKey = key;
            keyHookCallback = callback;

            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                // フックを行う
                // 第1引数   フックするイベントの種類
                //   13はキーボードフックを表す
                // 第2引数 フック時のメソッドのアドレス
                //   フックメソッドを登録する
                // 第3引数   インスタンスハンドル
                //   現在実行中のハンドルを渡す
                // 第4引数   スレッドID
                //   0を指定すると、すべてのスレッドでフックされる
                hookPtr = SetWindowsHookEx(
                    13,
                    HookCallback,
                    GetModuleHandle(curModule.ModuleName),
                    0
                );
            }
        }

        static int HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if ((int)wParam != 256)
            {
                // 256は「キーを押した時」
                return 0;
            }
            Keys pressedKey = (Keys)(short)Marshal.ReadInt32(lParam);
            if (pressedKey != captureKey)
            {
                return 0;
            }
            keyHookCallback();

            // 1を戻すとフックしたキーが捨てられます
            return 1;
        }

        public static void EndHook()
        {
            if (hookPtr != IntPtr.Zero)
            {
                UnhookWindowsHookEx(hookPtr);
                hookPtr = IntPtr.Zero;
            }
        }
    }
}
