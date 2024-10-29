using CipherAppServer.Enums;
using CipherAppServer.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace CipherAppServerTests;
public class CipherServiceFactoryTests
{
    [Fact]
    public void GetCipherService_ShouldReturnVigenereService_WhenCipherTypeIsVigenere()
    {
        // Arrange
        var vigenereServiceMock = new Mock<VigenereService>();
        var serviceProviderMock = new Mock<IServiceProvider>();

        serviceProviderMock
            .Setup(sp => sp.GetService(typeof(VigenereService)))
            .Returns(vigenereServiceMock.Object);

        var factory = new CipherServiceFactory(serviceProviderMock.Object);

        // Act
        var service = factory.GetCipherService(CipherType.vigenere);

        // Assert
        Assert.IsAssignableFrom<VigenereService>(service);
    }

    [Fact]
    public void GetCipherService_ShouldReturnCaesarService_WhenCipherTypeIsCaesar()
    {
        // Arrange
        var caesarServiceMock = new Mock<CaesarService>();
        var serviceProviderMock = new Mock<IServiceProvider>();

        serviceProviderMock
            .Setup(sp => sp.GetService(typeof(CaesarService)))
            .Returns(caesarServiceMock.Object);

        var factory = new CipherServiceFactory(serviceProviderMock.Object);

        // Act
        var service = factory.GetCipherService(CipherType.caesar);

        // Assert
        Assert.IsAssignableFrom<CaesarService>(service);
    }

    [Fact]
    public void GetCipherService_ShouldThrowArgumentException_WhenCipherTypeIsInvalid()
    {
        // Arrange
        var serviceProviderMock = new Mock<IServiceProvider>();
        var factory = new CipherServiceFactory(serviceProviderMock.Object);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => factory.GetCipherService((CipherType)999));
    }
}
