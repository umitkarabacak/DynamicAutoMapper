namespace DynamicAutoMapper.Tests;

public class AutoMapperSbyteTests
{
    private readonly IMapper _mapper;

    public AutoMapperSbyteTests()
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
        var entity = new SbyteModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = default,
        };

        // Act
        var viewModel = _mapper.Map<SbyteModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(sbyte.MinValue)]
    [InlineData(0)]
    [InlineData(sbyte.MaxValue)]
    public void Should_Map_EntityToViewModelWithValue(sbyte parameterValue)
    {
        // Arrange
        var entity = new SbyteModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = parameterValue,
        };

        // Act
        var viewModel = _mapper.Map<SbyteModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new SbyteModelViewModel
        {
            Id = 1,
            Value = default,
        };

        // Act
        var entity = _mapper.Map<SbyteModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(sbyte.MinValue)]
    [InlineData(0)]
    [InlineData(sbyte.MaxValue)]
    public void Should_Map_ViewModelToEntitylWithValue(sbyte parameterValue)
    {
        // Arrange
        var viewModel = new SbyteModelViewModel
        {
            Id = 1,
            Value = parameterValue,
        };

        // Act
        var entity = _mapper.Map<SbyteModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }
}
