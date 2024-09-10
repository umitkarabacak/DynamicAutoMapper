namespace DynamicAutoMapper.Tests;

public class AutoMapperCharIdsTests
{
    private readonly IMapper _mapper;

    public AutoMapperCharIdsTests()
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
        var entity = new CharIdsModel
        {
            Id = Random.Shared.Next(0, 250),
            ValueIds = "a,b,c"
        };

        // Act
        var viewModel = _mapper.Map<CharIdsModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.ValueIds, string.Join(',', viewModel.ValueIds));
        Assert.Equal(entity.ValueIds.Split(',').Select(Convert.ToChar), viewModel.ValueIds);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new CharIdsModelViewModel
        {
            Id = 1,
            ValueIds = ['1', '2', '3'],
        };

        // Act
        var entity = _mapper.Map<CharIdsModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(string.Join(',', viewModel.ValueIds), entity.ValueIds);
        Assert.Equal(viewModel.ValueIds, entity.ValueIds.Split(',').Select(Convert.ToChar));
    }
}
