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
        [Fact]
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
    }
}
