using Microsoft.Win32;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GbDriver.Helpers
{
    class ChromeReg
    {
        private object path;
        private string version;
        public string Version
        {
            get { return version; }
        }
        public ChromeReg()
        {
            path = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\chrome.exe", null, null);
            version = FileVersionInfo.GetVersionInfo(path.ToString()).FileVersion;
        }
    }

    class NewChromeDriver
    {
        public IWebDriver driver;

        ChromeOptions chromeOptions;
        ChromeReg chromeReg;
        WebClient webClient;
        string baseDirectoryPath = $"{AppDomain.CurrentDomain.BaseDirectory}",
               chromedriverPath = Path.Combine($"{AppDomain.CurrentDomain.BaseDirectory}", "chromedriver-win32/chromedriver.exe"),
               chromePath = Path.Combine($"{AppDomain.CurrentDomain.BaseDirectory}", "chrome-win32/chrome.exe"),
               chromeForTestZipUrl = $"https://edgedl.me.gvt1.com/edgedl/chrome/chrome-for-testing/120.0.6099.109/win32/chrome-win32.zip",
               chromeForTestZipPath = $"{AppDomain.CurrentDomain.BaseDirectory}" + "chrome - win32.zip",
               chromedriverZipUrl = $"https://edgedl.me.gvt1.com/edgedl/chrome/chrome-for-testing/120.0.6099.109/win32/chromedriver-win32.zip",
               chromedriverZipPath = $"{AppDomain.CurrentDomain.BaseDirectory}" + "chromedriver-win32.zip";
        public NewChromeDriver()
        {
            chromeReg = new ChromeReg();
            webClient = new WebClient();
            chromeOptions = new ChromeOptions();
            chromeOptions.BinaryLocation = chromePath;

            // Console.WriteLine($">>>---------> Chrome Version:{chromeReg.Version} <---------<<<");
            // Console.WriteLine($">>>---------> Is it time for a new WebDriver...? <---------<<<");
            // Console.WriteLine($">>>---------> All Your Base: {baseDirectoryPath} <---------<<<");
            // Console.WriteLine($">>>--------->Chrome Zip From Here: {chromeForTestZipUrl} <---------<<<");
            // Console.WriteLine($">>>--------->Driver Zip From Here: {chromedriverZipUrl} <---------<<<");
            // Console.WriteLine($">>>--------->Driver Runs From Here: {chromedriverPath} <---------<<<");
            // Console.WriteLine($">>>--------->Chrome Runs From Here: {chromePath} <---------<<<");

            if (!File.Exists(chromedriverPath))
            {
                Console.WriteLine($">>>---------> No Driver File : @ ) {chromedriverPath} getting driver");
                ifNotDownloadFile(chromedriverZipUrl, chromedriverZipPath);
                Console.WriteLine($">>>---------> Got Driver Zip, Extracting to : {chromedriverPath}");
                ifNotUnzip(chromedriverZipPath, baseDirectoryPath);
                File.Copy(chromedriverPath, baseDirectoryPath + "chromedriver.exe");
            }
            if (!File.Exists(chromePath))
            {
                Console.WriteLine($">>>---------> No Chrome File : @ ) {chromePath} getting chrome");
                ifNotDownloadFile(chromeForTestZipUrl, chromeForTestZipPath);
                Console.WriteLine($">>>---------> Got Chrome Zip, Extracting to : {chromePath}");
                ifNotUnzip(chromeForTestZipPath, baseDirectoryPath);
            }

            try
            {
                driver = new ChromeDriver(chromeOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
        void ifNotDownloadFile(string url, string path)
        {
            if (!File.Exists(path))
            {
                webClient.DownloadFile(url, path);
            }
        }
        void ifNotUnzip(string url, string path)//baseDirectoryPath + "chromedriver_win32.zip"
        {
            if (!File.Exists(path))
                ZipFile.ExtractToDirectory(url, path);
        }
    }
}

