using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TestAddIn.shared
{
    public class Tools
    {
        /* Customize cursor focus */
        [DllImport("user32.dll")]
        public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

        [DllImport("user32.dll")]
        public static extern bool ShowCaret(IntPtr hWnd);
        /* End customize cursor focus */

        // Hook all TextBoxes for custom caret
        public void HookAllTextBoxes(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBox tb)
                    tb.GotFocus += TextBox_GotFocus;
                else if (ctrl.HasChildren)
                    HookAllTextBoxes(ctrl.Controls);
            }
        }

       
        // Event handler for custom caret in TextBoxes
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                int caretWidth = 14;
                int caretHeight = tb.Font.Height;

                CreateCaret(tb.Handle, IntPtr.Zero, caretWidth, caretHeight);
                ShowCaret(tb.Handle);

                tb.Cursor = Cursors.IBeam;
            }
        }

        public void ApplyCustomCaret(TextBox tb, int caretWidth = 14)
        {
            int caretHeight = tb.Font.Height;
            CreateCaret(tb.Handle, IntPtr.Zero, caretWidth, caretHeight);
            ShowCaret(tb.Handle);
            tb.Cursor = Cursors.IBeam;
        }
    }
}
