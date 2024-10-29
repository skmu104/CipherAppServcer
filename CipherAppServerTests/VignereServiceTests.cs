using CipherAppServer.Services;

namespace CipherAppServerTests
{
    public class VignereServiceTests
    {
        [Fact]
        public void VigenereService_TestDecryptSingleLowerCaseWord()
        {
            var service = new VigenereService();
            var key = "key";
            var message = "message";
            Assert.Equal("cauiwiu", service.decrypt(message, key));
        }
        [Fact]
        public void VigenereService_TestDecryptLowerCaseSentence()
        {
            var service = new VigenereService();
            var key = "key";
            var message = "this is the message";
            Assert.Equal("jdki eu jdg cauiwiu", service.decrypt(message, key));
        }

        [Fact]
        public void VigenereService_TestIgnoreNonAlphabeticalCharacters()
        {
            var service = new VigenereService();
            var key = "key";
            var message = "th1s is the m3ssage?!-.=+\n\r";
            Assert.Equal("jd1u yo vxa o3iocwa?!-.=+\n\r", service.decrypt(message, key));
        }

        [Fact]
        public void VigenereService_TestDecryptSingleUpperCaseWord()
        {
            var service = new VigenereService();
            var key = "key";
            var message = "MESSAGE";
            Assert.Equal("CAUIWIU", service.decrypt(message, key));
        }

        [Fact]
        public void VigenereService_TestDecryptSentenceWithUpperAndLowerCharacters()
        {
            var service = new VigenereService();
            var key = "key";
            var message = "THIS is THE mesSaGe";
            Assert.Equal("JDKI eu JDG cauIwIu", service.decrypt(message, key));
        }

        [Fact]
        public void VigenereService_TestEncryptSingleLowerCaseWord()
        {
            var service = new VigenereService();
            var key = "key";
            var message = "cauiwiu";
            Assert.Equal("message", service.encrypt(message, key));
        }
    }
}