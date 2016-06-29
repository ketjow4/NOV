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

			FileInfo log4net_config = new FileInfo("log4net_config.xml");
			if (log4net_config.Exists)
			{
				string config_contents = File.ReadAllText(log4net_config.ToString());
				config_contents = string.Format(config_contents, @"logs\FlightManager\" + newFileName + ".txt");
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(config_contents);
				XmlConfigurator.Configure(doc.DocumentElement);
			}
			else
			{
				throw new Exception("Failed to configure log4net. Config not present.");
			}
		}
	}
}
