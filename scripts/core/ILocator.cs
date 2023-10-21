
namespace Project.Core {
    public interface ILocator<T>
    {
        U Get<U>() where U : T;
    }

    public interface ILocator
    {
        T Get<T>();
    }
}
