using System;
using System.Collections.Generic;
using Gtk;

namespace GtkOxyPlot.GTK
{
  public class MainClass
  {
    [STAThread]
    public static void Main()
    {
      Application.Init();

      DefaultOptions defaultOptions = new DefaultOptions();
      (List<PlotViewData>, List<PlotViewData>, List<TableData>, List<TableData>) data = Helper.GatherData(defaultOptions);
      Helper.InitWindow(data.Item1, data.Item2, data.Item3, data.Item4);

      Application.Run();
    }
  }
}
