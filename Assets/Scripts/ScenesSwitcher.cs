using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesSwitcher
{
    public async void LoadByIndexAsync(int buildIndex)
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(buildIndex);

        while (loadScene.isDone == false)
            await UniTask.Yield();
    }
}