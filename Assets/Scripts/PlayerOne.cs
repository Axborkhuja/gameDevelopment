using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(0, Input.GetAxis("Vertical"));
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }
}
