using UnityEngine;

public abstract class BaseManager<T> : BaseManagerSimple where T : MonoBehaviour
{
    #region Fields
    
    protected static T instance;

    #endregion


    #region Properties
    
    public static new T Instance 
    {
        get 
        {
            if (instance != null)
            {
                return instance;
            }
            return null;
        }
        set 
        {
            instance = Instantiate(value);
        }
    }

    #endregion
}
