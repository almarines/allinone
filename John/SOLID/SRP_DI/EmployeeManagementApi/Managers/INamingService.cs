using EmployeeManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Managers
{
    public interface INamingService
    {
        bool IsValid(string value);

        bool IsValid(int value);
    }
}
