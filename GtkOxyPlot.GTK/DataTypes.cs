using Gtk;
using OxyPlot;
using OxyPlot.GtkSharp;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GtkOxyPlot.GTK
{
  public enum PlotType { Simulation, Forecast };
  public class PlotData
  {
    public PlotData(string title, double[] rd)
    {
      this.title = title; rawData = rd;
    }
    public string title;
    private double[] rawData = new double[] { };
    public LineSeries data = new LineSeries();

    public List<DataPoint> GetDataPoints()
    {
      return Enumerable.Range(0, rawData.Length).Zip(rawData, (x, y) => new DataPoint(x, y)).ToList();
    }
  }
  public class TableData
  {
    public Table table;
    public uint left;
    public uint right;
    public uint top;
    public uint bottom;
  }
  public class StatisticsTableData
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
  public class PlotViewData
  {
    public PlotView plotView;
    public uint left;
    public uint right;
    public uint top;
    public uint bottom;
  }
  public class DefaultOptions
  {
    public int sampleSize = 0;
    public DateTime startDate = DateTime.Today;
  }
}
