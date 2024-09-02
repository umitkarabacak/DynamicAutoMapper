namespace DynamicAutoMapper.Tests;

public class AutoMapperObjectTests
{
    private readonly IMapper _mapper;

    public AutoMapperObjectTests()
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
        var entity = new ObjectModel
        {
            Id = Random.Shared.Next(0, 250),
            Data = null
        };

        // Act
        var viewModel = _mapper.Map<ObjectModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Null(viewModel.Data);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(123)]
    [InlineData(123.45)]
    [InlineData(true)]
    [InlineData("Test String")]
    public void Should_Map_EntityToViewModelWithValue(object parameterValue)
    {
        // Arrange
        var entity = new ObjectModel
        {
            Id = Random.Shared.Next(0, 250),
            Data = parameterValue
        };

        // Act
        var viewModel = _mapper.Map<ObjectModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Data, viewModel.Data);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new ObjectModelViewModel
        {
            Id = 1,
            Data = null
        };

        // Act
        var entity = _mapper.Map<ObjectModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Null(entity.Data);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(123)]
    [InlineData(123.45)]
    [InlineData(true)]
    [InlineData("Test String")]
    public void Should_Map_ViewModelToEntitylWithValue(object parameterValue)
    {
        // Arrange
        var viewModel = new ObjectModelViewModel
        {
            Id = 1,
            Data = parameterValue
        };

        // Act
        var entity = _mapper.Map<ObjectModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Data, entity.Data);
    }
}
