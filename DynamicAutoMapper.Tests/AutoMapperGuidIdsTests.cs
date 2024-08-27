namespace DynamicAutoMapper.Tests;

public class AutoMapperGuidIdsTests
{
    private readonly IMapper _mapper;

    public AutoMapperGuidIdsTests()
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
        var entity = new GuidIdsModel
        {
            Id = Random.Shared.Next(0, 250),
            ValueIds = Guid.NewGuid().ToString() + "," + Guid.NewGuid().ToString()
        };

        // Act
        var viewModel = _mapper.Map<GuidIdsModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.ValueIds, string.Join(',', viewModel.ValueIds));
        Assert.Equal(entity.ValueIds.Split(',').Select(x => Guid.Parse(x)), viewModel.ValueIds);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new GuidIdsModelViewModel
        {
            Id = 1,
            ValueIds = [Guid.NewGuid(), Guid.NewGuid()],
        };

        // Act
        var entity = _mapper.Map<GuidIdsModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(string.Join(',', viewModel.ValueIds), entity.ValueIds);
        Assert.Equal(viewModel.ValueIds, entity.ValueIds.Split(',').Select(x => Guid.Parse(x)));
    }
}
