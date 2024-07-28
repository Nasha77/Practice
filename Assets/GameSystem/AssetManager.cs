// KEE POH KUN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

public static class AssetManager 
{
    //private static string spritePath = "CharacterSprite/{0}";
    public static void LoadSprite(string name, Action<Sprite> onLoaded)
    {
        Debug.Log($"Sprite requested is {name}");
        // loadedSprite obj contains a sprite. call on loaded to pass loadedsprite as an input parameter
        // Addressables.LoadAssetAsync<Sprite>(string.Format($"CharacterSprite/{name}.png", name)).Completed += (loadedSprite) =>
        // directly puts the name inside 
        Addressables.LoadAssetAsync<Sprite>($"CharacterSprite/{name}.png").Completed += (loadedSprite) =>
        {
            // check if it exists
            onLoaded?.Invoke(loadedSprite.Result);
        };
    }
}
