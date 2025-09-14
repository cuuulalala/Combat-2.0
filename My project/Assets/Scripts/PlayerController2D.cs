using UnityEngine;
 codex/implement-player-movement-and-shooting-mechanics-c0ewn5
using UnityEngine.InputSystem;
> main

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Camera cam;
    private Vector2 movement;
    private Vector2 mousePos;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {
 codex/implement-player-movement-and-shooting-mechanics-c0ewn5
        if (Keyboard.current != null)
        {
            movement = Vector2.zero;
            if (Keyboard.current.aKey.isPressed) movement.x -= 1f;
            if (Keyboard.current.dKey.isPressed) movement.x += 1f;
            if (Keyboard.current.sKey.isPressed) movement.y -= 1f;
            if (Keyboard.current.wKey.isPressed) movement.y += 1f;
            movement = movement.normalized;
        }

        if (cam != null && Mouse.current != null)
            mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        if (cam != null)
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
 main
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
