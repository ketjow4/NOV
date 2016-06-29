using log4net.Config;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace MissionPlanner
{
	public static class Log4NetConfigurator
	{
		public static void Configure()
		{
			DirectoryInfo logs_directory = new DirectoryInfo("logs");
			DirectoryInfo logs_subdirectory = new DirectoryInfo(@"logs\FlightManager");
			if (!logs_directory.Exists || !logs_subdirectory.Exists)
			{
				Directory.CreateDirectory(@"logs\FlightManager");
			}
			
			DateTime today = DateTime.Today;
			string todayString = today.ToString("yyyy-MM-dd");

			FileInfo[] logFiles = logs_subdirectory.GetFiles();
			int filesToday = logFiles.Where(f => f.Name.StartsWith(todayString)).ToList().Count;
			string newFileName = todayString + "-Flight-Manager-Log-" + (filesToday + 1).ToString();
			
			string config_contents = string.Format(defaultConfigString, @"logs\FlightManager\" + newFileName + ".txt");
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(config_contents);
			XmlConfigurator.Configure(doc.DocumentElement);

			Console.SetOut(new ConsoleOverride());
		}

		private static string defaultConfigString = @"<log4net>
    <appender name=""RollingFile"" type=""log4net.Appender.RollingFileAppender"">
        <file value=""{0}"" />
        <appendToFile value=""true"" />
        <maximumFileSize value=""10MB"" />
        <maxSizeRollBackups value=""2"" />

        <layout type=""log4net.Layout.PatternLayout"">
            <conversionPattern value=""%level %thread - %message (%file:%line)%newline"" />
        </layout>
    </appender>
    
    <root>
        <level value=""INFO"" />
        <appender-ref ref=""RollingFile"" />
    </root>
</log4net>";
	}
}
