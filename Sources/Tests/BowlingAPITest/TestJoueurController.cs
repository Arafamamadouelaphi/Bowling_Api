using DTOs;

namespace BowlingAPITest;

public  class TestController
{
    [Fact]
    public  async void Get_ShouldReturnOkResult()
    {
        // Arrange
        var mockService = new Mock<IJoueurService>();
        mockService.Setup(service => service.GetAll()).ReturnsAsync(new List<JoueurDTO>());
        var controller = new JoueurController(mockService.Object);
        
        // Act
        var result = await controller.Get();
        
        // Assert
        Assert.IsType<OkObjectResult>(result);
        
    }
    
    [Fact]
    public  async void Get_ShouldReturnAllItems()
    {
        // Arrange
        var testItems = GetTestItems();
        var mockService = new Mock<IJoueurService>();
        mockService.Setup(service => service.GetAll()).ReturnsAsync(testItems);
        var controller = new JoueurController(mockService.Object);
        
        // Act
        var result = await controller.Get();
        
        // Assert
        var okResult = result as OkObjectResult;
        var items = Assert.IsType<List<JoueurDTO>>(okResult.Value);
        Assert.Equal(2, items.Count);
    }

    private IEnumerable<JoueurDTO> GetTestItems()
    {
        
        var testItems = new List<JoueurDTO>();
        testItems.Add(new JoueurDTO {Pseudo = "Item1" });
        testItems.Add(new JoueurDTO { Pseudo = "Item2" });
        return testItems;
    }
    
    // [Fact]
    // public  async void GetById_ShouldReturnNotFound()
    // {
    //     // Arrange
    //     var mockService = new Mock<IJoueurService>();
    //     mockService.Setup(service => service.Get(1)).ReturnsAsync((JoueurDTO)null);
    //     var controller = new JoueurController(mockService.Object);
    //     
    //     // Act
    //     var result = await controller.Get(1);
    //     
    //     // Assert
    //     Assert.IsType<NotFoundResult>(result);
    // }
}