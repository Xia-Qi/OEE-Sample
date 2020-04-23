using System;

namespace Acme.Core.Basic
{
    public class Plugin : IPlugin
    {
        public static string GetName()
        {
            return "Basic";
        }
    }
}
