using System.Collections.Generic;
using UnityEngine;

public static class SpriteFactory
{
    private static readonly Dictionary<int, Sprite> circleCache = new Dictionary<int, Sprite>();

    public static Sprite CreateCircleSprite(int size = 32)
    {
        if (!circleCache.TryGetValue(size, out var sprite))
        {
            var tex = new Texture2D(size, size);
            var center = size / 2f;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    float dx = x - center + 0.5f;
                    float dy = y - center + 0.5f;
                    if (dx * dx + dy * dy <= center * center)
                        tex.SetPixel(x, y, Color.white);
                    else
                        tex.SetPixel(x, y, Color.clear);
                }
            }
            tex.filterMode = FilterMode.Point;
            tex.Apply();
            sprite = Sprite.Create(tex, new Rect(0, 0, size, size), new Vector2(0.5f, 0.5f), size);
            circleCache[size] = sprite;
        }
        return sprite;
    }
}
