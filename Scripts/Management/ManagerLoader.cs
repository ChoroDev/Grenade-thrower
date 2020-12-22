using System.Collections.Generic;
using UnityEngine;

public class ManagerLoader : BaseManager<ManagerLoader>
{
    #region Fields

    [SerializeField] List<BaseManagerSimple> baseManagers;

    #endregion


    #region Unity lifecycle

    void Awake()
    {
        PlayerPrefs.SetInt("is_level_button_active_FirstChapterFirstLevel", 1);
        PlayerPrefs.SetInt("is_level_button_active_FirstChapterSecondLevel", 1);
        InstantiateStartManagers();
    }

    #endregion


    #region Private methods

    private void InstantiateStartManagers()
    {
        GameStateMachine.Instance = (GameStateMachine)FindManager(typeof(GameStateMachine));
        MapManager.Instance = (MapManager)FindManager(typeof(MapManager));
        CameraManager.Instance = (CameraManager)FindManager(typeof(CameraManager));
        InventoryManager.Instance = (InventoryManager)FindManager(typeof(InventoryManager));
        GUIManager.Instance = (GUIManager)FindManager(typeof(GUIManager));
        LevelManager.Instance = (LevelManager)FindManager(typeof(LevelManager));
    }


    private BaseManagerSimple FindManager(System.Type managerType)
    {
        return baseManagers.Find(baseManager => baseManager.GetType().Equals(managerType));
    }

    #endregion
}
