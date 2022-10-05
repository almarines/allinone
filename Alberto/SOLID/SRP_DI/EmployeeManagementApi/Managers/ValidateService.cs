using EmployeeManagementApi.Dto;
using System;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Managers
{
    public interface IValidateService
    {
        public bool IsValid(string firtname, string lastname);
    }

    public class ValidateService : IValidateService
    {
        public bool IsValid(string firtname, string lastname)
        {

            bool isValid = false;
            if (!string.IsNullOrEmpty(firtname) || !string.IsNullOrEmpty(lastname) )
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
