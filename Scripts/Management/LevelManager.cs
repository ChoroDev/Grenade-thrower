using UnityEngine;
using UnityEngine.UI;

public class LevelManager : BaseManager<LevelManager>
{
    #region Public methods

    public void CheckIsButtonActive(Button levelButton, string buttonName)
    {
        if (PlayerPrefs.GetInt(buttonName) == 1)
        {
            levelButton.gameObject.SetActive(true);
        }
        else
        {
            levelButton.gameObject.SetActive(false);
        }
    }

    #endregion
}
