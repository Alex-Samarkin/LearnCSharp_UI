using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmallBrowser_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /// задаем браузеру для отображения адрес, заданный текстом
            /// в меню
            /// обратите внимание: СНАЧАЛА создаем все компоненты,
            /// ПОТОМ, когда они "готовы" задаем их свойства
            ///
            webBrowser1.Url = new Uri(toolStripTextBox1.Text);
        }

        private void окноОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void инструкцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Добавим к браузеру строку для ввода адреса, 
кнопку для перехода по введенному адреcу и веб-браузер.
Для элементов интерфейса добавим главное меню по верху формы, 
браузер займет оставшееся пространство");
        }
    }
}
