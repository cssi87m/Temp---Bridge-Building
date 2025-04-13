using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    private int speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(7, 0) * speed;
        rb.angularVelocity = -100;
    }

    // Update is called once per frame
    private void Update()
    {

    }
}
