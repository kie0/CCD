using System;

namespace KW_45.LocCount
{
    public class EnvironmentProvider : IEnvironment
    {
        public string GetDir()
        {
            return Environment.GetCommandLineArgs()[1];
        }
    }
}