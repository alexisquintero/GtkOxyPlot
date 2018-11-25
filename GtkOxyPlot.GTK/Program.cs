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

      Window myWin = new Window("My first Gtk# Application");
      myWin.Resize(200, 200);

      Label myLbl = new Label
      {
        Text = "Hello World"
      };

      //myWin.Add(myLbl);
      var plotModel = new PlotModel {
        Title = "Example 1"
      };

      plotModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));

      var plotView = new PlotView {
        Model = plotModel
      };

      myWin.Add(plotView);

      myWin.ShowAll();

      Application.Run();
    }
  }
}
