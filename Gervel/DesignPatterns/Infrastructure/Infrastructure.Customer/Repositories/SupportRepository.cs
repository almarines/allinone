using Domain.Customer.Models;
using Domain.Customer.Repositories;
using LiteDB;

namespace Infrastructure.Customer.Repositories {
	public class SupportRepository : ISupportRepository {
		private readonly ILiteDBContext _context;

		public SupportRepository(ILiteDBContext context) {
			_context = context;
		}

		public Support GetSupportByCustomerId(int customerId) {
			return _context.GetSupportByCustomerId(customerId);
		}

		public BsonValue InsertSupport(Support support) {
			return _context.InsertSupport(support);
		}
	}
}
