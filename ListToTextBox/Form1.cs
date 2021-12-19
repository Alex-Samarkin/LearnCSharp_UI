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
    }
}
