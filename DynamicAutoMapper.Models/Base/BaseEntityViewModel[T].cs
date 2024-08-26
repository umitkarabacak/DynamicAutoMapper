namespace DynamicAutoMapper.Models.Base;

public abstract class BaseEntityViewModel<T>
{
    public T Id { get; set; }

    public bool IsDeleted { get; set; }
}
