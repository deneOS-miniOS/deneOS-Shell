using deneOS.init;
using System.Diagnostics;

namespace deneOS
{
    internal static class Program
    {
        public static DPKCore.Models.Manifest deneOSManifest = new()
            {
                Author = "repoficialx",
                EntryPoint = "deneOS.exe",
                Name = "deneOS System",
                Version = "0.5.1",
                Permissions = ["system.ui", "filesystem.user.read", "filesystem.user.write", "filesystem.software.read", "filesystem.software.write", "network.internet", "system.core.access"],
                TargetRuntime = "net10.0"
            };

        public static bool showBoot = false;
        static void ConfirmSMConfig()
        {
            if (!IsSMSetUp())
                ImportSMDefaults();
        }
        static bool IsSMSetUp()
        {
            string regKeyPath = @"HKEY_CURRENT_USER\Software\deneOS\startmenu";
            object? categories = Microsoft.Win32.Registry.GetValue(regKeyPath, "EntriesCategories", null);
            object? paths = Microsoft.Win32.Registry.GetValue(regKeyPath, "EntriesPaths", null);
            object? r2wbutton = Microsoft.Win32.Registry.GetValue(regKeyPath, "showR2WButton", null);
            return categories != null && paths != null && r2wbutton != null;
        }
        static void ImportSMDefaults()
        {
            string tempFile = Path.Combine(
        Path.GetTempPath(),
        $"deneOS_{Guid.NewGuid()}.reg"
    );

            try
            {
                File.WriteAllBytes(tempFile, Properties.Resources.SMDefaults);

                using (Process process = Process.Start(new ProcessStartInfo
                {
                    FileName = "regedit.exe",
                    Arguments = $"/s \"{tempFile}\"",
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }))
                {
                    process?.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar el registro:\n{ex.Message}");
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ConfirmSMConfig();
            adminMgmt.args = args;
            adminMgmt.argsCount = args.Length;
            Arguments();
            ApplicationConfiguration.Initialize();
                Application.Run(new BootScreen());
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration
        }
        static void Shell(string subArg)
        {
            if (subArg == "run")
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new Run(fromShell: true));
                
            }
            else if (subArg == "volSlider")
            {
                ApplicationConfiguration.Initialize();
                volSlider vol = new volSlider();
                vol.FormClosed += (s, e) => Environment.Exit(0);
                Application.Run(vol);
            }
            else if (subArg.StartsWith("crash::")) {
                ApplicationConfiguration.Initialize();
                string errorCode = subArg[8..];
                EmergencyScreen crash = new EmergencyScreen(errorCode);
                crash.FormClosed += (s, e) => Environment.Exit(0);
                Application.Run(crash);
            }
        }
        public static void Arguments()
        {


            if (File.Exists("c:\\currentsessionflags.txt")) File.Delete("c:\\currentsessionflags.txt");
            

            if (Debugger.IsAttached)
                flagMgmt.EnableDebug = true;

            string[] args = Environment.GetCommandLineArgs();
            string[] argfile = Array.Empty<string>();
            foreach (string arg in args)
            {
                _ = argfile.Length < args.Length ? argfile.Append(arg + Environment.NewLine) : null;

                if (arg.StartsWith("shell:")) Shell(arg[6..]);

                if (arg.StartsWith("/dangerZone:enableRoot")) flagMgmt.EnableRoot = true;
                else if (arg.StartsWith("/dangerZone:debug")) flagMgmt.EnableDebug = true;
                else if (arg.StartsWith("/dangerZone:disableLockScreen")) flagMgmt.DisableLockScreen = true;
                else if (arg.StartsWith("/dangerZone:skipBootAnim")) { flagMgmt.SkipBootAnim = true; showBoot = true; }
                else if (arg.StartsWith("/dangerZone:mockBattery")) flagMgmt.MockBattery = true;
                else if (arg.StartsWith("/dangerZone:classicMode")) flagMgmt.ClassicMode = true;
                else if (arg.StartsWith("/dangerZone:forceUpdate")) flagMgmt.ForceUpdate = true;

                else if (arg.StartsWith("/testing:untranslatedStrings")) flagMgmt.ShowUntranslatedStrings = true;
                else if (arg.StartsWith("/debugging:straightToDesktop")) flagMgmt.StraightToDesktop = true;
                else if (arg == "/safeMode") flagMgmt.SafeMode = true;
                else if (arg == "/safeMode:network") flagMgmt.SafeModeWithNetwork = true;
                else if (arg == "/resetPrefs") flagMgmt.ResetPrefs = true;
                else if (arg == "/recover") flagMgmt.RecoverMode = true;
                else if (arg == "/log") flagMgmt.LogSession = true;
                else if (arg == "/bypassChecks") flagMgmt.BypassChecks = true;
                else if (arg == "/sysinfo") flagMgmt.ShowSysInfo = true;
                else if (arg == "/noShell") flagMgmt.NoShell = true;
                else if (arg == "/emergencyUI") flagMgmt.EmergencyUI = true;
                else if (arg == "/offlineOnly") flagMgmt.OfflineOnly = true;
                else if (arg == "/forceVertical") flagMgmt.ForceVertical = true;
                else if (arg == "/forceOOBE") flagMgmt.ForceOOBE = true;

                else if (arg.StartsWith("/language:"))
                    flagMgmt.Language = arg.Split(':')[1];

                else if (arg.StartsWith("/application:"))
                    flagMgmt.LaunchAppId = arg.Split(':')[1];

                else if (arg.StartsWith("/locale:"))
                    flagMgmt.Locale = arg.Split(':')[1];

                else if (arg.StartsWith("/metricTime"))
                    flagMgmt.SelectedTimeFormat = flagMgmt.TimeFormat.Metric;

                else if (arg.StartsWith("/militaryTime"))
                    flagMgmt.SelectedTimeFormat = flagMgmt.TimeFormat.Military;
            }
            File.WriteAllLines(@"C:\CurrentSessionFlags.txt", argfile);
        }
    }
}