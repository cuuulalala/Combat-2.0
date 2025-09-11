using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float tileSize = 1f;
    Sprite tileSprite;

    Sprite CreateTileSprite()
    {
        var tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, new Color(0.3f, 0.8f, 0.3f));
        tex.filterMode = FilterMode.Point;
        tex.Apply();
        return Sprite.Create(tex, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), 1f);
    }

    public void Generate()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var tile = new GameObject($"Tile_{x}_{y}");
                tile.transform.position = new Vector3(x * tileSize, y * tileSize, 0f);
                var sr = tile.AddComponent<SpriteRenderer>();
                sr.sprite = tileSprite;
            }
        }
    }

    [RuntimeInitializeOnLoadMethod]
    static void Bootstrap()
    {
        var go = new GameObject("WorldGenerator");
        var gen = go.AddComponent<WorldGenerator>();
        gen.tileSprite = gen.CreateTileSprite();
        gen.Generate();
    }
}
