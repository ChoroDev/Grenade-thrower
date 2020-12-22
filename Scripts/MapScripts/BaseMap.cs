using UnityEngine;

public class BaseMap : MonoBehaviour
{
    #region Fields

    [SerializeField] MapType mapType;

    #endregion


    #region Properties

    public MapType Type { get { return mapType; } }

    #endregion
}
