namespace HDE.Platform.Logging
{
	/// <summary>
    /// Type of logging event
    /// </summary>
    public enum LoggingEvent
    {
        Error = 0,// errors{}
        Warning,// warnings from cycle
        Debug,// For debugging
        Info
    };
}
