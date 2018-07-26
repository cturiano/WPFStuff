using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Chat.Views
{
    /// <summary>
    ///     Fixes the issue with Windows of Style <see cref="WindowStyle.None" /> covering the taskbar
    /// </summary>
    public class WindowResizer
    {
        #region Fields

        /// <summary>
        ///     The window to handle the resizing for
        /// </summary>
        private readonly Window _window;

        #endregion

        #region Constructors

        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="window">The window to monitor and correctly maximize</param>
        public WindowResizer(Window window)
        {
            _window = window;

            // Listen out for source initialized to setup
            _window.SourceInitialized += Window_SourceInitialized;
        }

        #endregion

        #region Private Methods

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        private static extern bool GetMonitorInfo(IntPtr hMonitor, MonitorInfo lpmi);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr MonitorFromPoint(Point pt, MonitorOptions dwFlags);

        /// <summary>
        ///     Initialize and hook into the windows message pump
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            // Get the handle of this window
            var handle = new WindowInteropHelper(_window).Handle;
            var handleSource = HwndSource.FromHwnd(handle);

            // Hook into it's Windows messages
            handleSource?.AddHook(WindowProc);
        }

        /// <summary>
        ///     Listens out for all windows messages for this window
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="handled"></param>
        /// <returns></returns>
        private IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                // Handle the GetMinMaxInfo of the Window
                case 0x0024: /* WM_GETMINMAXINFO */
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }

            return (IntPtr)0;
        }

        /// <summary>
        ///     Get the min/max window size for this window
        ///     Correctly accounting for the taskbar size and position
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lParam"></param>
        private void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            GetCursorPos(out var lMousePosition);

            var lPrimaryScreen = MonitorFromPoint(new Point(0, 0), MonitorOptions.MonitorDefaulttoprimary);
            var lPrimaryScreenInfo = new MonitorInfo();
            if (GetMonitorInfo(lPrimaryScreen, lPrimaryScreenInfo) == false)
            {
                return;
            }

            var lCurrentScreen = MonitorFromPoint(lMousePosition, MonitorOptions.MonitorDefaulttonearest);

            var lMmi = (MinMaxInfo)Marshal.PtrToStructure(lParam, typeof(MinMaxInfo));

            if (lPrimaryScreen.Equals(lCurrentScreen))
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcWork.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcWork.Top;
                lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcWork.Right - lPrimaryScreenInfo.rcWork.Left;
                lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcWork.Bottom - lPrimaryScreenInfo.rcWork.Top;
            }
            else
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcMonitor.Top;
                lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcMonitor.Right - lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcMonitor.Bottom - lPrimaryScreenInfo.rcMonitor.Top;
            }

            // Now we have the max size, allow the host to tweak as needed
            Marshal.StructureToPtr(lMmi, lParam, true);
        }

        #endregion
    }

    #region Dll Helper Structures

    internal enum MonitorOptions : uint
    {
        MonitorDefaulttonull = 0x00000000,
        MonitorDefaulttoprimary = 0x00000001,
        MonitorDefaulttonearest = 0x00000002
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MonitorInfo
    {
        #region Fields

        public int cbSize = Marshal.SizeOf(typeof(MonitorInfo));
        public int dwFlags = 0;
        public Rectangle rcMonitor = new Rectangle();
        public Rectangle rcWork = new Rectangle();

        #endregion
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rectangle
    {
        public int Left,
                   Top,
                   Right,
                   Bottom;

        public Rectangle(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MinMaxInfo
    {
        public Point ptReserved;
        public Point ptMaxSize;
        public Point ptMaxPosition;
        public Point ptMinTrackSize;
        public Point ptMaxTrackSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        /// <summary>
        ///     x coordinate of point.
        /// </summary>
        public int X;

        /// <summary>
        ///     y coordinate of point.
        /// </summary>
        public int Y;

        /// <summary>
        ///     Construct a point of coordinates (x,y).
        /// </summary>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    #endregion
}