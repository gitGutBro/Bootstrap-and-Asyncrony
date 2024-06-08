using System;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader
{
    public async void TryLoadImage(string URL, Image imageComponent)
    {
        Texture2D texture = await GetTextureFromURL(URL);

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        imageComponent.sprite = sprite;
    }

    private async Task<Texture2D> GetTextureFromURL(string URL)
    {
        Texture2D texture = new(2, 2);

        using WebClient webClient = new();

        try
        {
            byte[] imageData = await webClient.DownloadDataTaskAsync(new Uri(URL));

            if (ImageConversion.LoadImage(texture, imageData) == false)
                texture = null;
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

        return texture;
    }
}