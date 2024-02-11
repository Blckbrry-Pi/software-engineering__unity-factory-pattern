using Unity.VisualScripting;
using UnityEngine;

public class SingletonBase<T>
where T : Object
{
    private readonly object _lockObj = new();
    public T Instance { get; private set; }

    public T GetOrInitInstance(T newInstance)
    {
        lock (_lockObj) // Because threads go brrrrrr
        {
            bool isNullInSomeWay = Instance == null || Instance.IsDestroyed();
            if (!isNullInSomeWay && !Instance.Equals(newInstance))
            {
                Object.Destroy(newInstance);
            } else
            {
                Instance = newInstance;
            }
            return Instance;
        }
    }
}
