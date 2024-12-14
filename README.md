# How to Add Annotation in Axis Label Click in WPF SfChart?

This article provides a detailed walkthrough on how to add an annotation to a [WPF SfChart](https://www.syncfusion.com/wpf-controls/charts) using [LabelClicked](https://help.syncfusion.com/wpf/charts/axis#labelclicked) event when an axis label is clicked. This functionality enhances the interactivity of your chart by displaying specific information about the clicked label.

Learn step-by-step instructions and gain insights on using the Label Clicked event in a WPF SfChart.

**Step 1:** Initialize the SfChart with Primary and Secondary axes by referring to the WPF charts [documentation](https://help.syncfusion.com/wpf/charts/getting-started). Trigger the [LabelClicked](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartAxisBase2D.html#events) event on the primary axis.

XAML 
 ```xml
<chart:SfChart x:Name="chart">

    <chart:SfChart.PrimaryAxis>
        <chart:CategoryAxis LabelClicked="Axis_LabelClicked"/>
    </chart:SfChart.PrimaryAxis>
    
    <chart:SfChart.SecondaryAxis>
        <chart:NumericalAxis/>
    </chart:SfChart.SecondaryAxis>

    <chart:ColumnSeries ItemsSource="{Binding DataSource}" 
                        XBindingPath="Company" 
                        YBindingPath="Revenue"/>

</chart:SfChart> 
 ```

**Step 2:** Implement the event handler for the **LabelClicked** event of the primary axis. This event handler will be triggered when a label on the primary axis is clicked. The [LabelContent](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartAxisLabel.html#Syncfusion_UI_Xaml_Charts_ChartAxisLabel_LabelContent) and [Position](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartAxisLabel.html#Syncfusion_UI_Xaml_Charts_ChartAxisLabel_Position) of the clicked label can be retrieved from the [AxisLabelClickedEventArgs](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.AxisLabelClickedEventArgs.html).

C# 
 ```csharp
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Axis_LabelClicked(object sender, AxisLabelClickedEventArgs e)
    {
        string labelContent = e.AxisLabel.LabelContent.ToString();
        int labelPosition = (int)e.AxisLabel.Position;
    }
}
 ```

**Step 3:** Create and add an [Annotation](https://help.syncfusion.com/wpf/charts/annotations) to the chart in the event handler based on the label position obtained from the event arguments. Populate the data list from the ItemsSource to diplay the revenue values.
 
 C#
 ```csharp
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
        string labelContent = e.AxisLabel.LabelContent.ToString();
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
 ```

**Step 4:** After deploying the application, click on the axis label as shown in the output below; the annotations will be displayed, showing the values corresponding to the label.

**Output:**
 ![Presentation1](https://github.com/user-attachments/assets/2cfe0fe0-3e3c-42b1-acca-1ba8b3fab185)

## Troubleshooting
### Path too long exception
If you are facing a path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

For more details, refer to the KB on [How-to-Add-Annotation-in-Axis-Label-Click-in-WPF-SfChart](https://support.syncfusion.com/kb/article/18485/how-to-add-annotation-in-axis-label-click-in-wpf-sfchart).
