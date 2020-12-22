using UnityEngine;
using System.Collections.Generic;

public class ScreenManager : BaseManager<ScreenManager>
{
    #region Fields

    [SerializeField] List<BaseScreen> screens;

    BaseScreen activeScreen;
    BaseScreen activeSurfaceScreen;

    #endregion


    #region Properties

    public static new ScreenManager Instance 
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
            instance = value;
        }
    }

    #endregion


    #region Unity lifecycle

    void OnEnable()
    {
        InventoryManager.Instance.OnInventoryOpen += ShowInventoryScreen;
        InventoryManager.Instance.OnInventoryClose += HideInventoryScreen;
    }


    void OnDisable()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.OnInventoryOpen -= ShowInventoryScreen;
            InventoryManager.Instance.OnInventoryClose -= HideInventoryScreen;
        }
    }

    #endregion


    #region Public methods

    public void SetNewScreenAndHideOther(ScreenType screenTypeToShow)
    {
        if (activeSurfaceScreen != null)
        {
            HideActiveScreen(true);
        }
        if (activeScreen != null)
        {
            HideActiveScreen(false);
        }
        ShowScreenByType(screenTypeToShow, false);
    }

    #endregion


    #region Private methods

    void ShowInventoryScreen()
    {
        ShowScreenByType(ScreenType.InventoryScreen, true);
    }


    void ShowScreenByType(ScreenType screenType, bool isSurfaceScreen)
    {
        BaseScreen screenToActivate = screens.Find(screen => screen.Type == screenType);
        screenToActivate.ShowScreen();
        if (isSurfaceScreen)
        {
            activeSurfaceScreen = screenToActivate;
        }
        else
        {
            activeScreen = screenToActivate;
        }
    }


    void HideInventoryScreen()
    {
        HideActiveScreen(true);
    }


    void HideActiveScreen(bool isSurfaceScreen)
    {
        if (isSurfaceScreen)
        {
            activeSurfaceScreen.HideScreen();
        }
        else
        {
            activeScreen.HideScreen();
        }
    }

    #endregion
}
