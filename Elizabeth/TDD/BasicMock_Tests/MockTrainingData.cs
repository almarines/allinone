using BasicMocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMock_Tests
{
    public class MockTrainingData : ITrainingData
    {
        public async Task<bool> Add(string name, string cost)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> Update(int id, string name)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(int id)
        {
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Training>> GetAllTrainings()
        {
            return await Task.FromResult(new List<Training>());
        }

        public void GetTranings(int id, out Training t)
        {
            throw new NotImplementedException();
        }

        Task ITrainingData.Update(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
