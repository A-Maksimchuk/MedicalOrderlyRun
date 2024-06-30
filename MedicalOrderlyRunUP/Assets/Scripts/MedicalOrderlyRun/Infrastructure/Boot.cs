using MedicalOrderlyRun.Infrastructure.SceneManagement;
using UnityEngine;
using VContainer.Unity;

namespace MedicalOrderlyRun.Infrastructure
{
    public class Boot: IStartable
    {
        public void Start()
        {
            Debug.Log("Game start");
            var sceneManager = new SceneManager();
            sceneManager.LoadMainScene();
        }
    }
}