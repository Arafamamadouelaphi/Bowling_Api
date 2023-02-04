using DTOs;

namespace BowlingAPITest;

public class TestController
{
    [Fact]
    public async void Get_ShouldReturnOkResult()
    {
        // Arrange
        var joueur1 = new JoueurDTO { Pseudo = "John Doe" };
        var joueur2 = new JoueurDTO { Pseudo = "Jane Smith" };
        var joueurs = GetTestItems();
        var mockService = new Mock<IJoueurService>();
        mockService.Setup(service => service.GetAll()).ReturnsAsync(joueurs);
        var controller = new JoueurController(mockService.Object);

        // Act
        var result = await controller.Get() as OkObjectResult;
        var value = result.Value as List<JoueurDTO>;

        // Assert
        result.Should().NotBeNull();
        value.Should().NotBeNull();
        result.StatusCode.Should().Be(200);
        value.Should().BeEquivalentTo(joueurs);
    }

    [Fact]
    public async void Get_ShouldReturnAllItems()
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
        testItems.Add(new JoueurDTO { Pseudo = "Item1" });
        testItems.Add(new JoueurDTO { Pseudo = "Item2" });
        return testItems;
    }

    [Fact]
    public async Task Get_With_Invalid_Name_Should_Return_BadRequest()
    {
        // Arrange
        var joueurController = new JoueurController(null);

        // Act
        var result = await joueurController.Get(null);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var badRequestResult = result as BadRequestObjectResult;
        badRequestResult.Value.Should().Be("Le nom du joueur est obligatoire");
    }

    [Fact]
    public async Task Get_With_Valid_Name_Should_Return_Ok_With_Joueur()
    {
        // Arrange
        var joueur = new JoueurDTO { Id = 1, Pseudo = "John Doe" };
        var joueurServiceMock = new Mock<IJoueurService>();
        joueurServiceMock.Setup(x => x.GetDataWithName("John Doe")).ReturnsAsync(joueur);
        var joueurController = new JoueurController(joueurServiceMock.Object);

        // Act
        var result = await joueurController.Get("John Doe");

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult.Value.Should().BeEquivalentTo(joueur);
    }

    [Fact]
    public async Task Post_With_Invalid_Joueur_Should_Return_BadRequest()
    {
        // Arrange
        var joueurController = new JoueurController(null);

        // Act
        var result = await joueurController.Post(null);

        // Assert
        result.Should().BeOfType<ActionResult<JoueurDTO>>();
        var actionResult = result as ActionResult<JoueurDTO>;
        actionResult.Result.Should().BeOfType<BadRequestObjectResult>();
        var badRequestResult = actionResult.Result as BadRequestObjectResult;
        badRequestResult.Value.Should().Be("Le joueur est obligatoire");
    }

    [Fact]
    public async Task Post_With_Valid_Joueur_Should_Return_Created_With_Joueur()
    {
        // Arrange
        var joueur = new JoueurDTO {  Pseudo = "John Doe" };
        var joueurServiceMock = new Mock<IJoueurService>();
        joueurServiceMock.Setup(x => x.Add(joueur)).ReturnsAsync(joueur);
        var joueurController = new JoueurController(joueurServiceMock.Object);

        // Act
        var result = await joueurController.Post(joueur);

        // Assert
        result.Should().BeOfType<ActionResult<JoueurDTO>>();
        var actionResult = result as ActionResult<JoueurDTO>;
        actionResult.Result.Should().BeOfType<CreatedAtActionResult>();
        var createdResult = actionResult.Result as CreatedAtActionResult;
        createdResult.Value.Should().BeEquivalentTo(joueur);
        Assert.Equal(createdResult.Value, joueur);
    }

    [Fact]
    public async Task Put_With_Invalid_Joueur_Should_Return_BadRequest()
    {
        // Arrange
        var joueurController = new JoueurController(null);

        // Act
        var result = await joueurController.Put(0, null);

        // Assert
        result.Should().BeOfType<ActionResult<JoueurDTO>>();
        var actionResult = result as ActionResult<JoueurDTO>;
        actionResult.Result.Should().BeOfType<BadRequestObjectResult>();
        var badRequestResult = actionResult.Result as BadRequestObjectResult;
        badRequestResult.Value.Should().Be("Le joueur est obligatoire");
    }

    [Fact]
    public async Task Put_With_Valid_Joueur_Should_Return_Ok_With_Joueur()
    {
        // Arrange
        var joueur = new JoueurDTO { Id = 1, Pseudo = "John Doe" };
        var joueurServiceMock = new Mock<IJoueurService>();
        joueurServiceMock.Setup(x => x.Update(joueur.Id,joueur)).ReturnsAsync(true);
        var joueurController = new JoueurController(joueurServiceMock.Object);

        // Act
        var result = await joueurController.Put(joueur.Id, joueur);

        // Assert
        result.Should().BeOfType<ActionResult<JoueurDTO>>();
        var actionResult = result as ActionResult<JoueurDTO>;
        actionResult.Result.Should().BeOfType<OkObjectResult>();
    }

    //test Get_ShouldReturnNotFound
    [Fact]
    public async Task Get_ShouldReturnNotFound()
    {
        // Arrange
        var mockService = new Mock<IJoueurService>();
        mockService.Setup(service => service.GetAll()).ReturnsAsync((List<JoueurDTO>)null);
        var controller = new JoueurController(mockService.Object);

        // Act
        var result = await controller.Get();

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task Get_White_Name_ShouldReturnNotFound()
    {
        // Arrange

        var joueur2 = new JoueurDTO { Pseudo = "Jane Smith" };
        var mockService = new Mock<IJoueurService>();
        mockService.Setup(service => service.GetDataWithName("Jane Smith")).ReturnsAsync(joueur2);
        var controller = new JoueurController(mockService.Object);

        // Act
        var result = await controller.Get("John Doe");

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }

    //test Get_ShouldReturn InternalServerError
    [Fact]
    public async Task Get_ShouldReturnInternalServerError()
    {
        // Arrange
        var mockService = new Mock<IJoueurService>();
        mockService.Setup(service => service.GetAll()).ThrowsAsync(new Exception());
        var controller = new JoueurController(mockService.Object);

        // Act
        var result = await controller.Get() as ObjectResult;

        // Assert
        result.Should().BeOfType<ObjectResult>();
        result.StatusCode.Should().Be(500);
    }
}