namespace ClinicManagementInternship.Utils
{
    public static class PasswordHash
    {
        public static string CreatePasswordHash(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
            return hashedPassword;
        }

        public static bool ComparePassword(string password, string storedHashedPassword)
        {
            bool passwordMatches = BCrypt.Net.BCrypt.Verify(password, storedHashedPassword);
            return passwordMatches;
        }
    }
}
