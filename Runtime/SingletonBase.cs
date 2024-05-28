using UnityEngine;

namespace jomi.utils
{
    public abstract class SingletonBase<T> : MonoBehaviour where T : SingletonBase<T>
    {
        public static T Instance => _Instance;
        protected static T _Instance;

        protected virtual void Awake()
        {
            if (_Instance)
            {
                Debug.LogError("Can't have 2 instances of singleton type " + typeof(T).Name + ".");
                Debug.LogWarning("Destroying duplicate instance " + name + ".");
                Destroy(this);
            }

            _Instance = this as T;
        }
    }
}