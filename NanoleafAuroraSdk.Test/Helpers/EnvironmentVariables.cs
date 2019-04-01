using System;

namespace NanoleafAuroraSdkNanoleafAuroraSdk.Test.Helpers
{
    public class EnvironmentVariables
    {
        public static string ApiKey =>
            Environment.GetEnvironmentVariable(EnvironmentVariableKeys.NANOLEAF_AURORA_API_KEY);

        public static string HostAddress =>
            Environment.GetEnvironmentVariable(EnvironmentVariableKeys.NANOLEAF_AURORA_HOST_ADDRESS);
    }
}
