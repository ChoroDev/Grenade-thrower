using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : BaseManager<PlayerManager>
{
    #region Fields

    [SerializeField] PlayerController playerController;

    PlayerController activePlayerController;

    #endregion


    #region Properties

    public UnityAction<PlayerController> OnPlayerCreated;

    public GameObject ActivePlayerInstance { get { return activePlayerController.gameObject; } }

    #endregion


    #region Unity lifecycle

    void OnEnable()
    {
        GameStateMachine.Instance.OnGameStateChanged += ManagePlayer;
    }


    void OnDisable()
    {
        if (GameStateMachine.Instance != null)
        {
            GameStateMachine.Instance.OnGameStateChanged -= ManagePlayer;
        }
    }

    #endregion


    #region Private methods

    private void ManagePlayer(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.OnMenu:

                RemovePlayer();

                break;

            //case GameState.OnGame:

            //    InstantiatePlayer();

            //    break;
        }
    }


    private void InstantiatePlayer()
    {
        if (activePlayerController == null)
        {
            activePlayerController = Instantiate(playerController);
            activePlayerController.gameObject.transform.position = Vector2.zero;
        }
        else
        {
            activePlayerController.gameObject.SetActive(true);
            activePlayerController.gameObject.transform.position = Vector2.zero;
        }
        OnPlayerCreated(activePlayerController);
    }


    private void RemovePlayer()
    {
        if (activePlayerController != null)
        {
            activePlayerController.gameObject.SetActive(false);
        }
    }

    #endregion
}
