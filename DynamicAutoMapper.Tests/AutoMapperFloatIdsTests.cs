namespace DynamicAutoMapper.Tests;

public class AutoMapperFloatIdsTests
{
    private readonly IMapper _mapper;

    public AutoMapperFloatIdsTests()
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
        var entity = new FloatIdsModel
        {
            Id = Random.Shared.Next(0, 250),
            ValueIds = "1.1,2.3"
        };

        // Act
        var viewModel = _mapper.Map<FloatIdsModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.ValueIds, string.Join(',', viewModel.ValueIds));
        Assert.Equal(entity.ValueIds.Split(',').Select(x => Convert.ToSingle(x)), viewModel.ValueIds);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new FloatIdsModelViewModel
        {
            Id = 1,
            ValueIds = [1f, 2f],
        };

        // Act
        var entity = _mapper.Map<FloatIdsModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(string.Join(',', viewModel.ValueIds), entity.ValueIds);
        Assert.Equal(viewModel.ValueIds, entity.ValueIds.Split(',').Select(x => Convert.ToSingle(x)));
    }
}
