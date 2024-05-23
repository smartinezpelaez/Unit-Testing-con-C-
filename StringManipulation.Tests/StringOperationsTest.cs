using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringManipulation.Tests
{
    public class StringOperationsTest
    {
        [Fact(Skip ="Esta prueba no es valida en este momento, TICKECT-001")]
        public void ConcatenateStrings()
        {
           // Arrange
           var strOperation = new StringOperations();
           
           // Act 
           var result = strOperation.ConcatenateStrings("Hello", "World");
           
           // Assert 
           Assert.NotNull(result);
           Assert.NotEmpty(result);
           Assert.Equal("Hello World", result);

        }

        [Fact]
        public void IsPalindrome_True() 
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.IsPalindrome("ama");

            // Assert 
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.IsPalindrome("Hello");

            // Assert 
            Assert.False(result);
        }

        [Fact]
        public void RemoveWhitespace() 
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.RemoveWhitespace("Hola mundo ");

            // Assert 
            Assert.NotNull(result);            
            Assert.DoesNotContain(" ", result);
        }

        [Fact]
        public  void QuantintyInWords() 
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.QuantintyInWords("Hola", 10);

            // Assert 
            Assert.NotNull(result);
            Assert.StartsWith("ten", result);
            Assert.Contains("Hola", result);            
        }

        [Fact]
        public void GetStringLenght_Exception() 
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            //var result = strOperation.GetStringLength("");

            // Assert
            Assert.ThrowsAny<ArgumentNullException>(()=> strOperation.GetStringLength(null));

        }

        [Fact]
        public void TruncateString_Exception()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            //var result = strOperation.GetStringLength("");

            // Assert
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strOperation.TruncateString("platzy",-2));
        }

        [Theory]// Permite que el test tome valores
        [InlineData("V", 5)]// Sirve para asignar valores a los argumentos del test
        [InlineData("III", 3)]
        [InlineData("X", 10)]
        public void FromRomanToNumber(string romanNumber, int expeted) 
        {
            var strOperation = new StringOperations();
            var result = strOperation.FromRomanToNumber(romanNumber);
            
            Assert.Equal(expeted, result);
        }

        [Fact]
        public void CountOccurrences() 
        {
            // Arrange
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperation = new StringOperations(mockLogger.Object);
           

            // Act
            var result = strOperation.CountOccurrences("Hola lola", 'l');

            // Assert            
            Assert.Equal(3, result);
        }

        [Fact]
        public void ReadFile() 
        {
            // Arrange
            var strOperation = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            
            // Act

            //mockFileReader.Setup(p => p.ReadString("file.txt")).Returns("Reading file");//Para un archivo especifico
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file");//Para un archivo especifico

            var result = strOperation.ReadFile(mockFileReader.Object, "file3.txt");

            // Assert
            Assert.Equal("Reading file", result);       
        }
    }
}
