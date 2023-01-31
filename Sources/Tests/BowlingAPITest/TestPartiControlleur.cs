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

    }

   
}

