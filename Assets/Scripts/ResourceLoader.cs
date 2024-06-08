using Cysharp.Threading.Tasks;
using UnityEngine;

public class ResourceLoader
{
    public async UniTask<GameObject> TryLoad(string path) =>
        await Resources.LoadAsync<GameObject>(path) as GameObject;
}