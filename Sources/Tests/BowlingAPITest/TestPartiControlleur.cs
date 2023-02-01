using DTOs;
using FluentAssertions;

namespace BowlingAPITest
{
	public class TestPartiControlleur
	{
        [Fact]
        public async void Get_ShouldReturnOkResult()
        {
            // Arrange
            var partie1 = new PartieDTO { Score=1 };
            var partie2 = new PartieDTO { Score = 2 };
            var parti = GetTestItems();
            var mockService = new Mock<IpartieService>();
            mockService.Setup(service => service.GetAll()).ReturnsAsync(parti);
            var controller = new PartieController(mockService.Object);

            // Act
            var result = await controller.Get() as OkObjectResult;
            var value = result.Value as List<PartieDTO>;

            // Assert
            result.Should().NotBeNull();
            value.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            value.Should().BeEquivalentTo(parti);

        }
        [Fact]
        public async void Get_ShouldReturnAllItems()
        {
            // Arrange
            var testItems = GetTestItems();
            var mockService = new Mock<IpartieService>();
            mockService.Setup(service => service.GetAll()).ReturnsAsync(testItems);
            var controller = new PartieController(mockService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = result as OkObjectResult;
            var items = Assert.IsType<List<PartieDTO>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

        private IEnumerable<PartieDTO> GetTestItems()
        {

            var testItems = new List<PartieDTO>();
            testItems.Add(new PartieDTO { Score = 1 });
            testItems.Add(new PartieDTO { Score = 2 });
            return testItems;
        }
        [Fact]
        public async Task Get_With_Invalid_Name_Should_Return_BadRequest()
        {
            // Arrange
            var PartieController = new PartieController(null);

            // Act
            var result = await PartieController.Get(null);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
            var badRequestResult = result as BadRequestObjectResult;
            badRequestResult.Value.Should().Be("Le score de la partie est obligatoire");
        }

        [Fact]
        public async Task Get_With_Valid_Name_Should_Return_Ok_With_partie()
        {
            // Arrange
            var parti = new PartieDTO { Id = 1, Score = 1 };
            var partiservicemock = new Mock<IpartieService>();
            partiservicemock.Setup(x => x.GetDataWithName("John Doe")).ReturnsAsync(parti);
            var particontrolleur = new PartieController(partiservicemock.Object);

            // Act
            var result = await particontrolleur.Get("John Doe");

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(parti);
        }

        //post
        [Fact]
        public async Task Put_With_Invalid_Joueur_Should_Return_BadRequest()
        {
            // Arrange
            var joueurController = new JoueurController(null);

            // Act
            var result = await joueurController.Put(null, null);

            // Assert
            result.Should().BeOfType<ActionResult<JoueurDTO>>();
            var actionResult = result as ActionResult<JoueurDTO>;
            actionResult.Result.Should().BeOfType<BadRequestObjectResult>();
            var badRequestResult = actionResult.Result as BadRequestObjectResult;
            badRequestResult.Value.Should().Be("Le joueur est obligatoire");
        }

        [Fact]
        public async Task Put_With_Valid_parti_Should_Return_Ok_With_Joueur()
        {
            // Arrange
            var parti = new PartieDTO { Id = 1, Score = 1 };
            var partiServiceMock = new Mock<IpartieService>();
            partiServiceMock.Setup(x => x.Update(parti)).ReturnsAsync(true);
            var partiControlleur = new PartieController(partiServiceMock.Object);

            // Act
            var result = await partiControlleur.Put(parti.Id, parti);

            // Assert
            result.Should().BeOfType<ActionResult<PartieDTO>>();
            var actionResult = result as ActionResult<PartieDTO>;
            actionResult.Result.Should().BeOfType<OkObjectResult>();
        }

        //test Get_ShouldReturnNotFound
        [Fact]
        public async Task Get_ShouldReturnNotFound()
        {
            // Arrange
            var mockService = new Mock<IpartieService>();
            mockService.Setup(service => service.GetAll()).ReturnsAsync((List<PartieDTO>)null);
            var controller = new PartieController(mockService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Get_White_Name_ShouldReturnNotFound()
        {
            // Arrange

            var partie1 = new PartieDTO { Score = 1 };
            var mockService = new Mock<IpartieService>();
            mockService.Setup(service => service.GetDataWithName("Jane Smith")).ReturnsAsync(partie1);
            var controller = new PartieController(mockService.Object);

            // Act
            var result = await controller.Get("John Doe");

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }
        [Fact]
        public async Task Get_ShouldReturnInternalServerError()
        {
            // Arrange
            var mockService = new Mock<IpartieService>();
            mockService.Setup(service => service.GetAll()).ThrowsAsync(new Exception());
            var controller = new PartieController(mockService.Object);

            // Act
            var result = await controller.Get() as ObjectResult;

            // Assert
            result.Should().BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(500);
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
            badRequestResult.Value.Should().Be("La partie est obligatoire");
        }

        


    }


}

