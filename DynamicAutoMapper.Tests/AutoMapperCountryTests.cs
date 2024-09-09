namespace DynamicAutoMapper.Tests;

public class AutoMapperCountryTests
{
    private readonly IMapper _mapper;

    public AutoMapperCountryTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DynamicProfile>();
        });

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new CountryViewModel
        {
            Id = 1,
            ZoneIds = ["ümit", "karabacak"],
        };

        // Act
        var entity = _mapper.Map<Country>(viewModel);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.ZoneIds ?? string.Empty, string.Join(",", viewModel.ZoneIds)); // Null veya boş değer kontrolü eklendi
        Assert.Equal((entity.ZoneIds ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries).Length, viewModel.ZoneIds.Length);
    }

    [Theory]
    [MemberData(nameof(StringListTestData))]
    public void Should_Map_ViewModelToEntitylWithValue(string[] parameterValues)
    {
        // Arrange
        var viewModel = new CountryViewModel
        {
            Id = 1,
            ZoneIds = parameterValues,
        };

        // Act
        var entity = _mapper.Map<Country>(viewModel);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(string.Join(",", parameterValues ?? new string[0]), entity.ZoneIds); // Null veya boş değer kontrolü
    }

    public static IEnumerable<object[]> StringListTestData =>
        new List<object[]>
        {
            new object[] { new string[] { "ümit" } },
            new object[] { new string[] { "ÜMİT", "KARABACAK" } },
            new object[] { new string[] { "" } },
            new object[] { new string[] { string.Empty } },
            new object[] { new string[] { null } },    // FIXED
            new object[] { null },                     // FIXED
        };

}
