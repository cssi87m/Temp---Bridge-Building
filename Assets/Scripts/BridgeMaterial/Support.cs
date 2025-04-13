using UnityEngine;
using System.Collections.Generic;

public class Support: MonoBehaviour {
    private Rigidbody2D rb;
    private Dictionary<string, Dictionary<string, float>> material_properties = new()
    {
        { "Rope", new Dictionary<string, float>() { 
            { "max_length_scale", 100f }, 
            { "min_length_scale", 25f }, 
            { "base_mana_cost", 1.0f } } },
        { "Cable", new Dictionary<string, float>() { 
            { "max_length_scale", 50f }, 
            { "min_length_scale", 10f }, 
            { "base_mana_cost", 2.0f } } },
        // Add more materials as needed
    };
    // Physical attribute
    private float max_length_scale = 100f;
    private float min_length_scale = 25f;
    private float base_mana_cost = 1.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        // Initialize the road object
        rb = GetComponent<Rigidbody2D>();
        // Set material properties

        string material = "Rope"; // This should be set by the player

        max_length_scale = material_properties[material]["max_length_scale"];
        min_length_scale = material_properties[material]["min_length_scale"];
        base_mana_cost = material_properties[material]["base_mana_cost"];
        // Set all physics attributes of road object
        rb.mass = 0;

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