namespace DynamicAutoMapper.Tests;

//public class DefaultTets
//{
//    [Fact]
//    public void Should_Map_EnumArray_Properly()
//    {
//        // Arrange
//        var entity = new YourEntity
//        {
//            EnumArray = new[] { YourEnum.Value1, YourEnum.Value2 }
//        };

//        // Act
//        var viewModel = _mapper.Map<YourViewModel>(entity);

//        // Assert
//        Assert.NotNull(viewModel.EnumArray);
//        Assert.Equal(entity.EnumArray.Length, viewModel.EnumArray.Length);
//        Assert.Contains("Value1", viewModel.EnumArray);
//        Assert.Contains("Value2", viewModel.EnumArray);
//    }

//    [Theory]
//    [InlineData(5, true)]
//    [InlineData(-1, false)]
//    [InlineData(0, false)]
//    public void Should_ReturnTrue_When_NumberIsPositive(int number, bool expectedResult)
//    {
//        // Act
//        var result = IsPositive(number);

//        // Assert
//        Assert.Equal(expectedResult, result);
//    }
//}
