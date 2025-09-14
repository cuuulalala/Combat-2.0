using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    public float contactDamage = 10f;
    private Transform target;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        var sr = GetComponent<SpriteRenderer>();
        if (sr == null)
            sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = SpriteFactory.CreateCircleSprite();
        sr.color = Color.red;
        var shader = Shader.Find("Universal Render Pipeline/2D/Sprite-Unlit-Default");
        if (shader != null)
            sr.material = new Material(shader);

    }

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            target = player.transform;
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 direction = ((Vector2)target.position - rb.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(contactDamage);
        }
    }

}
