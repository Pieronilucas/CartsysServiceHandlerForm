using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Unicode;

public sealed class ConversaoUTF8
{
    private static readonly Lazy<ConversaoUTF8> _instance = new Lazy<ConversaoUTF8>(() => new ConversaoUTF8());
    public static ConversaoUTF8 Instance => _instance.Value;

    public string ValorC { get; private set; }
    public string ValorD { get; private set; }

    private ConversaoUTF8()
    {
        string tempPathdllPath;

        string dllName = Environment.Is64BitProcess ? "utf8_64.dll" : "utf8.dll";
        string resourceName = $"CartsysControlPanel.Assets.{dllName}";
        string tempPath = Path.Combine(Path.GetTempPath(), dllName);

        if (!File.Exists(tempPath))
        {
            using var stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(resourceName)
                ?? throw new FileNotFoundException($"Recurso '{resourceName}' não encontrado.");

            using var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write);
            stream.CopyTo(fs);
        }

        IntPtr hDll = LoadLibrary(tempPath);
        if (hDll == IntPtr.Zero)
            throw new Exception($"Não foi possível carregar '{dllName}'. Erro: {Marshal.GetLastWin32Error()}");

        ValorC = CallStringFunc(hDll, "LoadUTF8C");
        ValorD = CallStringFunc(hDll, "LoadUTF8D");

        FreeLibrary(hDll);
    }

    private string CallStringFunc(IntPtr dll, string function)
    {
        IntPtr proc = GetProcAddress(dll, function);
        if (proc == IntPtr.Zero)
            throw new Exception($"Função {function} não encontrada");

        var del = Marshal.GetDelegateForFunctionPointer<FuncIntPtr>(proc);

        IntPtr ptr = del();
        return Marshal.PtrToStringAnsi(ptr)?.Trim();
    }

    private delegate IntPtr FuncIntPtr();

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr LoadLibrary(string lpLibFileName);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool FreeLibrary(IntPtr hModule);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
}
