namespace DynamicAutoMapper.Tests;

public class AutoMapperUintTests
{
    private readonly IMapper _mapper;

    public AutoMapperUintTests()
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
        var entity = new UintModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = default,
        };

        // Act
        var viewModel = _mapper.Map<UintModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(uint.MinValue)]
    [InlineData(0)]
    [InlineData(uint.MaxValue)]
    public void Should_Map_EntityToViewModelWithValue(uint parameterValue)
    {
        // Arrange
        var entity = new UintModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = parameterValue,
        };

        // Act
        var viewModel = _mapper.Map<UintModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new UintModelViewModel
        {
            Id = 1,
            Value = default,
        };

        // Act
        var entity = _mapper.Map<UintModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(uint.MinValue)]
    [InlineData(0)]
    [InlineData(uint.MaxValue)]
    public void Should_Map_ViewModelToEntitylWithValue(uint parameterValue)
    {
        // Arrange
        var viewModel = new UintModelViewModel
        {
            Id = 1,
            Value = parameterValue,
        };

        // Act
        var entity = _mapper.Map<UintModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }
}
