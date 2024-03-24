using StardewModdingAPI;

namespace MoreEvents;

public static class Logger
{
    private static IMonitor? _logger;

    public static void InitMonitor(IMonitor logger)
    {
        _logger = logger;
    }

    public static void Trace(string msg)
    {
        _logger?.Log(msg);
    }

    public static void Debug(string msg)
    {
        _logger?.Log(msg, LogLevel.Debug);
    }

    public static void Info(string msg)
    {
        _logger?.Log(msg, LogLevel.Info);
    }

    public static void Warn(string msg)
    {
        _logger?.Log(msg, LogLevel.Warn);
    }
}