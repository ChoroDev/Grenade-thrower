using UnityEngine.Events;

public class GameStateMachine : BaseManager<GameStateMachine>
{
    #region Fields

    GameState currentGameState;

    #endregion


    #region Properties

    public UnityAction<GameState> OnGameStateChanged;


    public GameState CurrentGameState { get { return currentGameState; } }


    public GameState SetCurrentStateAndNotifyListeners 
    {
        set 
        {
            if (currentGameState != value)
            {
                currentGameState = value;
                SendNotification(currentGameState);
            }
        }
    }

    #endregion


    #region Private methods

    private void SendNotification(GameState newGameState)
    {
        OnGameStateChanged(newGameState);
    }

    #endregion
}
