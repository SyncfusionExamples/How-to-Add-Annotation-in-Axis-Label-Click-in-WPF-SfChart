using System.Windows;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Charts;

namespace WPFChartLabelEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<double> data = new();

        public MainWindow()
        {
            InitializeComponent();

            foreach (var value in viewModel.DataSource)
            {
                data.Add(value.Revenue);
            }
        }

        private void Axis_LabelClicked(object sender, AxisLabelClickedEventArgs e)
        {
            string labelContent = (string)e.AxisLabel.LabelContent;
            int labelPosition = (int)e.AxisLabel.Position;

            chart.Annotations.Clear();

            RectangleAnnotation annotation = new()
            {
                X1 = labelPosition,
                Y1 = data[labelPosition] + 10,
                X2 = labelPosition + 1,
                Y2 = data[labelPosition] + 110,
                CoordinateUnit = CoordinateUnit.Axis,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalTextAlignment = VerticalAlignment.Center,
                Text = $"Revenue: {data[labelPosition]} USD",
                FontWeight = FontWeights.Bold,
                Fill = new SolidColorBrush(Colors.SkyBlue),
                Stroke = new SolidColorBrush(Colors.Transparent)
            };

            chart.Annotations.Add(annotation);
        }
    }
}