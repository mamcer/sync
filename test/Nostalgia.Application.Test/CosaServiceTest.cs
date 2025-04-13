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

    [Fact]
    public void AddCosaShouldCallRepositoryAdd()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var cosaRepositoryMock = new Mock<ICosaRepository>();
        var cosaService = new CosaService(unitOfWorkMock.Object, cosaRepositoryMock.Object);
        var cosa = new Cosa { Id = 1, Name = "TestCosa" };

        // Act 
        _ = cosaService.AddCosa(cosa);

        // Assert
        cosaRepositoryMock.Verify(repo => repo.Add(cosa), Times.Once);
    }

    [Fact]
    public void AddCosaShouldCallSaveChanges()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var cosaRepositoryMock = new Mock<ICosaRepository>();
        var cosaService = new CosaService(unitOfWorkMock.Object, cosaRepositoryMock.Object);
        var cosa = new Cosa { Id = 1, Name = "TestCosa" };

        // Act 
        _ = cosaService.AddCosa(cosa);

        // Assert
        unitOfWorkMock.Verify(repo => repo.SaveChanges(), Times.Once);
    }

    [Fact]
    public void AddCosaShouldReturnCosa()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var cosaRepositoryMock = new Mock<ICosaRepository>();
        var cosaService = new CosaService(unitOfWorkMock.Object, cosaRepositoryMock.Object);
        var cosa = new Cosa { Id = 1, Name = "TestCosa" };
        Cosa actual;

        // Act 
        actual = cosaService.AddCosa(cosa);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(cosa, actual);
    }

    [Fact]
    public void GetAllCosasShouldReturnAllCosas()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var cosaRepositoryMock = new Mock<ICosaRepository>();
        cosaRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<Cosa> { new Cosa { Id = 1, Name = "TestCosa01" }, new Cosa { Id = 2, Name = "TestCosa02" } });
        var cosaService = new CosaService(unitOfWorkMock.Object, cosaRepositoryMock.Object);
        List<Cosa> cosas;

        // Act 
        cosas = cosaService.GetAllCosas().ToList();

        // Assert
        Assert.NotNull(cosas);
        Assert.Equal(2, cosas.Count);
        Assert.Equal("TestCosa02", cosas[1].Name);
    }

    [Fact]
    public void GetCosaCountShouldReturnCount()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var cosaRepositoryMock = new Mock<ICosaRepository>();
        cosaRepositoryMock.Setup(repo => repo.GetCount()).Returns(3);
        var cosaService = new CosaService(unitOfWorkMock.Object, cosaRepositoryMock.Object);
        int actual;

        // Act 
        actual = cosaService.GetCosaCount();

        // Assert
        Assert.Equal(3, actual);
    }
}