using UnityEngine;

public class Node: MonoBehaviour {
    private Rigidbody2D rb;
    // Physical attribute
    private float max_length_scale = 100f;
    private float min_length_scale = 25f;
    private float mass = 1.0f;
    private float base_mana_cost = 1.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        // Initialize the road object
        rb = GetComponent<Rigidbody2D>();
        
        // Set all physics attributes of road object
        rb.mass = mass;

        CalculateLength();
        CalculateManaCost();
    }
    // Update is called once per frame
    void Update()
    {
        // Update the road object
    }

    // TODO: Talking to Son
    float SetLengthScale() {
        // Set the length scale of the road object
        return Random.Range(min_length_scale, max_length_scale); // This should be set by the player
        
    }

    void CalculateLength() {
        float length_scale = SetLengthScale();
        transform.localScale = new Vector3(length_scale, transform.localScale.y, transform.localScale.z);
        // Mana cost of 1 road object
    }

    void CalculateManaCost() {
        // Calculate the mana cost of the road object
        float mana_cost = base_mana_cost * transform.localScale.x;
        // This should be set by the player
    }
}