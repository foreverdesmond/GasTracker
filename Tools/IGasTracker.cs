namespace GasTrackerTool
{
    public interface IGasTracker
    {
        Task<decimal> GetGasPriceAsync();
    }
}
