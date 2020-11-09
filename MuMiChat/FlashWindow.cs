using System;
using System.Runtime.InteropServices;

namespace MuMiChat
{
    class FlashWindow
    {
        [DllImport("user32.dll")]
        public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        /// <summary>
        /// 閃爍類型
        /// </summary>
        public enum flashType : uint
        {
            FLASHW_STOP = 0, //停止閃爍
            FALSHW_CAPTION = 1, //只閃爍標題
            FLASHW_TRAY = 2, //只閃爍任務欄
            FLASHW_ALL = 3, //標題和任務欄同時閃爍
            FLASHW_PARAM1 = 4,
            FLASHW_PARAM2 = 12,
            FLASHW_TIMER = FLASHW_TRAY | FLASHW_PARAM1, //無條件閃爍任務欄直到發送停止標誌或者視窗被開啟，如果未開啟，停止時高亮
            FLASHW_TIMERNOFG = FLASHW_TRAY | FLASHW_PARAM2 //未開啟時閃爍任務欄直到發送停止標誌或者視窗被開啟，停止後高亮
        }

        /// <summary>
        /// 包含系統應在指定時間內閃爍視窗次數和閃爍狀態的信息
        /// </summary>
        public struct FLASHWINFO
        {
            /// <summary>
            /// 結構大小
            /// </summary>
            public uint cbSize;
            /// <summary>
            /// 要閃爍或停止的視窗handle
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            /// 閃爍的類型
            /// </summary>
            public uint dwFlags;
            /// <summary>
            /// 閃爍視窗的次數
            /// </summary>
            public uint uCount;
            /// <summary>
            /// 視窗閃爍的頻度，毫秒為單位；若該值為0，則為預設圖標的閃爍頻度
            /// </summary>
            public uint dwTimeout;
        }

        /// <summary>
        /// 閃爍視窗
        /// </summary>
        /// <param name="hWnd">視窗handle</param>
        /// <param name="type">閃爍類型</param>
        /// <returns></returns>
        public static bool FlashWindowEx(IntPtr hWnd, flashType type)
        {
            FLASHWINFO fInfo = new FLASHWINFO();
            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = hWnd;//要閃爍的視窗handle，該視窗可以是打開的或最小化的
            fInfo.dwFlags = (uint)type;//閃爍的類型
            fInfo.uCount = UInt32.MaxValue;//閃爍視窗的次數
            fInfo.dwTimeout = 0; //視窗閃爍的頻率，毫秒為單位；若該值為0，則為預設圖標的閃爍頻率
            return FlashWindowEx(ref fInfo);
        }
    }
}
