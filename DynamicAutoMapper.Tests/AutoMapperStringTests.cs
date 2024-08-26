namespace DynamicAutoMapper.Tests;

public class AutoMapperStringTests
{
    private readonly IMapper _mapper;

    public AutoMapperStringTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DynamicProfile>();
        });

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Should_Map_EntityToViewModelDefaultValue()
    {
        // Arrange
        var entity = new StringModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = string.Empty,
        };

        // Act
        var viewModel = _mapper.Map<StringModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("ÜmİT")]
    [InlineData("ÜMİT KARABACAK")]
    public void Should_Map_EntityToViewModelWithValue(string parameterValue)
    {
        // Arrange
        var entity = new StringModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = parameterValue,
        };

        // Act
        var viewModel = _mapper.Map<StringModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new StringModelViewModel
        {
            Id = 1,
            Value = string.Empty,
        };

        // Act
        var entity = _mapper.Map<StringModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("ÜmİT")]
    [InlineData("ÜMİT KARABACAK")]
    public void Should_Map_ViewModelToEntitylWithValue(string parameterValue)
    {
        // Arrange
        var viewModel = new StringModelViewModel
        {
            Id = 1,
            Value = parameterValue,
        };

        // Act
        var entity = _mapper.Map<StringModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }
}
