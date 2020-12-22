using UnityEngine;

public class GUIManager : BaseManager<GUIManager>
{
    #region Fields

    [SerializeField] ScreenManager screenManagerReference;

    [SerializeField] BaseButton playButton;
    [SerializeField] BaseButton firstLevelButton;
    [SerializeField] BaseButton menuButton;

    #endregion


    #region Unity lifecycle

    void OnEnable()
    {
        ScreenManager.Instance = screenManagerReference;
        playButton.OnClickAction += EnterLevelChoosing;
        firstLevelButton.OnClickAction += EnterNewGame;
        menuButton.OnClickAction += EnterMenu;
    }


    void Start()
    {
        EnterState(ScreenType.MenuScreen, GameState.OnMenu);
    }


    void OnDisable()
    {
        if (playButton != null)
        {
            playButton.OnClickAction -= EnterLevelChoosing;
        }
        if (firstLevelButton != null)
        {
            firstLevelButton.OnClickAction -= EnterNewGame;
        }
        if (menuButton != null)
        {
            menuButton.OnClickAction -= EnterMenu;
        }
    }

    #endregion


    #region Private methods

    void EnterMenu()
    {
        EnterState(ScreenType.MenuScreen, GameState.OnMenu);
    }


    void EnterLevelChoosing()
    {
        EnterState(ScreenType.LevelChoosingScreen, GameState.OnLevelChoosing);
    }


    void EnterNewGame()
    {
        EnterState(ScreenType.GameScreen, GameState.OnGame);
    }    

    
    void EnterState(ScreenType screenType, GameState gameState)
    {
        ScreenManager.Instance.SetNewScreenAndHideOther(screenType);
        GameStateMachine.Instance.SetCurrentStateAndNotifyListeners = gameState;
    }

    #endregion
}