using Core;
using Core.Contracts;
using NSubstitute;
using System.Diagnostics.CodeAnalysis;
using static BasicMocks.TrainingController;

namespace BasicMocks.Tests {
	[ExcludeFromCodeCoverage]
	public class TrainingControllerTests {
		[Fact]
		public async void TrainingController_Add_True_True_True_Tests() {
			// Arrange
			Container.Cleanup(); // Temporary solution to clear singleton for each tests

			// naming service
			var namingService = Substitute.For<INamingService>();
			namingService.Validate(Arg.Any<string>()).Returns(true);
			Container.AddSingelten<INamingService>(namingService);

			// training DB context
			var mockTrainingData = Substitute.For<ITrainingData>();
			mockTrainingData.Add(Arg.Any<string>(), Arg.Any<string>()).Returns(Task.FromResult(true));


			// SMTP mail service
			var stmpMockObj = Substitute.For<IMailService>();
			stmpMockObj.SendMail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(Task.FromResult(true));
			Container.AddSingelten<IMailService>(stmpMockObj);

			var controller = new TrainingController(mockTrainingData);

			// Act
			var result = await controller.Add("SOLID", "200 $", "trainer@gmail.com");

			// Assert
			Assert.True(result);
			namingService.Received().Validate(Arg.Any<string>());
			await mockTrainingData.Received().Add(Arg.Any<string>(), Arg.Any<string>());
			await stmpMockObj.Received().SendMail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
		}

		[Fact]
		public async void TrainingController_Add_True_True_True2_Tests() {
			// Arrange
			Container.Cleanup(); // Temporary solution to clear singleton for each tests

			// naming service
			var namingService = Substitute.For<INamingService>();
			namingService.Validate(Arg.Any<string>()).Returns(true);
			Container.AddSingelten<INamingService>(namingService);

			// training DB context
			bool addhappened = false;
			var mockTrainingData = Substitute.For<ITrainingData>();
			mockTrainingData.Add(Arg.Any<string>(), Arg.Any<string>()).Returns((c) => {
				addhappened = true;
				return Task.FromResult(true);
			});


			// SMTP mail service
			var stmpMockObj = Substitute.For<IMailService>();
			stmpMockObj.SendMail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(Task.FromResult(true));
			Container.AddSingelten<IMailService>(stmpMockObj);

			var controller = new TrainingController(mockTrainingData);

			// Act
			var result = await controller.Add("SOLID", "200 $", "trainer@gmail.com");

			// Assert
			Assert.True(result);
			Assert.True(addhappened);
		}

		[Fact]
		public async void TrainingController_Add__True_True_False_Tests() {
			// Arrange
			Container.Cleanup(); // Temporary solution to clear singleton for each tests

			var namingService = Substitute.For<INamingService>();
			namingService.Validate(Arg.Any<string>()).Returns(true);
			Container.AddSingelten<INamingService>(namingService);

			var mockTrainingData = Substitute.For<ITrainingData>();
			mockTrainingData.Add(Arg.Any<string>(), Arg.Any<string>()).Returns(Task.FromResult(true));

			var controller = new TrainingController(mockTrainingData);
			var stmpMockObj = Substitute.For<IMailService>();
			stmpMockObj.SendMail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(Task.FromResult(false));
			Container.AddSingelten<IMailService>(stmpMockObj);

			// Act
			var result = await controller.Add("SOLID", "200 $", "trainer@gmail.com");

			// Assert
			Assert.False(result);
		}

		[Fact]
		public async void TrainingController_Add_True_False_False_Tests() {
			// Arrange
			Container.Cleanup(); // Temporary solution to clear singleton for each tests

			var namingService = Substitute.For<INamingService>();
			namingService.Validate(Arg.Any<string>()).Returns(true);
			Container.AddSingelten<INamingService>(namingService);

			var mockTrainingData = Substitute.For<ITrainingData>();
			mockTrainingData.Add("SOLID", "200 $").Returns(Task.FromResult(false));
			var controller = new TrainingController(mockTrainingData);
			var stmpMockObj = Substitute.For<IMailService>();
			stmpMockObj.SendMail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(Task.FromResult(false));
			Container.AddSingelten<IMailService>(stmpMockObj);

			// Act
			var result = await controller.Add("SOLID", "200 $", "trainer@gmail.com");

			// Assert
			var allTrainings = await controller.GetAllTrainings();
			//Assert.Single(allTrainings);
			Assert.False(result);
			await stmpMockObj.DidNotReceive().SendMail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
		}

		[Fact]
		public void TrainingController_Add_False_XXX_Tests() {
			// Arrange
			Container.Cleanup(); // Temporary solution to clear singleton for each tests

			var namingService = Substitute.For<INamingService>();
			namingService.Validate(Arg.Any<string>()).Returns(false);
			Container.AddSingelten<INamingService>(namingService);

			var mockTrainingData = Substitute.For<ITrainingData>();
			mockTrainingData.Add("SOLID", "200 $").Returns(Task.FromResult(false));
			var controller = new TrainingController(mockTrainingData);

			// Act
			Func<Task> result = async () => await controller.Add("SOLID", "200 $", "trainer@gmail.com");

			// Assert
			Assert.ThrowsAsync<InvalidOperationException>(result);
		}

		#region Tests for TrainingController.Delete()

		[Theory]
		[InlineData(-1)]
		[InlineData(0)]
		public async Task TrainingController_Remove_InvalidID(int invalidID) {
			Container.Cleanup(); // Temporary solution to clear singleton for each tests

			var mockTrainingData = Substitute.For<ITrainingData>();
			var mockMessageBox = Substitute.For<IMessageBox>();
			Container.AddSingelten<IMessageBox>(mockMessageBox);

			var controller = new TrainingController(mockTrainingData);

			var removeAction = () => controller.Delete(invalidID);

			await Assert.ThrowsAsync<InvalidOperationException>(removeAction);
			mockMessageBox.DidNotReceive().Show(Arg.Any<string>(), Arg.Any<string>());
			await mockTrainingData.DidNotReceive().Delete(Arg.Any<int>());
		}

		[Fact]
		public async Task TrainingController_Remove_ValidID_ConfirmDelete_TrainingDataResult_True() {
			Container.Cleanup(); // Temporary solution to clear singleton for each tests

			var mockTrainingData = Substitute.For<ITrainingData>();
			mockTrainingData.Delete(Arg.Any<int>()).Returns(Task.FromResult(true));

			var mockMessageBox = Substitute.For<IMessageBox>();
			mockMessageBox.Show(Arg.Any<string>(), Arg.Any<string>()).Returns(DialogResult.Yes);
			Container.AddSingelten<IMessageBox>(mockMessageBox);

			var controller = new TrainingController(mockTrainingData);

			var deleteResult = await controller.Delete(1);

			Assert.True(deleteResult);
			mockMessageBox.Received().Show(Arg.Any<string>(), Arg.Any<string>());
			await mockTrainingData.Received().Delete(Arg.Any<int>());
		}

		[Fact]
		public async Task TrainingController_Remove_ValidID_ConfirmDelete_TrainingDataResult_False() {
			Container.Cleanup(); // Temporary solution to clear singleton for each tests

			var mockTrainingData = Substitute.For<ITrainingData>();
			mockTrainingData.Delete(Arg.Any<int>()).Returns(Task.FromResult(false));

			var mockMessageBox = Substitute.For<IMessageBox>();
			mockMessageBox.Show(Arg.Any<string>(), Arg.Any<string>()).Returns(DialogResult.Yes);
			Container.AddSingelten<IMessageBox>(mockMessageBox);

			var controller = new TrainingController(mockTrainingData);

			var deleteResult = await controller.Delete(1);

			Assert.False(deleteResult);
			mockMessageBox.Received().Show(Arg.Any<string>(), Arg.Any<string>());
			await mockTrainingData.Received().Delete(Arg.Any<int>());
		}

		[Theory]
		[InlineData(DialogResult.None)]
		[InlineData(DialogResult.No)]
		[InlineData(DialogResult.Cancel)]
		[InlineData(DialogResult.Abort)]
		[InlineData(DialogResult.Retry)]
		[InlineData(DialogResult.Ignore)]
		public async Task TrainingController_Remove_ValidID_DontConfirmDelete(DialogResult dialogResult) {
			Container.Cleanup(); // Temporary solution to clear singleton for each tests

			var mockTrainingData = Substitute.For<ITrainingData>();
			var controller = new TrainingController(mockTrainingData);

			var mockMessageBox = Substitute.For<IMessageBox>();
			mockMessageBox.Show(Arg.Any<string>(), Arg.Any<string>()).Returns(dialogResult);
			Container.AddSingelten<IMessageBox>(mockMessageBox);

			var deleteResult = await controller.Delete(1);

			Assert.False(deleteResult);
			mockMessageBox.Received().Show(Arg.Any<string>(), Arg.Any<string>());
			await mockTrainingData.DidNotReceive().Delete(Arg.Any<int>());
		}

		// NOTE:
		// In order to use System.Windows.Forms in .NET 6 project,
		// update BasicMocks.Tests.csproj by adding the config from the article below:
		// https://stackoverflow.com/questions/38460253/how-to-use-system-windows-forms-in-net-core-class-library

		#endregion


		#region Tests for TrainingController.DeleteWithConsole()
		[Fact]
		public async void DeleteWithConsole_Tests() {
			Container.Cleanup(); // Temporary solution to clear singleton for each tests

			var mockTrainingData = Substitute.For<ITrainingData>();
			mockTrainingData.Delete(Arg.Any<int>()).Returns(Task.FromResult(true));

			var mockMessageBox = Substitute.For<IConsoleService>();
			Container.AddSingelten<IConsoleService>(mockMessageBox);

			var controller = new TrainingController(mockTrainingData);

			var deleteResult = await controller.DeleteWithConsole(1);

			Assert.True(deleteResult);
			mockMessageBox.Received().WriteLine("before deleting Employee");
			await mockTrainingData.Received().Delete(Arg.Any<int>());
			mockMessageBox.Received().WriteLine("after deleting Employee");
		}
		#endregion

		#region Tests for TrainingController.Update()
		// T.B.D
		#endregion
	}
}
