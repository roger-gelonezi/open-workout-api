namespace Auth.Management.Api.Constants
{
    public static class DefaultLoginConstants
    {
        const string DefaultUserName = "DefaultUserName";
        const string DefaultUserNameValue = "rogeriogelonezi";
        const string DefaultPassword = "DefaultPassword";
        const string DefaultPasswordValue = "Sup3r$3cr3t";

        public static string GetDefaultUserName(IConfiguration configuration)
        {
            return configuration[DefaultUserName] ?? DefaultUserNameValue;
        }

        public static string GetDefaulPassword(IConfiguration configuration)
        {
            return configuration[DefaultPassword] ?? DefaultPasswordValue;
        }
    }
}

