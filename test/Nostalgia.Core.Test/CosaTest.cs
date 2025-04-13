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
}