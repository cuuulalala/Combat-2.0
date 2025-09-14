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
        sr.sprite = SpriteFactory.CreateCircleSprite();
        sr.color = Color.yellow;
        var shader = Shader.Find("Universal Render Pipeline/2D/Sprite-Unlit-Default");
        if (shader != null)
            sr.material = new Material(shader);

        if (player.GetComponent<PlayerController2D>() == null)
            player.AddComponent<PlayerController2D>();
    }

}
