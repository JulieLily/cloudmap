
namespace TOPSUN.ERP.SystemFrameworks
{
	using System;
	using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics;
	using System.Configuration;
	using System.Xml;
    using System.Text;

	/// <summary>
	/// ApplicationConfiguration 的摘要说明。
	/// </summary>
	public class ApplicationConfiguration : IConfigurationSectionHandler
	{
		//
		// Constant values for all of the SystemFramework standard settings
		//
		private const String TRACING_ENABLED           = "ERP.SystemFramework.Tracing.Enabled";
		private const String TRACING_TRACEFILE         = "ERP.SystemFramework.Tracing.TraceFile";
		private const String TRACING_TRACELEVEL        = "ERP.SystemFramework.Tracing.TraceLevel";
		private const String TRACING_SWITCHNAME        = "ERP.SystemFramework.Tracing.SwitchName";
		private const String TRACING_SWITCHDESCRIPTION = "ERP.SystemFramework.Tracing.SwitchDescription";
		private const String EVENTLOG_ENABLED          = "ERP.SystemFramework.EventLog.Enabled";
		private const String EVENTLOG_MACHINENAME      = "ERP.SystemFramework.EventLog.Machine";
		private const String EVENTLOG_SOURCENAME       = "ERP.SystemFramework.EventLog.SourceName";
		private const String EVENTLOG_TRACELEVEL       = "ERP.SystemFramework.EventLog.LogLevel";
		private const String SYSINFO_CONNECTIONSTRING  = "ERP.SystemFramework.SysInfoConnectionString";
        
		//
		// Static member variables. These contain the application settings
		//   from Config.Web, or the default values.
		//
		private static bool tracingEnabled;
		private static String tracingTraceFile;
		private static TraceLevel tracingTraceLevel;
		private static String tracingSwitchName;
		private static String tracingSwitchDescription;
		private static bool eventLogEnabled;
		private static String eventLogMachineName;
		private static String eventLogSourceName;
		private static TraceLevel eventLogTraceLevel;
		private static String sysInfoConnectionString;
        
		//
		// The root directory of the application. Established in the
		//   OnApplicationStart callback form Global.asax.
		//
		private static String appRoot;
        
		//
		// Constant values for all of the default settings.
		//
		private const bool TRACING_ENABLED_DEFAULT             = true;
		private const String TRACING_TRACEFILE_DEFAULT         = "ApplicationTrace.txt";
		private const TraceLevel TRACING_TRACELEVEL_DEFAULT    = TraceLevel.Verbose;
		private const String TRACING_SWITCHNAME_DEFAULT        = "ApplicationTraceSwitch";
		private const String TRACING_SWITCHDESCRIPTION_DEFAULT = "Application error and tracing information";
		private const bool EVENTLOG_ENABLED_DEFAULT            = true;
		private const String EVENTLOG_MACHINENAME_DEFAULT      = ".";
		private const String EVENTLOG_SOURCENAME_DEFAULT       = "WebApplication";
		private const TraceLevel EVENTLOG_TRACELEVEL_DEFAULT   = TraceLevel.Error;
		private const String SYSINFO_CONNECTIONSTRING_DEFAULT  = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source=F:\Visual Studio Projects\TOPSUN-SOFT\ERP\SystemFrameworks\DATA\SysInformation.mdb";
        
		/// <summary>
		///     Called from OnApplicationStart to initialize settings from
		///     the Web.Config file(s). 
		///     <remarks>
		///         The app domain will restart if settings change, so there is 
		///         no reason to read these values more than once. This funtion
		///         uses the NameValueSectionHandler base class to generate a 
		///         hashtablefrom the XML, which is then used to store the current
		///         settings.  Because all settings are read here, we do not actually 
		///         store the generated hashtable object for later retrieval by
		///         Context.GetConfig. The application should use the accessor
		///         functions directly.
		///     </remarks>
		///     <param name="parent">An object created by processing a section 
		///         with this name in a Config.Web file in a parent directory.
		///     </param>
		///     <param name="configContext">The config's context.</param>
		///     <param name="section">The section to be read.</param>
		///     <retvalue>
		///		    <para>
		///             A ConfigOutput object: which we leave empty because all settings
		///             are stored at this point.
		///		    </para>
		///		    <para>
		///             null:  if there was an error.
		///		    </para>
		///	    </retvalue>
		/// </summary>
		public Object Create(Object parent, object configContext, XmlNode section)
		{
                    
			NameValueCollection settings;
                    
			try
			{
				NameValueSectionHandler baseHandler = new NameValueSectionHandler();
				settings = (NameValueCollection)baseHandler.Create(parent, configContext, section);
			}
			catch
			{
				settings = null;
			}
        
			if (settings == null)
			{
				tracingEnabled = TRACING_ENABLED_DEFAULT;
				tracingTraceFile = TRACING_TRACEFILE_DEFAULT;
				tracingTraceLevel = TRACING_TRACELEVEL_DEFAULT;
				tracingSwitchName = TRACING_SWITCHNAME_DEFAULT;
				tracingSwitchDescription = TRACING_SWITCHDESCRIPTION_DEFAULT;
				eventLogEnabled = EVENTLOG_ENABLED_DEFAULT;
				eventLogMachineName = EVENTLOG_MACHINENAME_DEFAULT;
				eventLogSourceName = EVENTLOG_SOURCENAME_DEFAULT;
				eventLogTraceLevel = EVENTLOG_TRACELEVEL_DEFAULT;
				sysInfoConnectionString = SYSINFO_CONNECTIONSTRING_DEFAULT;
			}
			else
			{
				tracingEnabled = ReadSetting(settings, TRACING_ENABLED, TRACING_ENABLED_DEFAULT);
				tracingTraceFile = ReadSetting(settings, TRACING_TRACEFILE, TRACING_TRACEFILE_DEFAULT);
				tracingTraceLevel = ReadSetting(settings, TRACING_TRACELEVEL, TRACING_TRACELEVEL_DEFAULT);
				tracingSwitchName = ReadSetting(settings, TRACING_SWITCHNAME, TRACING_SWITCHNAME_DEFAULT);
				tracingSwitchDescription = ReadSetting(settings, TRACING_SWITCHDESCRIPTION, TRACING_SWITCHDESCRIPTION_DEFAULT);
				eventLogEnabled = ReadSetting(settings, EVENTLOG_ENABLED, EVENTLOG_ENABLED_DEFAULT);
				eventLogMachineName = ReadSetting(settings, EVENTLOG_MACHINENAME, EVENTLOG_MACHINENAME_DEFAULT);
				eventLogSourceName = ReadSetting(settings, EVENTLOG_SOURCENAME, EVENTLOG_SOURCENAME_DEFAULT);
				eventLogTraceLevel = ReadSetting(settings, EVENTLOG_TRACELEVEL, EVENTLOG_TRACELEVEL_DEFAULT);
				sysInfoConnectionString = ReadSetting(settings, SYSINFO_CONNECTIONSTRING, SYSINFO_CONNECTIONSTRING_DEFAULT);
			}

			return null;
		}
        
		/// <summary>
		///     String version of ReadSetting.
		///     <remarks>
		///         Reads a setting from a hashtable and converts it to the correct
		///         type. One of these functions is provided for each type
		///         expected in the hash table. These are public so that other
		///         classes don't have to duplicate them to read settings from
		///         a hash table.
		///     </remarks>
		///     <param name="settings">The Hashtable to read from.</param>
		///     <param name="key">A key for the value in the Hashtable.</param>
		///     <param name="defaultValue">The default value if the item is not found.</param>
		///     <retvalue>
		///		    <para>value: from the hash table</para>
		///         <para>
		///             default: if the item is not in the table or cannot be case to the expected type.
		///		    </para>
		///	    </retvalue>
		/// </summary>
		public static String ReadSetting(NameValueCollection settings, String key, String defaultValue)
		{
			try
			{
				Object setting = settings[key];
                
				return (setting == null) ? defaultValue : (String)setting;
			}
			catch
			{
				return defaultValue;
			}
		}
        
		/// <summary>
		///     Boolean version of ReadSetting.
		///     <remarks>
		///         Reads a setting from a hashtable and converts it to the correct
		///         type. One of these functions is provided for each type
		///         expected in the hash table. These are public so that other
		///         classes don't have to duplicate them to read settings from
		///         a hash table.
		///     </remarks>
		///     <param name="settings">The Hashtable to read from.</param>
		///     <param name="key">A key for the value in the Hashtable.</param>
		///     <param name="defaultValue">The default value if the item is not found.</param>
		///     <retvalue>
		///		    <para>value: from the hash table</para>
		///         <para>
		///             default: if the item is not in the table or cannot be case to the expected type.
		///		    </para>
		///	    </retvalue>
		/// </summary>
		public static bool ReadSetting(NameValueCollection settings, String key, bool defaultValue)
		{
			try
			{
				Object setting = settings[key];
                
				return (setting == null) ? defaultValue : Convert.ToBoolean((String)setting);
			}
			catch
			{
				return defaultValue;
			}
		}
        
		/// <summary>
		///     int version of ReadSetting.
		///     <remarks>
		///         Reads a setting from a hashtable and converts it to the correct
		///         type. One of these functions is provided for each type
		///         expected in the hash table. These are public so that other
		///         classes don't have to duplicate them to read settings from
		///         a hash table.
		///     </remarks>
		///     <param name="settings">The Hashtable to read from.</param>
		///     <param name="key">A key for the value in the Hashtable.</param>
		///     <param name="defaultValue">The default value if the item is not found.</param>
		///     <retvalue>
		///		    <para>value: from the hash table</para>
		///         <para>
		///             default: if the item is not in the table or cannot be case to the expected type.
		///		    </para>
		///	    </retvalue>
		/// </summary>
		public static int ReadSetting(NameValueCollection settings, String key, int defaultValue)
		{
			try
			{
				Object setting = settings[key];
                
				return (setting == null) ? defaultValue : Convert.ToInt32((String)setting);
			}
			catch
			{
				return defaultValue;
			}
		}
        
		/// <summary>
		///     TraceLevel version of ReadSetting.
		///     <remarks>
		///         Reads a setting from a hashtable and converts it to the correct
		///         type. One of these functions is provided for each type
		///         expected in the hash table. These are public so that other
		///         classes don't have to duplicate them to read settings from
		///         a hash table.
		///     </remarks>
		///     <param name="settings">The Hashtable to read from.</param>
		///     <param name="key">A key for the value in the Hashtable.</param>
		///     <param name="defaultValue">The default value if the item is not found.</param>
		///     <retvalue>
		///		    <para>value: from the hash table</para>
		///         <para>
		///             default: if the item is not in the table or cannot be case to the expected type.
		///		    </para>
		///	    </retvalue>
		/// </summary>
		public static TraceLevel ReadSetting(NameValueCollection settings, String key, TraceLevel defaultValue)
		{
			try
			{
				Object setting = settings[key];
                
				return (setting == null) ? defaultValue : (TraceLevel)Convert.ToInt32((String)setting);
			}
			catch
			{
				return defaultValue;
			}
		}
        
		/// <summary>
		///     Function to be called by Application_OnStart as described in the
		///     class description. Initializes the application root.
		///     <param name="myAppPath">The path of the running application.</param>
		/// </summary>
		public static void OnApplicationStart(String myAppPath)
		{
			appRoot = myAppPath;
            ConfigurationManager.GetSection("ApplicationConfiguration");
			ConfigurationManager.GetSection("ERPConfiguration");            
		}
        
		/// <value>
		///     Property AppRoot is used to get the root path of the application.
		/// </value>
		public static String AppRoot
		{
			get
			{
				return appRoot;
			}
		}
        
		/// <value>
		///     Property TracingEnabled is used to get the configuration setting, defaulting to False on error.
		/// </value>
		public static bool TracingEnabled
		{
			get
			{
				return tracingEnabled;
			}
		}
        
		/// <value>
		///     Property TracingTraceFile is used to get the full path name to the file that contains trace 
		///     settings, defaults to ApplicationTrace.txt.
		/// </value>
		public static String TracingTraceFile
		{
			get
			{
				return tracingTraceFile;
			}
		}
        
		/// <value>
		///     Property TracingTraceFile is used to get the highest logging level that should be written to 
		///     the tracing file, defaults to TraceLevel.Verbose (however, TracingEnabled defaults
		///     to False, so you have to turn it on explicitly).
		/// </value>
		public static TraceLevel TracingTraceLevel
		{
			get
			{
				return tracingTraceLevel;
			}
		}
        
		/// <value>
		///   Property TracingSwitchName is used to get the trace switch name, defaults to ApplicationTraceSwitch.
		/// </value>
		public static String TracingSwitchName
		{
			get
			{
				return tracingSwitchName;
			}
		}
        
		/// <value>
		///   Property TracingSwitchDescription is used to get the trace settings file, defaults to 
		///     "Application error and tracing information".
		/// </value>
		public static String TracingSwitchDescription
		{
			get
			{
				return tracingSwitchDescription;
			}
		}
        
		/// <value>
		///     Property EventLogEnabled is used to get whether writing to the event log is support, defaults to True.
		///     <remarks>Returns true if writing to the event log is enabled, false otherwise</remarks>
		/// </value>
		public static bool EventLogEnabled
		{
			get
			{
				return eventLogEnabled;
			}
		}
		/// <value>
		///     Property EventLogMachineName is used to get the machine name to log the event to, defaults to an
		///     empty string, indicating the current machine.  A machine name 
		///     (without \\), may be empty.
		/// </value>
		public static String EventLogMachineName
		{
			get
			{
				return eventLogMachineName;
			}
		}
        
		/// <value>
		///     Property EventLogMachineName is used to get the source of the error to be written to the event log, 
		///     defaults WebApplication.
		/// </value>
		public static String EventLogSourceName
		{
			get
			{
				return eventLogSourceName;
			}
		}
        
		/// <value>
		///     Property EventLogTraceLevel is used to get the highest logging level that should be written to the event log,
		///     defaults to TraceLevel.Error.
		/// </value>
		public static TraceLevel EventLogTraceLevel
		{
			get
			{
				return eventLogTraceLevel;
			}
		}

		public static String SysInformationConnectionString
		{
			get
			{
				return sysInfoConnectionString;
			}
		}
        
	}
}
