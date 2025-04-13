namespace Nostalgia.Core.Test;

using Nostalgia.Core.Entities;

public class CosaTest
{
    [Fact]
    public void ConstructorShouldInitializeField()
    {
        // Act
        var cosa = new Cosa();

        // Assert
        Assert.Equal(0, cosa.Id);
        Assert.Equal(string.Empty, cosa.Name);
        Assert.Equal(string.Empty, cosa.Path);
        Assert.Equal(0, cosa.ScanId);
        Assert.Equal(string.Empty, cosa.Hash);
    }

    [Fact]
    public void PropertySettersShouldWork()
    {
        // Arrange
        var cosa = new Cosa();
        var path = "testPath";
        var id = 1;
        var hash = "testHash";

        // Act
        cosa.Path = path;
        cosa.ScanId = id;
        cosa.Hash = hash;

        // Assert
        Assert.Equal(path, cosa.Path);
        Assert.Equal(id, cosa.ScanId);
        Assert.Equal(hash, cosa.Hash);
    }
}