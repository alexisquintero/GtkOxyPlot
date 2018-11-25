using System;
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

      Table tableLayout = new Table(5, 3, false);
      Label lblSimulation = new Label("Simulación");
      Label lblOptions = new Label("Opciones");
      Label lblForecast = new Label("Pronóstico");
      tableLayout.Attach(lblSimulation, 0, 1, 0, 1);
      tableLayout.Attach(lblOptions, 1, 2, 0, 1);
      tableLayout.Attach(lblForecast, 2, 3, 0, 1);

      var plotModel = new PlotModel
      {
        Title = "Cos"
      };
      plotModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
      var plotView = new PlotView
      {
        Model = plotModel
      };

      tableLayout.Attach(plotView, 0, 1, 1, 2);

      var plotModel2 = new PlotModel
      {
        Title = "Sin"
      };
      plotModel2.Series.Add(new FunctionSeries(Math.Sin, 0, 10, 0.1, "sin(x)"));
      var plotView2 = new PlotView
      {
        Model = plotModel2
      };

      tableLayout.Attach(plotView2, 0, 1, 2, 3);

      var plotModel3 = new PlotModel
      {
        Title = "Cosh"
      };
      plotModel3.Series.Add(new FunctionSeries(Math.Cosh, 0, 10, 0.1, "cosh(x)"));
      var plotView3 = new PlotView
      {
        Model = plotModel3
      };

      tableLayout.Attach(plotView3, 2, 3, 1, 2);

      var plotModel4 = new PlotModel
      {
        Title = "Sinh"
      };
      plotModel4.Series.Add(new FunctionSeries(Math.Sinh, 0, 10, 0.1, "sinh(x)"));
      var plotView4 = new PlotView
      {
        Model = plotModel4
      };

      tableLayout.Attach(plotView4, 2, 3, 2, 3);

      var plotModel5 = new PlotModel
      {
        Title = "tan"
      };
      plotModel5.Series.Add(new FunctionSeries(Math.Tan, 0, 10, 0.1, "tan(x)"));
      var plotView5 = new PlotView
      {
        Model = plotModel5
      };

      tableLayout.Attach(plotView5, 2, 3, 3, 4);

      myWin.Add(tableLayout);

      myWin.ShowAll();

      Application.Run();
    }
  }
}
