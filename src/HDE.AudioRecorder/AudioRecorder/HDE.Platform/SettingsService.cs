using System;
using System.IO;
using System.Reflection;
using HDE.Platform.Logging;
using HDE.Platform.Serialization;

namespace HDE.Platform.Services
{
    /// <summary>
    /// Provides basic settings functionallity.
    /// </summary>
    public class SettingsService<TSettings>
        where TSettings: new()
    {
        #region Fields

        private const string DefaultFileName = "Settings.xml";
        private ILog _log;
        private string _settingsFile;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates settings service.
        /// </summary>
        /// <param name="log">Opened log.</param>
        /// <param name="settingsFolder">Settings folder. If it doesn't exist it will be created.</param>
        /// <param name="fileName">File name.</param>
        public SettingsService(ILog log, string settingsFolder, string fileName = DefaultFileName)
        {
            Initialize(log, settingsFolder, fileName);
        }

        /// <summary>
        /// Creates settings service. Settings will be stored in application data \ executing assembly \ Settings.xml (which is good for most scenarios).
        /// </summary>
        /// <param name="log">Opened log.</param>
        public SettingsService(ILog log)
        {
#if DEBUG
            Initialize(log,
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location),
                    "Debug"),
                DefaultFileName);
#else

            Initialize(log, 
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)
                    ), 
                DefaultFileName);
#endif
        }

#endregion

#region Private Methods

        private void Initialize(ILog log, string settingsFolder, string settingsFileName)
        {
            if (log == null)
                throw new ArgumentNullException(nameof(log));
            if (!log.IsOpened)
                throw new ArgumentException("Log was not opened", nameof(log));
            if (string.IsNullOrWhiteSpace(settingsFolder))
                throw new ArgumentException("Settings folder was not specified.", nameof(settingsFolder));
            if (string.IsNullOrWhiteSpace(settingsFolder))
                throw new ArgumentException("Settings file name was not specified.", nameof(settingsFileName));
            
            _log = log;
            _settingsFile = Path.Combine(settingsFolder, settingsFileName);

            _log.Debug($"Settings file: {settingsFileName}.");

            if (!Directory.Exists(settingsFolder))
            {
                _log.Info($"Creating settings folder {settingsFolder}.");
                Directory.CreateDirectory(settingsFolder);
            }
        }

#endregion

#region Public Methods

        /// <summary>
        /// Loads settings. Doesn't throw exceptions.
        /// </summary>
        /// <returns>Settings. When settings file is missing or corrupted default settings will be returned.</returns>
        public TSettings Load()
        {
            _log.Info("Loading settings.");

            if (!File.Exists(_settingsFile))
            {
                _log.Info("Settings are missing. Default settings will be returned.");
                return new TSettings();
            }

            try
            {
                return SerializerHelper.Load<TSettings>(_settingsFile);
            }
            catch (Exception unhandledException)
            {
                _log.Error("Failed to load settings. Default settings will be returned.");
                _log.Error(unhandledException);
                return new TSettings();
            }
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="settings">Settings</param>
        public void Save(TSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            SerializerHelper.Save(settings, _settingsFile);
        }

#endregion
    }
}
