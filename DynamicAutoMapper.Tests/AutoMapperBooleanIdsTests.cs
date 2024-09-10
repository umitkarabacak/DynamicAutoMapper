namespace DynamicAutoMapper.Tests;

public class AutoMapperBooleanIdsTests
{
    private readonly IMapper _mapper;

    public AutoMapperBooleanIdsTests()
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
        var entity = new BooleanIdsModel
        {
            Id = Random.Shared.Next(0, 250),
            ValueIds = "True,True,False"
        };

        // Act
        var viewModel = _mapper.Map<BooleanIdsModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.ValueIds, string.Join(',', viewModel.ValueIds));
        Assert.Equal(entity.ValueIds.Split(',').Select(Convert.ToBoolean), viewModel.ValueIds);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new BooleanIdsModelViewModel
        {
            Id = 1,
            ValueIds = [true, true, false]
        };

        // Act
        var entity = _mapper.Map<BooleanIdsModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(string.Join(',', viewModel.ValueIds), entity.ValueIds);
        Assert.Equal(viewModel.ValueIds, entity.ValueIds.Split(',').Select(Convert.ToBoolean));
    }
}
