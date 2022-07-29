using Core.Attributes;
using Core.Contracts;
using System;

namespace MailService.Azure {
  [Service(Contract = typeof(ILoggingService))]
  public class AzLogger: ILoggingService {
    public string Name => "AzLogger";

    public void Log(string message) {
      Console.WriteLine(message);
    }
  }
}
