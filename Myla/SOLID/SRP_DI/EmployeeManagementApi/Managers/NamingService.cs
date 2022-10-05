namespace EmployeeManagementApi.Managers
{
    public class NamingService
    {
        public bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }



            return true;
        }
    }
}
