using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ImageLoader
{
    public async UniTask<Sprite> GetLoadedSprite(string URL)
    {
        Texture2D texture = await GetTextureFromURL(URL);
        Debug.Log(texture);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        return sprite;
    }

    private async Task<Texture2D> GetTextureFromURL(string URL, int width = 2, int height = 2)
    {
        Texture2D texture = new(width, height);

        using HttpClient httpClient = new();
        HttpResponseMessage response = await httpClient.GetAsync(URL);

        if (response.IsSuccessStatusCode == false)
        {
            Debug.LogError("Image load error");
            return null;
        }

        Stream imageStream = await response.Content.ReadAsStreamAsync();
        texture.LoadImage(ReadFully(imageStream));

        return texture;
    }

    private byte[] ReadFully(Stream input)
    {
        using MemoryStream memoryStream = new();
        input.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}