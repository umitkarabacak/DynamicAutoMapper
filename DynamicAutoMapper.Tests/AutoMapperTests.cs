namespace DynamicAutoMapper.Tests;

public class AutoMapperTests
{
    private readonly IMapper _mapper;

    public AutoMapperTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DynamicProfile>();
        });

        _mapper = config.CreateMapper();
    }

    //[Fact]
    //public void Should_Map_EntityToViewModel()
    //{
    //    // Arrange
    //    var entity = new YourEntity
    //    {
    //        Id = 1,
    //        Name = "Test Entity",
    //        // Diğer özellikler
    //    };

    //    // Act
    //    var viewModel = _mapper.Map<YourViewModel>(entity);

    //    // Assert
    //    Assert.Equal(entity.Id, viewModel.Id);
    //    Assert.Equal(entity.Name, viewModel.Name);
    //    // Diğer özellikler için de aynı şekilde kontrol yapabilirsiniz
    //}

    //[Fact]
    //public void Should_Map_ViewModelToEntity()
    //{
    //    // Arrange
    //    var viewModel = new YourViewModel
    //    {
    //        Id = 1,
    //        Name = "Test ViewModel",
    //        // Diğer özellikler
    //    };

    //    // Act
    //    var entity = _mapper.Map<YourEntity>(viewModel);

    //    // Assert
    //    Assert.Equal(viewModel.Id, entity.Id);
    //    Assert.Equal(viewModel.Name, entity.Name);
    //    // Diğer özellikler için de aynı şekilde kontrol yapabilirsiniz
    //}

    //[Fact]
    //public void Should_Map_EnumArray_Properly()
    //{
    //    // Arrange
    //    var entity = new YourEntity
    //    {
    //        EnumArray = new[] { YourEnum.Value1, YourEnum.Value2 }
    //    };

    //    // Act
    //    var viewModel = _mapper.Map<YourViewModel>(entity);

    //    // Assert
    //    Assert.NotNull(viewModel.EnumArray);
    //    Assert.Equal(entity.EnumArray.Length, viewModel.EnumArray.Length);
    //    Assert.Contains("Value1", viewModel.EnumArray);
    //    Assert.Contains("Value2", viewModel.EnumArray);
    //}

}
