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
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(string.Join(',', viewModel.ZoneIds), entity.ZoneIds);
        Assert.Equal(viewModel.ZoneIds, entity.ZoneIds.Split(','));
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
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(string.Join(',', viewModel.ZoneIds), entity.ZoneIds);
        Assert.Equal(viewModel.ZoneIds, entity.ZoneIds.Split(','));
    }

    public static IEnumerable<object[]> StringListTestData =>
    [
        [new List<string> { null }],
        [new List<string> { "" }],
        [new List<string> { "ÜMİT", "KARABACAK" }]
    ];

}
