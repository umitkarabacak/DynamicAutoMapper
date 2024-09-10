namespace DynamicAutoMapper.Tests;

public class AutoMapperEnumIdsTests
{
    private readonly IMapper _mapper;

    public AutoMapperEnumIdsTests()
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
        var entity = new EnumIdsModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = [CurrencyType.TL, CurrencyType.Dollar]
        };

        // Act
        var viewModel = _mapper.Map<EnumIdsModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new EnumIdsModelViewModel
        {
            Id = 1,
            Value = [CurrencyType.TL, CurrencyType.Dollar]
        };

        // Act
        var entity = _mapper.Map<EnumIdsModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }
}
