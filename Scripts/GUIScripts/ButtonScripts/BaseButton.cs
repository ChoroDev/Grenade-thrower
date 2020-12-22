using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BaseButton : MonoBehaviour
{
    #region Fields

    [SerializeField] protected Button button;

    #endregion


    #region Properties

    public UnityAction OnClickAction;

    #endregion


    #region Unity lifecycle

    void Start()
    {
        RegisterButtonListener();    
    }

    #endregion


    #region Private methods

    void RegisterButtonListener()
    {
        button.onClick.AddListener(OnClickAction);
    }

    #endregion
}
