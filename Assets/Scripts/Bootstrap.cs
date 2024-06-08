using UnityEngine;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string _URL;
    [SerializeField] private Image _image;

    private ImageLoader _imageLoader;

    private void Awake()
    {
        _imageLoader = new();
    }

    private void Start()
    {
        _imageLoader.TryLoadImage(_URL, _image);
    }
}