// KEE POH KUN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

public static class AssetManager 
{
    // Loads a sprite from the Addressable Assets system and invokes a callback when the sprite is loaded.
    // The "name" parameter is the name of the sprite to load.
    // The "onLoaded" parameter is a callback function that takes a Sprite as a parameter.
    public static void LoadSprite(string name, Action<Sprite> onLoaded)
    {

        // Load the sprite from the Addressable Assets system using the specified path format
        // The path is "CharacterSprite/{name}.png", where {name} is the name of the sprite
        Addressables.LoadAssetAsync<Sprite>($"CharacterSprite/{name}.png").Completed += (loadedSprite) =>
        {
            // check if it exists,
            // Check if the onLoaded callback is not null and invoke it with the loaded sprite
            onLoaded?.Invoke(loadedSprite.Result);
        };
    }
}
