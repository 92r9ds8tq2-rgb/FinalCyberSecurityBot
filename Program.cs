using System;
using System.Windows.Forms;

namespace FinalCyberSecurityBot
{
internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        System.Reflection.ConstructorInfo parameterlessCtor = null;
        foreach (var ctor in typeof(Form1).GetConstructors())
        {
            if (ctor.GetParameters().Length == 0)
            {
                parameterlessCtor = ctor;
                break;
            }
        }

        if (parameterlessCtor is null)
        {
            throw new InvalidOperationException("No public parameterless constructor found for Form1.");
        }

        Application.Run((Form)parameterlessCtor.Invoke(null));
    }
}
}
