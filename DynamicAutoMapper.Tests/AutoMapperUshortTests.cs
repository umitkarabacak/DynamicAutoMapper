namespace DynamicAutoMapper.Tests;

public class AutoMapperUshortTests
{
    private readonly IMapper _mapper;

    public AutoMapperUshortTests()
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
        var entity = new UshortModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = default,
        };

        // Act
        var viewModel = _mapper.Map<UshortModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(ushort.MinValue)]
    [InlineData(0)]
    [InlineData(ushort.MaxValue)]
    public void Should_Map_EntityToViewModelWithValue(ushort parameterValue)
    {
        // Arrange
        var entity = new UshortModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = parameterValue,
        };

        // Act
        var viewModel = _mapper.Map<UshortModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new UshortModelViewModel
        {
            Id = 1,
            Value = default,
        };

        // Act
        var entity = _mapper.Map<UshortModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(ushort.MinValue)]
    [InlineData(0)]
    [InlineData(ushort.MaxValue)]
    public void Should_Map_ViewModelToEntitylWithValue(ushort parameterValue)
    {
        // Arrange
        var viewModel = new UshortModelViewModel
        {
            Id = 1,
            Value = parameterValue,
        };

        // Act
        var entity = _mapper.Map<UshortModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }
}
