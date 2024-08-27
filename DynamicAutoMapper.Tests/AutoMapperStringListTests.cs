namespace DynamicAutoMapper.Tests;

public class AutoMapperStringListTests
{
    private readonly IMapper _mapper;

    public AutoMapperStringListTests()
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
        var entity = new StringListModel
        {
            Id = Random.Shared.Next(0, 250),
            Values = ["default"],
        };

        // Act
        var viewModel = _mapper.Map<StringListModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Values, viewModel.Values);
    }

    [Theory]
    [MemberData(nameof(StringListTestData))]
    public void Should_Map_EntityToViewModelWithValue(List<string> parameterValues)
    {
        // Arrange
        var entity = new StringListModel
        {
            Id = Random.Shared.Next(0, 250),
            Values = parameterValues,
        };

        // Act
        var viewModel = _mapper.Map<StringListModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Values, viewModel.Values);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new StringListModelViewModel
        {
            Id = 1,
            Values = ["default"],
        };

        // Act
        var entity = _mapper.Map<StringListModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Values, entity.Values);
    }

    [Theory]
    [MemberData(nameof(StringListTestData))]
    public void Should_Map_ViewModelToEntitylWithValue(List<string> parameterValues)
    {
        // Arrange
        var viewModel = new StringListModelViewModel
        {
            Id = 1,
            Values = parameterValues,
        };

        // Act
        var entity = _mapper.Map<StringListModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Values, entity.Values);
    }
    public static IEnumerable<object[]> StringListTestData =>
    new List<object[]>
    {
        new object[] { new List<string> { "ümit" } }, // Tek elemanlı bir liste
        new object[] { new List<string> { "ÜmİT" } }, // Tek elemanlı bir liste, farklı büyük-küçük harf kullanımı
        new object[] { new List<string> { "ÜMİT", "KARABACAK" } }, // Çok elemanlı bir liste
        new object[] { new List<string> { "" } }, // Boş bir string içeren liste
        new object[] { new List<string> { string.Empty } }, // Boş bir string içeren liste (string.Empty kullanarak)
        new object[] { new List<string>() }, // Boş bir liste
    };
}
