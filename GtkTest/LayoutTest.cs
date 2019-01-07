using Xunit;
using GtkOxyPlot.GTK;
using Utils.Exceptions;

namespace GtkTest
{
  public class LayoutTest
  {
    [Fact]
    public void PlotBuilder_NullPds()
    {
      try
      {
        Helper.PlotBuilder(null, PlotType.Forecast);
      }
      catch (NullParameter np)
      {
        Assert.Equal(np.Message, NullParameter.eMessage);
      }
    }
  }
}
