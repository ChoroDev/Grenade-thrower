using UnityEngine;

public class ExitButton : BaseButton
{
    #region Unity lifecycle

    void Start()
    {
        button.onClick.AddListener(() => Application.Quit());
    }

    #endregion
}
