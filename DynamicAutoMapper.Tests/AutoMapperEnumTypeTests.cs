namespace DynamicAutoMapper.Tests;

public class AutoMapperEnumTypeTests
{
    private readonly IMapper _mapper;

    public AutoMapperEnumTypeTests()
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
        var entity = new EnumModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = default,
        };

        // Act
        var viewModel = _mapper.Map<EnumModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(CurrencyType.Unkown)]
    [InlineData(CurrencyType.TL)]
    [InlineData(CurrencyType.Dollar)]
    [InlineData(CurrencyType.Euro)]
    [InlineData(CurrencyType.Pound)]
    public void Should_Map_EntityToViewModelWithValue(Enum parameterValue)
    {
        // Arrange
        var entity = new EnumModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = parameterValue,
        };

        // Act
        var viewModel = _mapper.Map<EnumModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new EnumModelViewModel
        {
            Id = 1,
            Value = default,
        };

        // Act
        var entity = _mapper.Map<EnumModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(CurrencyType.Unkown)]
    [InlineData(CurrencyType.TL)]
    [InlineData(CurrencyType.Dollar)]
    [InlineData(CurrencyType.Euro)]
    [InlineData(CurrencyType.Pound)]
    public void Should_Map_ViewModelToEntitylWithValue(Enum parameterValue)
    {
        // Arrange
        var viewModel = new EnumModelViewModel
        {
            Id = 1,
            Value = parameterValue,
        };

        // Act
        var entity = _mapper.Map<EnumModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }
}
