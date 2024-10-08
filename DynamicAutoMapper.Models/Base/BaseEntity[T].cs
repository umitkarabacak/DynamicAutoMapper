﻿namespace DynamicAutoMapper.Models.Base;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
    public bool IsDeleted { get; set; }
}
