using UnityEngine;
using UnityEngine.InputSystem;

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
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
