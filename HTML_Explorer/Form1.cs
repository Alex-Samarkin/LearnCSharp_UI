using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTML_Explorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "https://google.com";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                webBrowser1.Url = new Uri(textBox1.Text);
            }

        }

        /// <summary>
        /// вызываем операцию по передаче текста, когда весь документ будет загружен
        /// иначе могут быть ошибки, зато сейчас будут тормоза
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            /// браузер уммет преобразовывать свой документ
            /// во вменяемый текст
            textBox2.Text = webBrowser1.DocumentText;
        }
    }
}
