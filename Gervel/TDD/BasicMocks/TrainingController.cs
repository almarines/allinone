using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Core.Contracts;

namespace BasicMocks {
    public partial class TrainingController
    {
        private readonly ITrainingData _trainingData;

        public TrainingController(ITrainingData trainingData)
        {
            _trainingData = trainingData;
        }

        public async Task<IEnumerable<Training>> GetAllTrainings()
        {
            return await _trainingData.GetAllTrainings();
        }

        public async Task<bool> Add(string name, string cost, string mail)
        {
            var namingService = Container.Resolve<INamingService>();
            if (!namingService.Validate(name))
            {
                throw new InvalidOperationException();
            }

            var success = await _trainingData.Add(name, cost);

            if (success)
            {
                var smtpMailService = Container.Resolve<IMailService>();
                success = await smtpMailService.SendMail("test@gmail.com", mail, "welcome", "Welcome to .Net training");
            }

            return success;
        }

        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException();
            }

			var messageBoxWrapper = Container.Resolve<IMessageBox>();
			var dialogResult = messageBoxWrapper.Show("Confirm", "Do you want to delete");

            if (dialogResult == DialogResult.Yes)
            {
                var result = await _trainingData.Delete(id);
                return result;
            }

            return false;
        }

		public async Task<bool> Update(int id, string name) {
			// verification of inputs
			var namingService = Container.Resolve<INamingService>();
			if (!namingService.Validate(name)) {
				throw new InvalidOperationException();
			}

			// updating into DB
			var success = await _trainingData.Update(id, name);
			return success;
		}

		public async Task<bool> DeleteWithConsole(int id) {
			if (id <= 0) {
				throw new InvalidOperationException();
			}

			var consoleWrapperService = Container.Resolve<IConsoleService>();
			consoleWrapperService.WriteLine("before deleting Employee");

			var result = await _trainingData.Delete(id);

			consoleWrapperService.WriteLine("after deleting Employee");

			return result;
		}

        public void GetTraining(int id, out Training t) {
            _trainingData.GetTraining(id, out t);
		}
    }

}
