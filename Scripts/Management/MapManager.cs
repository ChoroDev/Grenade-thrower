using System.Collections.Generic;
using UnityEngine;

public class MapManager : BaseManager<MapManager>
{
    #region Fields

    [SerializeField] List<BaseMap> maps;

    BaseMap instantiatedMap;

    #endregion


    #region Unity lifecycle

    void OnEnable()
    {
        GameStateMachine.Instance.OnGameStateChanged += ManageMap;
    }


    void OnDisable()
    {
        if (GameStateMachine.Instance != null)
        {
            GameStateMachine.Instance.OnGameStateChanged -= ManageMap;
        }
    }

    #endregion


    #region Private methods

    private void ManageMap(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.OnMenu:

                DestroyMap();

                break;

            case GameState.OnGame:

                CreateMap(MapType.LocalMap);

                break;
        }
    }

    
    private void CreateMap(MapType mapType)
    {
        instantiatedMap = Instantiate(maps.Find((map) => map.Type == mapType));
    }


    private void DestroyMap()
    {
        if (instantiatedMap != null)
        {
            Destroy(instantiatedMap.gameObject);
        }
    }

    #endregion
}
