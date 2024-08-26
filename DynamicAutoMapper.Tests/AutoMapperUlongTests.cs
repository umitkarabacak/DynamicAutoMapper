namespace DynamicAutoMapper.Tests;

public class AutoMapperUlongTests
{
    private readonly IMapper _mapper;

    public AutoMapperUlongTests()
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
        var entity = new UlongModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = default,
        };

        // Act
        var viewModel = _mapper.Map<UlongModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(ulong.MinValue)]
    [InlineData(0)]
    [InlineData(ulong.MaxValue)]
    public void Should_Map_EntityToViewModelWithValue(ulong parameterValue)
    {
        // Arrange
        var entity = new UlongModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = parameterValue,
        };

        // Act
        var viewModel = _mapper.Map<UlongModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new UlongModelViewModel
        {
            Id = 1,
            Value = default,
        };

        // Act
        var entity = _mapper.Map<UlongModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(ulong.MinValue)]
    [InlineData(0)]
    [InlineData(ulong.MaxValue)]
    public void Should_Map_ViewModelToEntitylWithValue(ulong parameterValue)
    {
        // Arrange
        var viewModel = new UlongModelViewModel
        {
            Id = 1,
            Value = parameterValue,
        };

        // Act
        var entity = _mapper.Map<UlongModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }
}
