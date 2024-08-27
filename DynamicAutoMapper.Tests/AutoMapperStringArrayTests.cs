namespace DynamicAutoMapper.Tests;

public class AutoMapperStringArrayTests
{
    private readonly IMapper _mapper;

    public AutoMapperStringArrayTests()
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
        var entity = new StringArrayModel
        {
            Id = Random.Shared.Next(0, 250),
            Values = ["default"],
        };

        // Act
        var viewModel = _mapper.Map<StringArrayModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Values, viewModel.Values);
    }

    [Theory]
    [MemberData(nameof(StringArrayTestData))]
    public void Should_Map_EntityToViewModelWithValue(string[] parameterValues)
    {
        // Arrange
        var entity = new StringArrayModel
        {
            Id = Random.Shared.Next(0, 250),
            Values = parameterValues,
        };

        // Act
        var viewModel = _mapper.Map<StringArrayModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Values, viewModel.Values);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new StringArrayModelViewModel
        {
            Id = 1,
            Values = ["default"],
        };

        // Act
        var entity = _mapper.Map<StringArrayModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Values, entity.Values);
    }

    [Theory]
    [MemberData(nameof(StringArrayTestData))]
    public void Should_Map_ViewModelToEntitylWithValue(string[] parameterValues)
    {
        // Arrange
        var viewModel = new StringArrayModelViewModel
        {
            Id = 1,
            Values = parameterValues,
        };

        // Act
        var entity = _mapper.Map<StringArrayModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Values, entity.Values);
    }

    public static IEnumerable<object[]> StringArrayTestData =>
    new List<object[]>
    {
        new object[] { new string[] { "ümit" } }, // Tek elemanlı bir dizi
        new object[] { new string[] { "ÜmİT" } }, // Tek elemanlı bir dizi, farklı büyük-küçük harf kullanımı
        new object[] { new string[] { "ÜMİT", "KARABACAK" } }, // Çok elemanlı bir dizi
        new object[] { new string[] { "" } }, // Boş bir string içeren dizi
        new object[] { new string[] { string.Empty } }, // Boş bir string içeren dizi (string.Empty kullanarak)
        new object[] { new string[] { } }, // Boş bir dizi
    };
}
