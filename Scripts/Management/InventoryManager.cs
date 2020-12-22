using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : BaseManager<InventoryManager>
{
    #region Fields

    bool isInventoryOpened;

    #endregion


    #region Properties

    public UnityAction OnInventoryOpen;
    public UnityAction OnInventoryClose;

    #endregion


    #region Unity lifecycle

    void Update()
    {
        ManageInventoryScreen();
    }

    #endregion


    #region Private methods

    void ManageInventoryScreen()
    {
        if (GameStateMachine.Instance.CurrentGameState == GameState.OnGame && Input.GetKeyDown(KeyCode.I) && !isInventoryOpened)
        {
            OnInventoryOpen();
            isInventoryOpened = true;
        }
        else if (isInventoryOpened && (Input.GetKeyDown(KeyCode.I) || GameStateMachine.Instance.CurrentGameState != GameState.OnGame))
        {
            OnInventoryClose();
            isInventoryOpened = false;
        }
    }

    #endregion
}
