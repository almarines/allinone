using Core.Attributes;
using System;
using System.Diagnostics.Contracts;
using static BasicMocks.TrainingController;

namespace BasicMocks {
	[Service(Contract = typeof(IConsoleService))]
	public class ConsoleWrapperService : IConsoleService {
		public void WriteLine(string text) {
			Console.WriteLine(text);
		}
	}
}