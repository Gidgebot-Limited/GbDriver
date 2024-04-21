using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using GbDriver;
using System.Xml.Linq;

namespace GbDriver.Helpers
{
    class Gb_Data
    {
        public string SetSSPath()
        {
            return Path.GetFullPath(getScreenshotDirectory() + "/" + GetCallingClass() + "/" + getCallingMethod() + "/");
        }
        public string GetCallingClass()
        {
            StackTrace stackTrace = new StackTrace();
            if (stackTrace.FrameCount > 1)
            {
                var callingMethod = stackTrace.GetFrame(1)?.GetMethod();
                if (callingMethod != null)
                {
                    var parentClass = callingMethod.DeclaringType;
                    if (parentClass != null)
                    {
                        return parentClass.Name;
                    }
                }
            }

            return "Unknown";
        }
        public string getCallingMethod()
        {
            StackTrace stackTrace = new StackTrace();
            if (stackTrace.FrameCount > 1)
            {
                var callingMethod = stackTrace.GetFrame(1).GetMethod();
                return callingMethod.Name;
            }
            return "UnknownCallingMethod";
        }
        public string getScreenshotDirectory()
        {
            return "../../../../Screenshots/";
        }

    }
}
