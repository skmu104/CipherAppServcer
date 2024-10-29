using CipherAppServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherAppServerTests
{
    public class CaesarServiceTests
    {
        [Fact]
        public void CaesarService_TestDecryptSingleLowerCaseWord()
        {
            var service = new CaesarService();
            var key = "1";
            var message = "message";
            Assert.Equal("ldrrzfd", service.decrypt(message, key));
        }

        [Fact]
        public void CaesarService_TestDecryptLowerCaseSentence()
        {
            var service = new CaesarService();
            var key = "1";
            var message = "this is the message";
            Assert.Equal("sghr hr sgd ldrrzfd", service.decrypt(message, key));
        }

        [Fact]
        public void CaesarService_TestIgnoreNonAlphabeticalCharacters()
        {
            var service = new CaesarService();
            var key = "1";
            var message = "th1s is the m3ssage?!-.=+\n\r";
            Assert.Equal("sg1r hr sgd l3rrzfd?!-.=+\n\r", service.decrypt(message, key));
        }

        [Fact]
        public void CaesarService_TestDecryptSingleUpperCaseWord()
        {
            var service = new CaesarService();
            var key = "1";
            var message = "MESSAGE";
            Assert.Equal("LDRRZFD", service.decrypt(message, key));
        }

        [Fact]
        public void CaesarService_TestDecryptSentenceWithFullOverFlowKey()
        {
            var service = new CaesarService();
            var key = "26";
            var message = "this is the message";
            Assert.Equal("this is the message", service.decrypt(message, key));
        }

        [Fact]
        public void CaesarService_TestDecryptSentenceWithFullOverFlowKeyAndIncremented()
        {
            var service = new CaesarService();
            var key = "27";
            var message = "this is the message";
            Assert.Equal("sghr hr sgd ldrrzfd", service.decrypt(message, key));
        }

        [Fact]
        public void CaesarService_TestDecryptSentenceWithUpperAndLowerCharacters()
        {
            var service = new CaesarService();
            var key = "1";
            var message = "THIS is THE mesSaGe";
            Assert.Equal("SGHR hr SGD ldrRzFd", service.decrypt(message, key));
        }

        [Fact]
        public void CaesarService_TestEncryptSingleLowerCaseWord()
        {
            var service = new CaesarService();
            var key = "1";
            var message = "ldrrzfd";
            Assert.Equal("message", service.encrypt(message, key));
        }

        [Fact]
        public void CaesarService_ShouldThrowArgumentException_WhenKeyNotValid()
        {
            var service = new CaesarService();
            var key = "a1";
            var message = "message";
            Assert.Throws<ArgumentException>(() => service.decrypt(message, key));

        }
    }
}
