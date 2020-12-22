using UnityEngine;

public abstract class BaseManagerSimple : MonoBehaviour
{
    #region Fields

    static BaseManagerSimple instance;

    #endregion


    #region Properties

    public static BaseManagerSimple Instance 
    {
        get 
        {
            if (instance != null)
            {
                return instance;
            }
            return instance = new GameObject(typeof(BaseManagerSimple).ToString()).AddComponent<BaseManagerSimple>();
        }
        set 
        {
            instance = value;
        }
    }

    #endregion
}
