namespace DynamicAutoMapper.Tests;

public class AutoMapperConfigurationTests
{
    private readonly IMapper _mapper;

    public AutoMapperConfigurationTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            // Burada tüm profillerinizi ekleyin
            cfg.AddProfile<DynamicProfile>();
        });

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void AutoMapper_Configuration_IsValid()
    {
        _mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }
}
