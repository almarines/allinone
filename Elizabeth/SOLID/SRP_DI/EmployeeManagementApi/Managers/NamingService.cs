namespace EmployeeManagementApi.Managers
{
    public class NamingService
    {
        public bool IsValid(string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }

    public interface INamingService
    {
        public bool IsValid(string value);
    }
}
