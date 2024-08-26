﻿namespace DynamicAutoMapper.Tests;

public class AutoMapperFloatTests
{
    private readonly IMapper _mapper;

    public AutoMapperFloatTests()
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
        var entity = new FloatModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = default,
        };

        // Act
        var viewModel = _mapper.Map<FloatModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(-100_000f)]
    [InlineData(-1f)]
    [InlineData(0f)]
    [InlineData(1f)]
    [InlineData(100_000f)]
    public void Should_Map_EntityToViewModelWithValue(float parameterValue)
    {
        // Arrange
        var entity = new FloatModel
        {
            Id = Random.Shared.Next(0, 250),
            Value = parameterValue,
        };

        // Act
        var viewModel = _mapper.Map<FloatModelViewModel>(entity);

        // Assert
        Assert.Equal(entity.Id, viewModel.Id);
        Assert.Equal(entity.Value, viewModel.Value);
    }

    [Fact]
    public void Should_Map_ViewModelToEntityDefaultValue()
    {
        // Arrange
        var viewModel = new FloatModelViewModel
        {
            Id = 1,
            Value = default,
        };

        // Act
        var entity = _mapper.Map<FloatModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(null)]
    [InlineData(-100_000f)]
    [InlineData(-1f)]
    [InlineData(0f)]
    [InlineData(1f)]
    [InlineData(100_000f)]
    public void Should_Map_ViewModelToEntitylWithValue(float parameterValue)
    {
        // Arrange
        var viewModel = new FloatModelViewModel
        {
            Id = 1,
            Value = parameterValue,
        };

        // Act
        var entity = _mapper.Map<FloatModel>(viewModel);

        // Assert
        Assert.Equal(viewModel.Id, entity.Id);
        Assert.Equal(viewModel.Value, entity.Value);
    }
}
