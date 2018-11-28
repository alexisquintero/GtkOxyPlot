using System;
using System.Collections.Generic;
using System.Linq;
using Gtk;
using OxyPlot;
using OxyPlot.GtkSharp;
using OxyPlot.Series;

namespace GtkOxyPlot.GTK
{
  public class MainClass
  {
    [STAThread]
    public static void Main()
    {
      Application.Init();

      Window myWin = new Window("Plots");
      myWin.Resize(1000, 1000);

      Table tableLayout = new Table(5, 6, false);
      Label lblSimulation = new Label("Simulación");
      Label lblOptions = new Label("Opciones");
      Label lblForecast = new Label("Pronóstico");
      tableLayout.Attach(lblSimulation, 0, 2, 0, 1, AttachOptions.Expand, AttachOptions.Shrink, 5, 5);
      tableLayout.Attach(lblOptions, 2, 4, 0, 1, AttachOptions.Expand, AttachOptions.Shrink, 5, 5);
      tableLayout.Attach(lblForecast, 4, 6, 0, 1, AttachOptions.Expand, AttachOptions.Shrink, 5, 5);

      var plotModel = new PlotModel
      {
        Title = "Cos"
      };
      plotModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
      var plotView = new PlotView
      {
        Model = plotModel
      };

      tableLayout.Attach(plotView, 0, 2, 1, 2);

      var plotModel2 = new PlotModel
      {
        Title = "Sin"
      };
      plotModel2.Series.Add(new FunctionSeries(Math.Sin, 0, 10, 0.1, "sin(x)"));
      var plotView2 = new PlotView
      {
        Model = plotModel2
      };

      tableLayout.Attach(plotView2, 0, 2, 2, 3);

      var plotModel3 = new PlotModel
      {
        Title = "Cosh"
      };
      plotModel3.Series.Add(new FunctionSeries(Math.Cosh, 0, 10, 0.1, "cosh(x)"));
      var plotView3 = new PlotView
      {
        Model = plotModel3
      };

      tableLayout.Attach(plotView3, 4, 6, 1, 2);

      var plotModel4 = new PlotModel
      {
        Title = "Sinh"
      };
      plotModel4.Series.Add(new FunctionSeries(Math.Sinh, 0, 10, 0.1, "sinh(x)"));
      var plotView4 = new PlotView
      {
        Model = plotModel4
      };

      tableLayout.Attach(plotView4, 4, 6, 2, 3);

      var plotModel5 = new PlotModel
      {
        Title = "tan"
      };
      plotModel5.Series.Add(new FunctionSeries(Math.Tan, 0, 10, 0.1, "tan(x)"));
      var plotView5 = new PlotView
      {
        Model = plotModel5
      };

      tableLayout.Attach(plotView5, 4, 6, 3, 4);

      double[] input = new double[] {1.5, 2.6, 3.7, 4.8, 5.9, 8.0, 20.0};
      List<DataPoint> input2 = Enumerable.Range(1, input.Length).Zip(input, (x, y) => new DataPoint(x, y)).ToList();
      LineSeries ls = new LineSeries();
      ls.Points.AddRange(input2);
      var plotModel6 = new PlotModel
      {
        Title = "doubles"
      };
      plotModel6.Series.Add(ls);
      var plotView6 = new PlotView
      {
        Model = plotModel6
      };

      tableLayout.Attach(plotView6, 0, 2, 3, 4);

      Table tableOptionLayout = new Table(8, 2, false);
      Label lblSampleSize = new Label("Tamaño de la muestra: ");
      tableOptionLayout.Attach(lblSampleSize, 0, 1, 0, 1);
      Label lblPopulationSize = new Label("Tamaño de la población: ");
      tableOptionLayout.Attach(lblPopulationSize, 0, 1, 1, 2);
      Label lblError1 = new Label("Error 1: ");
      tableOptionLayout.Attach(lblError1, 0, 1, 2, 3);
      Label lblError2 = new Label("Error 2: ");
      tableOptionLayout.Attach(lblError2, 0, 1, 3, 4);
      Label lblError3 = new Label("Error 3: ");
      tableOptionLayout.Attach(lblError3, 0, 1, 4, 5);
      Label lblError4 = new Label("Error 4: ");
      tableOptionLayout.Attach(lblError4, 0, 1, 5, 6);
      Label lblError5 = new Label("Error 5: ");
      tableOptionLayout.Attach(lblError5, 0, 1, 6, 7);
      Label lblStartDate = new Label("Fecha inicio: ");
      tableOptionLayout.Attach(lblStartDate, 0, 1, 7, 8);

      Label lblSampleSizeValue = new Label("0");
      //Gtk.Widget a = new Adjustment(0, 0, 15, 1, 1, 1);
      tableOptionLayout.Attach(lblSampleSizeValue, 1, 2, 0, 1);
      Label lblPopulationSizeValue = new Label("Tamaño de la población: ");
      tableOptionLayout.Attach(lblPopulationSizeValue, 1, 2, 1, 2);
      Label lblError1Value = new Label("Error 1: ");
      tableOptionLayout.Attach(lblError1Value, 1, 2, 2, 3);
      Label lblError2Value = new Label("Error 2: ");
      tableOptionLayout.Attach(lblError2Value, 1, 2, 3, 4);
      Label lblError3Value = new Label("Error 3: ");
      tableOptionLayout.Attach(lblError3Value, 1, 2, 4, 5);
      Label lblError4Value = new Label("Error 4: ");
      tableOptionLayout.Attach(lblError4Value, 1, 2, 5, 6);
      Label lblError5Value = new Label("Error 5: ");
      tableOptionLayout.Attach(lblError5Value, 1, 2, 6, 7);
      Label lblStartDateValue = new Label("Fecha inicio: ");
      tableOptionLayout.Attach(lblStartDateValue, 1, 2, 7, 8);

      Table table2 = tableOptionLayout;

      tableLayout.Attach(tableOptionLayout, 2, 3, 1, 2);
      tableLayout.Attach(table2, 3, 4, 1, 2);

      myWin.Add(tableLayout);

      myWin.ShowAll();

      Application.Run();
    }
    private List<PlotViewData> SimulationPlotBuilder(String title)
    {
      double[] input = new double[] {1.5, 2.6, 3.7, 4.8, 5.9, 8.0};
      List<DataPoint> input2 = Enumerable.Range(1, input.Length).Zip(input, (x, y) => new DataPoint(x, y)).ToList();
      LineSeries ls = new LineSeries();
      ls.Points.AddRange(input2);
      var plotModel6 = new PlotModel
      {
        Title = "doubles"
      };
      plotModel6.Series.Add(ls);
      var plotView6 = new PlotView
      {
        Model = plotModel6
      };
      return null;
    }
    protected internal class PlotData
    {
      String title;
      double[] rawData = new double[] { };

      List<DataPoint> getDataPoints()
      {
        return Enumerable.Range(0, rawData.Length).Zip(rawData, (x, y) => new DataPoint(x, y)).ToList();
      }
    }
    protected internal class PlotViewData
    {
      PlotView plotView;
      int left;
      int right;
      int top;
      int bottom;
    }
  }
}
