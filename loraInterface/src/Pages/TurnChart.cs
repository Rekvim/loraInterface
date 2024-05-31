using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace loraInterface.src.Pages
{
    public partial class TurnChart : UserControl
    {
        private Chart chart; // График для отображения данных
        private System.Windows.Forms.Timer timer; // Таймер для обновления данных

        public TurnChart()
        {
            InitializeChart(); // Инициализация компонентов графика
            LoadData(); // Загрузка начальных данных
            InitializeTimer(); // Инициализация таймера для периодической загрузки данных
        }

        // Метод для инициализации компонентов графика
        private void InitializeChart()
        {
            chart = new Chart
            {
                Dock = DockStyle.Fill, // Растягиваем график на всю панель управления
                BackColor = Color.White // Белый фон графика
            };

            ChartArea chartArea = new ChartArea
            {
                Name = "Графикк Дата/Актуальные вращения",
                AxisX =
                {
                    Title = "Дата", // Название оси X
                    IntervalType = DateTimeIntervalType.Auto, // Автоматический интервал по дате
                    Interval = 1, // Интервал в днях
                    LabelStyle = { Format = "dd.MM HH:mm" } // Формат отображения даты
                },
                AxisY = { Title = "Актуальные вращения" } // Название оси Y
            };

            chart.ChartAreas.Add(chartArea);

            Series series = new Series
            {
                Name = "Актуальные вращения",
                ChartType = SeriesChartType.Line, // Линейный тип графика
                XValueType = ChartValueType.DateTime, // Тип данных по оси X - дата и время
                YValueType = ChartValueType.Int32 // Тип данных по оси Y - целые числа
            };

            chart.Series.Add(series); // Добавление серии данных на график
            this.Controls.Add(chart); // Добавление графика на панель управления
        }

        // Метод для загрузки данных на график из файла
        private void LoadData()
        {
            List<TurnData> turnDataList = TurnData.ReadTurnDataFromFile(); // Чтение данных о вращениях из файла

            chart.Series["Актуальные вращения"].Points.Clear(); // Очистка текущих данных на графике перед загрузкой новых

            foreach (var turnData in turnDataList)
            {
                DateTime date;
                int actualTurn = turnData.ActualTurn;

                // Пытаемся распарсить дату и время с учетом нового формата "d.MM.yyyy HH:mm:ss"
                if (DateTime.TryParseExact(turnData.Data, "d.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    chart.Series["Актуальные вращения"].Points.AddXY(date, actualTurn); // Добавляем точку данных на график
                }
                else
                {
                    MessageBox.Show($"Error parsing date: {turnData.Data}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Выводим сообщение об ошибке при парсинге даты
                }
            }

            chart.Invalidate(); // Перерисовываем график для отображения новых данных
        }

        // Метод для инициализации таймера для периодической загрузки данных
        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer
            {
                Interval = 5000 // Интервал в миллисекундах (5000 мс = 5 секунд)
            };
            timer.Tick += Timer_Tick; // Устанавливаем обработчик события Tick для таймера
            timer.Start(); // Запускаем таймер
        }

        // Обработчик события Tick таймера для периодической загрузки данных
        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadData(); // Вызываем метод загрузки данных
        }
    }
}
