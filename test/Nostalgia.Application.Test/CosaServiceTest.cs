namespace Nostalgia.Application.Test;

using Moq;
using Nostalgia.Application;
using Nostalgia.Core.Entities;
using Nostalgia.Core.Interfaces;

public class CosaServiceTest
{
    [Fact]
    public void ConstructorShouldInitializeProperties()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var cosaRepositoryMock = new Mock<ICosaRepository>();
        
        // Act
        var cosaService = new CosaService(unitOfWorkMock.Object, cosaRepositoryMock.Object);
        
        // Assert
        Assert.NotNull(cosaService.UnitOfWork);
        Assert.NotNull(cosaService.CosaRepository);
    }

    [Fact]
    public void AddCosaShouldThrowArgumentNullExceptionWhenCosaIsNull()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var cosaRepositoryMock = new Mock<ICosaRepository>();
        var cosaService = new CosaService(unitOfWorkMock.Object, cosaRepositoryMock.Object);

        // Act & Assert
        _ = Assert.Throws<ArgumentNullException>(() => cosaService.AddCosa(default));
    }
}