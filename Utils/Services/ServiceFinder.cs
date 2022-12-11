namespace Controller.Services;

using Utils.Interfaces;

/// <summary>
/// Искатель имплементаций сервиса
/// Привычнее использовать локатор служб, поэтому нагородил такой велосипед.
/// </summary>
public static class ServiceFinder
{
    private static Type[]? _allTypes = null;

    /// <summary>
    /// Все типы
    /// </summary>
    /// <remarks> Да, с многопоточностью могут возникнуть проблемы, можно сделать конкуррентный хешсет, либо инициализировать на старте приложения. </remarks>
    public static Type[] AllTypes
    {
        get => _allTypes
               ?? AppDomain.CurrentDomain.GetAssemblies()
                   .SelectMany(it =>
                       it.GetTypes()).ToArray();
        set => _allTypes = value;
    }

    /// <summary>
    /// Получить единственную имплементацию по дженерику на классе
    /// </summary>
    /// <param name="item">Элемент</param>
    /// <param name="baseType">Базовый тип сервиса с открытым дженериком (абстрактный класс или интерфейс)</param>
    /// <typeparam name="TGeneric">Тип дженерика</typeparam>
    /// <typeparam name="TService">Тип сервиса</typeparam>
    /// <returns>Инстанс сервиса</returns>
    public static TService GetSingleImplementationByGeneric<TGeneric, TService>(TGeneric item, Type baseType)
        where TService : IResolvable
    {
        return GetSingleImplementationByGeneric<TService>(item?.GetType() ?? typeof(TGeneric), baseType);
    }

    /// <summary>
    /// Получить единственную имплементацию по дженерику на классе
    /// </summary>
    /// <param name="itemType">Тип элемента</param>
    /// <param name="baseType">Базовый тип сервиса с открытым дженериком (абстрактный класс или интерфейс)</param>
    /// <typeparam name="TService">Тип сервиса</typeparam>
    /// <returns>Инстанс сервиса</returns>
    /// <exception cref="Exception">Исключение при инстанциировании сервиса</exception>
    public static TService GetSingleImplementationByGeneric<TService>(Type itemType, Type baseType)
        where TService : IResolvable
    {
        var types = ServiceFinder.GetImplementationsTypesOfService<TService>();

        // TODO Если подумать получше, то можно найти более надёжный способ сопоставления, также после устранения недостатков, описанных выше.
        var type = types.SingleOrDefault(it =>
            it.IsClass
            && it.BaseType.GenericTypeArguments.All(z => baseType.GenericTypeArguments.Contains(z))
            && !it.IsAbstract);

        if (type is null)
        {
            throw new Exception($"Can't find implementation of {nameof(TService)} for {itemType}");
        }

        if (Activator.CreateInstance(type)
            is TService service)
        {
            return service;
        }

        throw new Exception($"Can't create implementation of {nameof(TService)} for {itemType}");
    }

    /// <summary>
    /// Найти имплементацию для сервиса
    /// </summary>
    /// <typeparam name="TService">Тип сервиса</typeparam>
    /// <returns>все имплементации</returns>
    public static Type[] GetImplementationsTypesOfService<TService>()
        where TService : IResolvable
    {
        return AllTypes
            .Where(z =>
                z.GetInterfaces()
                    .Contains(typeof(TService)))
            .ToArray();
    }
}