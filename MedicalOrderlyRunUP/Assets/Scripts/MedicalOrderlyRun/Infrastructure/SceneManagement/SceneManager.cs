using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using SM = UnityEngine.SceneManagement.SceneManager;

namespace MedicalOrderlyRun.Infrastructure.SceneManagement
{
    public class SceneManager
    {
        private SceneInstance? _loadingScene;
        private SceneInstance? _currentScene;
        private const string LOADING_SCENE_NAME = "Loading";
        private const string MAIN_SCENE_NAME = "Main";

        public async UniTask LoadScene(string sceneName)
        {
            AsyncOperationHandle<SceneInstance> loadingSceneHandler = 
                Addressables.LoadSceneAsync(LOADING_SCENE_NAME, LoadSceneMode.Additive);
            _loadingScene = await loadingSceneHandler.Task;
            if (_currentScene != null)
            {
                await Addressables.UnloadSceneAsync(_currentScene.Value);
            }
            else
            {
                await SM.UnloadSceneAsync(SM.GetActiveScene());
            }
            AsyncOperationHandle<SceneInstance> nextScene = Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            _currentScene = await nextScene.Task;
            await UniTask.Delay(1000);
            await Addressables.UnloadSceneAsync(_loadingScene.Value);
        }

        public async UniTask LoadMainScene()
        {
            await LoadScene(MAIN_SCENE_NAME);
        }
    }
}