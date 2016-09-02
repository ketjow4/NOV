using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MissionPlanner
{
	public class ConsoleOverride : TextWriter
	{
		private static readonly ILog log = LogManager.GetLogger("Console");

		public override void Write(string value)
		{
			log.Info(value.Replace("\n", string.Empty));
			base.Write(value);
		}

		public override void Write(string format, object arg0)
		{
			log.Info(string.Format(format, arg0).Replace("\n", string.Empty));
			base.Write(format, arg0);
		}

		public override void Write(string format, object arg0, object arg1)
		{
			log.Info(string.Format(format, arg0, arg1).Replace("\n", string.Empty));
			base.Write(format, arg0, arg1);
		}

		public override void Write(string format, object arg0, object arg1, object arg2)
		{
			log.Info(string.Format(format, arg0, arg1, arg2).Replace("\n", string.Empty));
			base.Write(format, arg0, arg1, arg2);
		}

		public override void Write(string format, params object[] arg)
		{
			log.Info(string.Format(format, arg).Replace("\n", string.Empty));
			base.Write(format, arg);
		}

		public override void WriteLine(string value)
		{
			log.Info(value.Replace("\n", string.Empty));
			base.WriteLine(value);
		}

		public override void WriteLine(string format, object arg0)
		{
			log.Info(string.Format(format, arg0).Replace("\n", string.Empty));
			base.WriteLine(format, arg0);
		}

		public override void WriteLine(string format, object arg0, object arg1)
		{
			log.Info(string.Format(format, arg0, arg1).Replace("\n", string.Empty));
			base.WriteLine(format, arg0, arg1);
		}

		public override void WriteLine(string format, object arg0, object arg1, object arg2)
		{
			log.Info(string.Format(format, arg0, arg1, arg2).Replace("\n", string.Empty));
			base.WriteLine(format, arg0, arg1, arg2);
		}

		public override void WriteLine(string format, params object[] arg)
		{
			log.Info(string.Format(format, arg).Replace("\n", string.Empty));
			base.WriteLine(format, arg);
		}

		public override Encoding Encoding
		{
			get
			{
				return Encoding.UTF8;
			}
		}
	}
}
