using UnityEngine;

public class Road : MonoBehaviour {
    private Rigidbody2D rb;

    // Physical attributes
    private float max_length_scale = 2f;
    private float min_length_scale = 1f;
    private float mass = 1.0f;
    private float base_mana_cost = 1.0f;

    // Runtime states
    private bool isDragging = false;
    private Vector3 dragStartPos;

    // Public mana cost for UI or gameplay logic
    public float ManaCost { get; private set; }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = mass;

        // Initialize road scale
        float length_scale = SetLengthScale();
        transform.localScale = new Vector3(length_scale, transform.localScale.y, transform.localScale.z);

        CalculateManaCost();
    }

    void Update() {
        if (isDragging) {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float newLength = Mathf.Clamp(mouseWorldPos.x - dragStartPos.x, min_length_scale, max_length_scale);

            // Ensure positive length only
            newLength = Mathf.Max(newLength, min_length_scale);

            // Update length
            transform.localScale = new Vector3(newLength, transform.localScale.y, transform.localScale.z);

            // Recalculate mana cost
            CalculateManaCost();
        }
    }
    
    void OnMouseDown() {
        isDragging = true;
        dragStartPos = transform.position;
    }

    void OnMouseUp() {
        isDragging = false;
    }

    float SetLengthScale() {
        return Random.Range(min_length_scale, max_length_scale); // Initial random length
    }

    void CalculateManaCost() {
        ManaCost = base_mana_cost * transform.localScale.x;
        Debug.Log($"Mana Cost: {ManaCost}");
    }
}

