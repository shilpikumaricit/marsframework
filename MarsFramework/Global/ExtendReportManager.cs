using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MarsFramework.Config;

namespace MarsFramework.Global
{
    class ExtendReportManager
    {
        public static ExtentReports extent { get; set; }
        public static ExtentHtmlReporter reporter { get; set; }
        public static ExtentTest test { get; set; }

        public static ExtentReports getInstance()
        {
            if(extent == null)
            {
                extent = new ExtentReports();
                reporter = new ExtentHtmlReporter(MarsResource.ReportXMLPath + MarsResource.ExtentReportFileName);
                extent.AttachReporter(reporter);
                extent.AddSystemInfo("Application Under Test", "nop Commerce Demo");
                extent.AddSystemInfo("Environment", "QA");
                extent.AddSystemInfo("Machine", Environment.MachineName);
                extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);

                string extentConfigPath = MarsResource.ExtentReportConfigFilePath;
                reporter.LoadConfig(extentConfigPath);
            }
            return extent;
        }

    }

   
}
