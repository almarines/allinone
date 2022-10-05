namespace EmployeeManagementApi.Managers
{
    public interface INamingService
    {
        bool IsValid(string value);

        bool IsValid(int value);
    }
}