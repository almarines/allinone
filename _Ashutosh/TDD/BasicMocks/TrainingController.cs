using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Core.Contracts;

namespace BasicMocks
{
    public class TrainingController
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
                //var smtpMailService = new SMTPMailService();
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

            var dialogResult = MessageBox.Show("Confirm", "Do you want to delete");
            if (dialogResult == DialogResult.Yes)
            {
                var result = await _trainingData.Delete(id);
                return result;
            }

            return false;
        }
    }
}
