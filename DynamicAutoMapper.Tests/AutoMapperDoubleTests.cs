namespace DynamicAutoMapper.Tests;

public class AutoMapperDoubleTests
{
    private readonly IMapper _mapper;

    public AutoMapperDoubleTests()
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
        var entity = new DoubleModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = default,
        };

        // Act
        var viewModel = _mapper.Map<DoubleModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(-100_000f)]
    [InlineData(-1f)]
    [InlineData(0f)]
    [InlineData(1f)]
    [InlineData(100_000d)]
    [InlineData(-100_000d)]
    [InlineData(-1d)]
    [InlineData(0d)]
    [InlineData(1d)]
    [InlineData(100_000d)]
    public void Should_Map_EntityToViewModelWithValue(double parameterValue)
    {
        // Arrange
        var entity = new DoubleModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = parameterValue,
        };

        // Act
        var viewModel = _mapper.Map<DoubleModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new DoubleModelViewModel
        {
            Id = 1,
            Value = default,
        };

        // Act
        var entity = _mapper.Map<DoubleModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(-100_000f)]
    [InlineData(-1f)]
    [InlineData(0f)]
    [InlineData(1f)]
    [InlineData(100_000d)]
    [InlineData(-100_000d)]
    [InlineData(-1d)]
    [InlineData(0d)]
    [InlineData(1d)]
    [InlineData(100_000d)]
    public void Should_Map_ViewModelToEntitylWithValue(double parameterValue)
    {
        // Arrange
        var viewModel = new DoubleModelViewModel
        {
            Id = 1,
            Value = default,
        };

        // Act
        var entity = _mapper.Map<DoubleModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }
}
