using UnityEngine;
using UnityEngine.Events;

public class LevelButton : BaseButton
{
    #region Fields

    [SerializeField] LevelButtonType buttonType;

    #endregion


    #region Properties

    UnityAction OnLevelChoosingScreenEnabled;

    #endregion


    #region Unity lifecycle

    void OnEnable()
    {
        CheckIsButtonActive();
    }

    #endregion


    #region Private methods

    void CheckIsButtonActive()
    {
        string buttonName = string.Format("is_level_button_active_{0}", buttonType.ToString());
        LevelManager.Instance.CheckIsButtonActive(button, buttonName);
    }

    #endregion
}
