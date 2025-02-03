using UnityEngine.SceneManagement;

namespace Platformer.Service.MainMenu
{
    public class MainMenuLoaderService
    {
        #region Public methods

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("Start");
        }

        #endregion
    }
}