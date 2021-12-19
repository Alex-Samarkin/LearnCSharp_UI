// LearnCSharp_UI
// ListToTextBox
// DataColumn.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 22:32 19 12 2021

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListToTextBox
{
    /// <summary>
    /// колонка данных с заголовком
    /// генерирует данные с помощью генератора случайных чисел r числом N
    /// данные лежат в списке Data
    /// данные переводятся в строки и выдаются StringBuilder sb
    /// 
    /// </summary>
    public class DataColumn : Header
    {
        private StringBuilder sb = new StringBuilder();
        private Random r = new Random();

        [Category("Данные"), Description("Количество генерируемых данных"), DefaultValue(1000)]
        [DisplayName("Количество")]
        [NotifyParentProperty(true)]
        public int N { get; set; } = 1000;

        /// <summary>
        /// далее мы изменим свойство на true
        /// </summary>
        [Browsable(false)]
        [Category("Данные"), Description("Список для размещения данных")]
        [DisplayName("Список данных")]
        [NotifyParentProperty(true)]
        public List<double> Data { get; set; } = new List<double>();

        /// <summary>
        /// очистить данные
        /// </summary>
        public void Clear()
        {
            Data.Clear();
        }

        /// <summary>
        /// создать массив данных, старые данные стираются
        /// </summary>
        public void Generate()
        {
            Clear();
            for (int i = 0; i < N; i++)
            {
                Data.Add(r.NextDouble());
            }

        }

        /// <summary>
        /// преобразовать данные в строки
        /// если данные отсутствуют, то они будут сгенерированы
        /// </summary>
        /// <returns>строки, отображающие данные</returns>
        public string ToLines()
        {
            if (Data.Count == 0)
            {
                Generate();
            }

            sb.Clear();
            foreach (double d in Data)
            {
                sb.AppendLine(d.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// считываем данные из текстового поля (должно быть multiline == true, НЕ ПРОВЕРЯЕМ для простоты
        /// </summary>
        /// <param name="textBox">поле с данными</param>
        public void FromTextBox(TextBox textBox)
        {
            /// удаляем старые данные
            Clear();
            /// преобразуем все строки
            foreach (string line in textBox.Lines)
            {
                double d = 0;
                /// если преобразование не удалось (ошибка в строке)
                /// задаем значение 0
                if (Double.TryParse(line,out d)==false)
                {
                    d = 0;
                }
                Data.Add(d);
            }

            /// попробуйте закомментировать строку ниже
            Data.RemoveAt(Data.Count-1);
        }

        #region Статистика

        [Browsable(false)]
        public double Sum => Data.Sum();
        [Browsable(false)]
        public double Count => Data.Count;
        [Browsable(false)]
        public double Min => Data.Min();
        [Browsable(false)]
        public double Max => Data.Max();
        [Browsable(false)]
        public double Avg => Data.Average();
        [Browsable(false)]
        public double SS
        {
            get
            {
                double ss = 0;
                double avg = Avg;
                foreach (double d in Data)
                {
                    ss += (d - avg) * (d - avg);
                }

                return ss;
            }
        }
        [Browsable(false)]
        public double Variance => SS / (Count - 1);
        [Browsable(false)]
        public double SD => Math.Sqrt(Variance);
        [Browsable(true)]
        public string Descr => $"N={Count} Min={Min} Max ={Max} Avg={Avg} Var={Variance} Sd={SD}";

        #endregion

    }
}