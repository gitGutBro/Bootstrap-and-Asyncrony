using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class ScenesSwitcher
{
    [SerializeField] private Slider _progressBar;

    public async void SwitchByIndexAsync()
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        while (loadScene.isDone == false)
        {
            const float AsyncOperationLimit = 0.9f;

            float progress = Mathf.Clamp01(loadScene.progress / AsyncOperationLimit);
            _progressBar.value = progress;

            await UniTask.Yield();
        }

        System.Threading.Thread.Sleep(500); //For demonstration the progress bar on the scene.
        loadScene.allowSceneActivation = true;
    }
}