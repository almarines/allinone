namespace EmployeeManagementApi.Managers
{
    public class NamingService : INamingService
    {
        public bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            return true;
        }

        public bool IsValid(int value) => value > 0;
    }
}