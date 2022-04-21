using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinProject1
{
    class MyForm : Form
    {
        public MyForm()
        {
            // Change the caption of the application.
            Text = "Hello World Mailisa!!";
            MaximizeBox = false; ////How do you remove the minimize and maximize box from the window?
            MinimizeBox = false; /////How do you remove the minimize and maximize box from the window?
            BackColor = Color.Pink; ////How do you change the background color of the window?
            //Visible = false;
            WindowState = FormWindowState.Maximized; /////How do you make the window display as maximized?
            Size = new Size(100, 200); ///How do you set the position and size of the window?
            StartPosition = FormStartPosition.CenterScreen;  // centers form on screen
           

        }
        static void Main()
        {
            MyForm myForm = new MyForm();
            ///// myForm.BackColor = Color.Red; //chnage the background color
            ////myForm.Size = new Size(100, 200);
            // Display the form.
            Application.Run(myForm);
        }
    }
}
