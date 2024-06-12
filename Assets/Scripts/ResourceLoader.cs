using Cysharp.Threading.Tasks;
using UnityEngine;

public class ResourceLoader
{
    public async UniTask<GameObject> TryLoad(string path)
    {
        var result = Resources.LoadAsync<GameObject>(path);
        return await result as GameObject;
    }
}