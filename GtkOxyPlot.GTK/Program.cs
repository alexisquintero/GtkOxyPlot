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
      myWin.Maximize();

      Table tableLayout = new Table(5, 6, false);
      Label lblSimulation = new Label("Simulación");
      Label lblOptions = new Label("Opciones");
      Label lblForecast = new Label("Pronóstico");
      tableLayout.Attach(lblSimulation, 0, 2, 0, 1, AttachOptions.Expand, AttachOptions.Shrink, 5, 5);
      tableLayout.Attach(lblOptions, 2, 4, 0, 1, AttachOptions.Expand, AttachOptions.Shrink, 5, 5);
      tableLayout.Attach(lblForecast, 4, 6, 0, 1, AttachOptions.Expand, AttachOptions.Shrink, 5, 5);

      //Start dummy data
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

      double[] input = new double[] { 1.5, 2.6, 3.7, 4.8, 5.9, 8.0, 20.0 };
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

      StatisticsTableData std11 = new StatisticsTableData(1, 2, 3, 4, 5, 6, 7, DateTime.MinValue);
      StatisticsTableData std12 = new StatisticsTableData(1, 2, 3, 4, 5, 6, 7, DateTime.MinValue);
      StatisticsTableData std13 = new StatisticsTableData(1, 2, 3, 4, 5, 6, 7, DateTime.MinValue);
      StatisticsTableData std21 = new StatisticsTableData(0,9,8,7,6,5,4,DateTime.MinValue);
      StatisticsTableData std22 = new StatisticsTableData(0,9,8,7,6,5,4,DateTime.MinValue);
      StatisticsTableData std23 = new StatisticsTableData(0,9,8,7,6,5,4,DateTime.MinValue);
      List<StatisticsTableData> stdsSimulation = new List<StatisticsTableData>
      {
        std11,
        std12,
        std13
      };
      List<StatisticsTableData> stdsForecast = new List<StatisticsTableData>
      {
        std21,
        std22,
        std23
      };

      List<TableData> stbSimulation = StatisticalTableBuilder(stdsSimulation, TableType.Simulation);
      List<TableData> stbForecast = StatisticalTableBuilder(stdsForecast, TableType.Forecast);
      stbSimulation.ForEach(td => tableLayout.Attach(td.table, td.left, td.right, td.top, td.bottom));
      stbForecast.ForEach(td => tableLayout.Attach(td.table, td.left, td.right, td.top, td.bottom));
      //End dummy data

      myWin.Add(tableLayout);

      myWin.ShowAll();

      Application.Run();
    }
    private List<PlotView> PlotViewBuilder(List<PlotData> pds)
    {
      List<PlotView> pvs = new List<PlotView>();
      pds.ForEach(p =>
      {
        LineSeries ls = new LineSeries();
        ls.Points.AddRange(p.GetDataPoints());
        PlotModel plotModel = new PlotModel
        {
          Title = p.title
        };
        plotModel.Series.Add(ls);
        PlotView plotView = new PlotView
        {
          Model = plotModel
        };
        pvs.Add(plotView);
      });
      return pvs;
    }
    //Simulation plot occupy: left=0; right=2;
    //Forecast plot occupy: left=4; right=6;
    private enum PlotType { Simulation, Forecast };
    //Call first with Simulation plots, then Forecast, or vice versa
    private List<PlotViewData> SimulationPlotBuilder(List<PlotData> pds, PlotType pt)
    {
      List<PlotView> pvs = PlotViewBuilder(pds);

      int left, right;
      switch (pt)
      {
        case PlotType.Simulation: left = 0; right = 2; break;
        case PlotType.Forecast: left = 4; right = 6; break;
        default: left = 0; right = 0; break;
      }
      //TODO: throw new exception if left == right

      List<PlotViewData> pvds = new List<PlotViewData>();
      pvs.ForEach(pv =>
      {
        PlotViewData pvd = new PlotViewData
        {
          plotView = pv,
          left = left,
          right = right,
          top = pvds.Count,
          bottom = pvds.Count + 1
        };
      });

      return pvds;
    }
    private enum TableType { Simulation, Forecast };
    private static List<TableData> StatisticalTableBuilder(List<StatisticsTableData> stds, TableType tt)
    {
      uint left, right;
      switch (tt)
      {
        case TableType.Simulation: left = 2; right = 3; break;
        case TableType.Forecast: left = 3; right = 4; break;
        default: left = 0; right = 0; break;
      }
      //TODO: throw new exception if left == right

      List<TableData> tds = new List<TableData>();
      List<String> lbls = new List<String>{
        "Tamaño de la muestra: ",
        "Tamaño de la población: ",
        "Desviación Media Absoluta: ",
        "Desviación Media Porcentual: ",
        "Error Porcentual Medio: ",
        "Error Cuadrático Medio: ",
        "Raíz cuadrada del error cuadrático medio: ",
        "Fecha de inicio: "
      };

      stds.ForEach(std =>
      {
        List<Label> lblsValue = new List<Label>
        {
          new Label(std.SampleSize.ToString()),
          new Label(std.PopulationSize.ToString()),
          new Label(std.MeanAbsoluteDeviation.ToString()),
          new Label(std.MeanAbsolutePercentageError.ToString()),
          new Label(std.MeanPercentageError.ToString()),
          new Label(std.MeanSquaredError.ToString()),
          new Label(std.RootMeanSquareDeviation.ToString()),
          new Label(std.StartDate.ToString())
        };

        Table table = new Table(8, 2, false);
        uint lblsCounter = 0;
        lbls.ForEach(l =>
        {
          table.Attach(new Label(l), 0, 1, lblsCounter, lblsCounter + 1);
          lblsCounter++;
        });
        lblsCounter = 0;
        lblsValue.ForEach(l =>
        {
          table.Attach(l, 1, 2, lblsCounter, lblsCounter + 1);
          lblsCounter++;
        });

        TableData td = new TableData
        {
          table = table,
          left = left,
          right = right,
          top = (uint) tds.Count + 1,
          bottom = (uint) tds.Count + 2
        };

        tds.Add(td);
      });

      return tds;
    }
    class TableData
    {
      public Table table;
      public uint left;
      public uint right;
      public uint top;
      public uint bottom;
    }
    class StatisticsTableData
    {
      public StatisticsTableData(int ss, int ps, double mad, double mape, double mpe, double mse, double rmsd, DateTime sd)
      {
        SampleSize = ss; PopulationSize = ps; MeanAbsoluteDeviation = mad; MeanAbsolutePercentageError = mape;
        MeanPercentageError = mpe; MeanSquaredError = mse; RootMeanSquareDeviation = rmsd; StartDate = sd;
      }
      public int SampleSize;
      public int PopulationSize;
      public double MeanAbsoluteDeviation;
      public double MeanAbsolutePercentageError;
      public double MeanPercentageError;
      public double MeanSquaredError;
      public double RootMeanSquareDeviation;
      public DateTime StartDate;
    }
    class PlotData
    {
      public String title;
      double[] rawData = new double[] { };

      public List<DataPoint> GetDataPoints()
      {
        return Enumerable.Range(0, rawData.Length).Zip(rawData, (x, y) => new DataPoint(x, y)).ToList();
      }
    }
    protected internal class PlotViewData
    {
      public PlotView plotView;
      public int left;
      public int right;
      public int top;
      public int bottom;
    }
  }
}
