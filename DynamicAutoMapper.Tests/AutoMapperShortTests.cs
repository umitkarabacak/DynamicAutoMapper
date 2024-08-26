namespace DynamicAutoMapper.Tests;

public class AutoMapperShortTests
{
    private readonly IMapper _mapper;

    public AutoMapperShortTests()
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
        var entity = new ShortModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = default,
        };

        // Act
        var viewModel = _mapper.Map<ShortModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(short.MinValue)]
    [InlineData(0)]
    [InlineData(short.MaxValue)]
    public void Should_Map_EntityToViewModelWithValue(short parameterValue)
    {
        // Arrange
        var entity = new ShortModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = parameterValue,
        };

        // Act
        var viewModel = _mapper.Map<ShortModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new ShortModelViewModel
        {
            Id = 1,
            Value = default,
        };

        // Act
        var entity = _mapper.Map<ShortModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(short.MinValue)]
    [InlineData(0)]
    [InlineData(short.MaxValue)]
    public void Should_Map_ViewModelToEntitylWithValue(short parameterValue)
    {
        // Arrange
        var viewModel = new ShortModelViewModel
        {
            Id = 1,
            Value = parameterValue,
        };

        // Act
        var entity = _mapper.Map<ShortModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }
}
