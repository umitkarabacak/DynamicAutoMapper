namespace DynamicAutoMapper.Tests;

public class AutoMapperStringIdsTests
{
    private readonly IMapper _mapper;

    public AutoMapperStringIdsTests()
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
        var entity = new StringIdsModel
        {
            Id = Random.Shared.Next(0, 250),
            ValueIds = "ümit,karabacak"
        };

        // Act
        var viewModel = _mapper.Map<StringIdsModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.ValueIds, string.Join(',', viewModel.ValueIds));
        Assert.Equal(entity.ValueIds.Split(','), viewModel.ValueIds);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new StringIdsModelViewModel
        {
            Id = 1,
            ValueIds = ["ümit", "karabacak"],
        };

        // Act
        var entity = _mapper.Map<StringIdsModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(string.Join(',', viewModel.ValueIds), entity.ValueIds);
        Assert.Equal(viewModel.ValueIds, entity.ValueIds.Split(','));
    }
}
