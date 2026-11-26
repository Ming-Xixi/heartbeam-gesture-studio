using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        try
        {
            string browser = FindBrowser();
            if (browser == null)
                throw new InvalidOperationException("请安装 Microsoft Edge 或 Google Chrome，然后重新打开光束心境。");

            byte[] content;
            using (Stream input = Assembly.GetExecutingAssembly().GetManifestResourceStream("Heartbeam.Page"))
            using (var buffer = new MemoryStream())
            {
                input.CopyTo(buffer);
                content = buffer.ToArray();
            }

            string version;
            using (var sha = SHA256.Create())
                version = BitConverter.ToString(sha.ComputeHash(content)).Replace("-", "").Substring(0, 16);
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "HeartbeamGestureStudio", version);
            Directory.CreateDirectory(directory);
            string page = Path.Combine(directory, "index.html");
            if (!File.Exists(page))
            {
                string temporaryPage = Path.Combine(directory, Guid.NewGuid().ToString("N") + ".tmp");
                try
                {
                    File.WriteAllBytes(temporaryPage, content);
                    try { File.Move(temporaryPage, page); }
                    catch (IOException) { if (!File.Exists(page)) throw; }
                }
                finally { if (File.Exists(temporaryPage)) File.Delete(temporaryPage); }
            }

            Process.Start(new ProcessStartInfo(browser, "--app=" + new Uri(page).AbsoluteUri)
            {
                UseShellExecute = false
            });
        }
        catch (Exception error)
        {
            MessageBox.Show(error.Message, "光束心境", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static string FindBrowser()
    {
        var roots = new[] {
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        };
        foreach (string application in new[] { @"Microsoft\Edge\Application\msedge.exe", @"Google\Chrome\Application\chrome.exe" })
        foreach (string root in roots)
        {
            if (String.IsNullOrEmpty(root)) continue;
            string candidate = Path.Combine(root, application);
            if (File.Exists(candidate)) return candidate;
        }
        return null;
    }
}
