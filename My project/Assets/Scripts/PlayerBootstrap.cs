using UnityEngine;

public static class PlayerBootstrap
{
    [RuntimeInitializeOnLoadMethod]
    static void Init()
    {
        var player = GameObject.Find("Player");
        if (player == null)
        {
            player = new GameObject("Player");
            player.transform.position = Vector3.zero;
        }
        player.tag = "Player";

        var rb = player.GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = player.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        if (player.GetComponent<CircleCollider2D>() == null)
            player.AddComponent<CircleCollider2D>();

        var sr = player.GetComponent<SpriteRenderer>();
        if (sr == null)
            sr = player.AddComponent<SpriteRenderer>();
        sr.sprite = CreateCircleSprite();
        sr.color = Color.yellow;
        var shader = Shader.Find("Universal Render Pipeline/2D/Sprite-Unlit-Default");
        if (shader != null)
            sr.material = new Material(shader);

        if (player.GetComponent<PlayerController2D>() == null)
            player.AddComponent<PlayerController2D>();
    }

    static Sprite CreateCircleSprite()
    {
        const int size = 32;
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
        return Sprite.Create(tex, new Rect(0, 0, size, size), new Vector2(0.5f, 0.5f), size);
    }
}
