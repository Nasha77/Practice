using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

public class AssetManager 
{
    private static string spritePath = "CharacterSprite/{0}";
    public static void LoadSprite(string name, Action<Sprite> onLoaded)
    {
        // loadedSprite obj contains a sprite. call on loaded to pass loadedsprite as an input parameter
        Addressables.LoadAssetAsync<Sprite>(string.Format("CharacterSprite/{0}.png", name)).Completed += (loadedSprite) =>
        {
            // check if it exists
            onLoaded?.Invoke(loadedSprite.Result);
        };
    }
}
