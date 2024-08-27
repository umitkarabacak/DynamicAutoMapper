namespace DynamicAutoMapper;

public class DynamicProfile : Profile
{
    public DynamicProfile()
    {
        // BaseEntity<> ve BaseEntityViewModel<> türlerinden birinin assembly'sini alın
        var modelBaseEntityAssembly = typeof(BaseEntity<>).Assembly;
        var modelBaseEntityViewModelAssembly = typeof(BaseEntityViewModel<>).Assembly;

        var assemblies = new[] { modelBaseEntityAssembly, modelBaseEntityViewModelAssembly };

        // Find all types derived from BaseEntity<T>
        var entityTypes = assemblies.SelectMany(a => a.GetTypes())
            .Where(t => t.BaseType != null &&
                        (
                            (t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(BaseEntity<>))
                            || t.BaseType == typeof(BaseEntity)
                        ))
            .Distinct()
            .ToList();

        // Find all types derived from BaseEntityViewModel<T>
        var modelTypes = assemblies.SelectMany(a => a.GetTypes())
            .Where(t => t.BaseType != null &&
                        (
                            (t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityViewModel<>))
                            || t.BaseType == typeof(BaseEntityViewModel)
                        ))
            .Distinct()
            .ToList();

        var createMapMethod = typeof(Profile).GetMethod("CreateMap", new Type[] { });

        foreach (var entityType in entityTypes)
        {
            // Her entity türü için, aynı isimle başlayan model türlerini bulun
            var matchingModels = modelTypes.Where(m => m.Name.StartsWith(entityType.Name)).ToList();

            foreach (var modelType in matchingModels)
            {
                // Her eşleşen tür için map oluşturun
                var genericCreateMapMethod = createMapMethod.MakeGenericMethod(entityType, modelType);
                var map = genericCreateMapMethod.Invoke(this, null);

                // ReverseMap'i çağır
                var reverseMapMethod = map.GetType().GetMethod("ReverseMap");
                reverseMapMethod.Invoke(map, null);
            }
        }
    }
}
