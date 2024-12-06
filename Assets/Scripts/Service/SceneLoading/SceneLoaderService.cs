using UnityEngine.SceneManagement;

namespace Platformer.Service.SceneLoading
{
    public class SceneLoaderService
    {
        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadAsync(string sceneName) { }

    }
}