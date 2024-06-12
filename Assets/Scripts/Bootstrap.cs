using UnityEngine;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string _URL;
    [SerializeField] private Image _image;
    [Space]
    [SerializeField]private ScenesSwitcher _scenesSwitcher;

    private ImageLoader _imageLoader;
    private ResourceLoader _resourceLoader;

    private void Awake()
    {
        _imageLoader = new();
        _resourceLoader = new();
    }

    private async void Start()
    {
        _image.sprite = await _imageLoader.GetLoadedSprite(_URL);
        GameObject gameObject = await _resourceLoader.TryLoad("Resource");
        print(gameObject);
        _scenesSwitcher.SwitchByIndexAsync();
    }
}