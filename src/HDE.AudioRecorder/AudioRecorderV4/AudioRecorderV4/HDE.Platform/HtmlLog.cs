using System;
using System.IO;
using System.Globalization;
using HDE.Platform.FileIO;

namespace HDE.Platform.Logging
{
    /// <summary>
    /// Logs and outputs information to File
    /// </summary>
    public class HtmlLog : LogBase
    {
        #region Consts

        const string _TIME_FORMATSTRING = "yyyy.MM.dd HH.mm.ss";

        #endregion

        #region Fields

        readonly SyncFile _syncfile = new SyncFile();
        readonly string _logsFolder;
        StreamWriter _output;
        
        #endregion

        #region Properties

        protected string LogHeader { get; set; }
        protected string LogFooter { get; set; }
        protected string LogExtension { get; set; }
        
        #endregion

        #region Constructors

        /// <param name="htmlOpen">
        /// <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
        /// <HTML>
        /// <HEAD>
        /// 	<META HTTP-EQUIV="CONTENT-TYPE" CONTENT="text/html; charset=utf-8">
        /// 	<TITLE>{0} - {1}</TITLE>
        /// 	<META NAME="GENERATOR" CONTENT="BUtil backup operations log">
        /// </HEAD>
        /// <BODY>
        /// <table border = "0" align="center" cellpadding="5" cellspacing="0" width="100%">
        /// 	<tr>
        /// 		<td align="center" nowrap="nowrap" bgcolor="#264b99">
        /// 			<a target="_new" href="{2}"><font color="#ffffff">{5}</font></a>
        /// 			<a target="_new" href="{3}"><font color="#ffffff">{6}</font></a>
        /// 			<a target="_new" href="{4}"><font color="#ffffff">{7}</font></a>
        /// 		</td>
        /// 	</tr>
        /// <table>
        /// </br>
        /// </param>
        /// <exception cref="LogException">Synchronization failled</exception>
        public HtmlLog(
            string logsFolder, 
            string logHeader)
		{
            LogHeader = logHeader;
            LogExtension = ".html";
            LogFooter = "</body>\r\n</html>";
            _logsFolder = logsFolder;
        	if (string.IsNullOrEmpty(logsFolder))
        	{
        		throw new ArgumentNullException("logsFolder");
        	}
        }

        public HtmlLog(string logsFolder)
            : this (logsFolder, "<html><head></head><body>")
        {
        }

        #endregion

        #region Protected Methods

        protected override void OpenInternal()
		{
            if (!Directory.Exists(_logsFolder))
            {
                Directory.CreateDirectory(_logsFolder);
            }

            try
            {
                do
                {
                    do
                    {
                        _logFile = Path.Combine(_logsFolder,
                            DateTime.Now.ToString(_TIME_FORMATSTRING, CultureInfo.CurrentCulture) +
                            LogExtension);
                    }
                    while (File.Exists(_logFile));
                }
                while (!_syncfile.TrySyncFile(_logFile));
            }
            catch (ArgumentException e)
            {
                throw new LogException(e.Message);
            }

            // creating log on the base of template
            // required to reduce problems with encoding
			try
			{
			    var logStream = new FileStream(_logFile, FileMode.Create, FileAccess.Write, FileShare.Read);
                _output = new StreamWriter(logStream);
                _output.Write(LogHeader);
			}
			catch (Exception e)
			{
                throw new LogException(e.Message, e);
			}
		}
	
        protected override void WriteInternal(LoggingEvent loggingEvent,string message)
        {
            string output = HtmlLogFormatter.GetHtmlFormattedLogMessage(loggingEvent, message);
            WriteCore(output);
        }
	  
        protected override void CloseInternal()
        {
            WriteCore(LogFooter);

            _output.Flush();
            _output.Close();
            _syncfile.Dispose();
            
            System.Diagnostics.Debug.WriteLine("log::close::finished");
        }

        protected void WriteCore(string message)
        {
            _output.WriteLine(message);
            _output.Flush();
        }

        #endregion
    }
}
