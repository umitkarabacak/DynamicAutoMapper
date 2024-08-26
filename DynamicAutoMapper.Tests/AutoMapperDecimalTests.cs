namespace DynamicAutoMapper.Tests;

public class AutoMapperDecimalTests
{
    private readonly IMapper _mapper;

    public AutoMapperDecimalTests()
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
        var entity = new DecimalModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = default,
        };

        // Act
        var viewModel = _mapper.Map<DecimalModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(-100_000.00)]
    [InlineData(-1.00)]
    [InlineData(0.00)]
    [InlineData(1.00d)]
    [InlineData(100_000.00)]
    public void Should_Map_EntityToViewModelWithValue(decimal parameterValue)
    {
        // Arrange
        var entity = new DecimalModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = parameterValue,
        };

        // Act
        var viewModel = _mapper.Map<DecimalModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new DecimalModelViewModel
        {
            Id = 1,
            Value = default,
        };

        // Act
        var entity = _mapper.Map<DecimalModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(-100_000.00)]
    [InlineData(-1.00)]
    [InlineData(0.00)]
    [InlineData(1.00d)]
    [InlineData(100_000.00)]
    public void Should_Map_ViewModelToEntitylWithValue(decimal parameterValue)
    {
        // Arrange
        var viewModel = new DecimalModelViewModel
        {
            Id = 1,
            Value = parameterValue,
        };

        // Act
        var entity = _mapper.Map<DecimalModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }
}
