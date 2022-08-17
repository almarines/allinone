using Domain.Customer.Models;
using LiteDB;

namespace Domain.Customer.Repositories {
	public interface ISupportRepository {
		BsonValue InsertSupport(Support support);
		Support GetSupportByCustomerId(int customerId);
	}
}
