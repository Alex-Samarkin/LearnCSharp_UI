using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListToTextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /// 2 - Заполняем колонку данными и отображаем ее
            Column.Generate();
            propertyGrid1.SelectedObject = Column;
            /// раскомментируйте следующую строку.
            /// textBox2.Text = Column.ToLines();
            /// теперь закоменнтируйте строку выше, чтобы опять /// textBox2.Text = Column.ToLines();
            /// и раскомментироуйте следующую
            /// textBox2.Lines = Column.ToLines().Split(Environment.NewLine.ToCharArray());
        }

        /// <summary>
        /// 1 - создаем колонку
        /// заполнять ее мы можем только в конструкторе, чтобы у нас быди компоненты для
        /// размещения данных
        /// </summary>
        public DataColumn Column { get; set; } = new DataColumn();

        /// <summary>
        /// вывод данных в текстовое поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // textBox2.Lines = Column.ToLines().Split(Environment.NewLine.ToCharArray());
            textBox2.Text = Column.ToLines();
        }

        /// <summary>
        /// создание и запись данных в текстовое поле
        /// измените N на величину в диапазоне 20-30
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Column.Generate();
            textBox2.Text = Column.ToLines();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Column.FromTextBox(textBox2);
            // вывод тех данных, которые попали в массив с учетом конвертации
            // добавьте в текстовом поле "неправильную" строку и проверьте результат
            textBox2.Text = Column.ToLines();
        }
    }
}
