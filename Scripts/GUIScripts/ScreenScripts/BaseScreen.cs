using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScreen : MonoBehaviour
{
    #region Fields

    [SerializeField] ScreenType screenType;

    #endregion


    #region Properties

    public ScreenType Type { get { return screenType; } }

    #endregion


    #region Public methods

    public void ShowScreen()
    {
        gameObject.SetActive(true);
    }


    public void HideScreen()
    {
        gameObject.SetActive(false);
    }

    #endregion
}
