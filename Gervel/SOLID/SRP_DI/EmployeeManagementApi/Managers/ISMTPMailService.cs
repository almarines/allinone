using System.Threading.Tasks;

namespace EmployeeManagementApi.Managers {
	public interface IMailService {
		public bool IsValid(string value);
		public Task<bool> SendMail(string to, string subject, string body);
	}
}
