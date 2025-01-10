using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class WindowTransparent : MonoBehaviour
{
    private struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }
    [DllImport("user32.dll")]
    private static extern int MessageBox(IntPtr hwnd, string text, string caption, uint type);

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    private const int GWL_EXSTYLE = -20;
    private const uint WS_EX_LAYERED = 0x00080000;
    private const uint WS_EX_TRANSPARENT = 0x00000020;
    private const uint LWA_COLORKEY = 0x00000001;

    static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);
    [DllImport("user32.dll")]
    private static extern int SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
    private void Start()
    {
#if !UNITY_EDITOR
        //MessageBox(new IntPtr(0),"Hello","Hello",0);
        var margins = new MARGINS() { cxLeftWidth = -1 };
 
        // Get a handle to the window
        var hwnd = GetActiveWindow();
 
        // Extend the window into the client area
        DwmExtendFrameIntoClientArea(hwnd, ref margins);
        // Set properties of the window
        SetWindowLong(hwnd, GWL_EXSTYLE, WS_EX_LAYERED | WS_EX_TRANSPARENT);
        SetLayeredWindowAttributes(hwnd,0,0,LWA_COLORKEY);
        SetWindowPos(hwnd, HWND_TOPMOST,0,0,0,0,0);
      
#endif
        Application.runInBackground = true;
    }
}
