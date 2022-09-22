using Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicMocks {
    public class Training
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Cost { get; set; }
    }

    public interface ITrainingData
    {

        Task<bool> Add(string name, string cost);

        Task<bool> Delete(int id);
        Task<IEnumerable<Training>> GetAllTrainings();
    }

    public class TrainingDataContext : ITrainingData
    {
        private static IList<Training> list = new List<Training>();

        public TrainingDataContext()
        {
            list.Add(new Training() { Id = 1, Name = ". Net Core", Cost = "100$" });
        }
        public async Task<bool> Add(string name, string cost)
        {
            list.Add(new Training() { Id = list.Count + 1, Name = name, Cost = cost });
            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(int id)
        {
            list.Remove(list.First(s => s.Id == id));
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Training>> GetAllTrainings()
        {
            return await Task.FromResult(list);
        }
    }

    public class NamingService : INamingService
    {
        public bool Validate(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                return false;
            }          

            return true;
        }
    }
}
