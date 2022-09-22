using BasicModule;
using BasicModule.BasicClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnit_BasicModules_Tests
{
    public class LoggerFixture : IDisposable
    {
        public LoggerFixture()
        {
            // create text file.
        }
        public void Log(string msg)
        {
            // use the text to log
        }
        public void Dispose()
        {
            // Create report
            // send mail of report
            // delete the file
        }
    }

    public class FileCleanUpFixture : IDisposable
    {
        public FileManagement FileObj;
        public FileCleanUpFixture()
        {
            FileObj = new FileManagement();
        }

        public void Dispose()
        {
            File.Delete("C:\\Users\\elizabeths\\source\\test.txt");
        }

    }

    [CollectionDefinition("File CleanUp Collection")]
    public class FileCleanUpCollection : ICollectionFixture<FileCleanUpFixture>
    {

    }

    [Collection("File CleanUp Collection")]
    public class FileTests
    {
        private readonly FileCleanUpFixture fileCleanup;
        public FileTests(FileCleanUpFixture fileCleanup)
        {
            this.fileCleanup = fileCleanup;
        }

        [Fact]
        public void CreateFile_Test()
        {
            // Arrange

            // Act
            fileCleanup.FileObj.CreateFile("C:\\Users\\elizabeths\\source\\test.txt");

            // Assert
            Assert.True(File.Exists("C:\\Users\\elizabeths\\source\\test.txt"));
        }
    }
}
