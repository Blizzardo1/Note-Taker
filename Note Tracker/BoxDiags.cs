// <copyright file="BoxDiags.cs" company="Blizzeta Software and Gaming">
// Copyright (c) 2013 All Rights Reserved
// <author>Adonis S. Deliannis (Blizzardo1)</author>
// </copyright>
      
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Note_Taker
{
    public class BoxDiag
    {
        [DllImport("User32.dll", EntryPoint = "MessageBox")]
        public static extern DialogResult MsgBox(IntPtr hWnd, string Text, string Caption, MessageBoxIcon Type);

        public static void Error(Control controlResponsible, Form parentResponsible, bool Null)
        {
            MsgBox(parentResponsible.Handle, string.Format(Null ? "Error: {0} cannot be null" : "Error: {0}", controlResponsible.Name), null, MessageBoxIcon.Error); 
        }

        public static void Warning(Control controlResponsible, Form parentResponsible, string message)
        {
            MsgBox(parentResponsible.Handle, string.Format("Warning: {0}", message), null, MessageBoxIcon.Warning);
        }

        public static void Success(string message)
        {
            MsgBox(IntPtr.Zero, message, "Success", MessageBoxIcon.Information);
        }
    }
}
