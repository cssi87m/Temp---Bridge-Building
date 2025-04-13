using System.Collections.Generic;
using UnityEngine;

public class Complementary : MonoBehaviour {
    private Rigidbody2D rb;
    private Dictionary<string, Dictionary<string, float>> material_properties = new()
    {
        { "Wood", new Dictionary<string, float>() { 
            { "max_length_scale", 100f }, 
            { "min_length_scale", 25f }, 
            { "mass", 1.0f }, { "base_mana_cost", 1.0f } } },
        { "Stone", new Dictionary<string, float>() { 
            { "max_length_scale", 50f }, 
            { "min_length_scale", 10f }, 
            { "mass", 2.0f }, 
            { "base_mana_cost", 2.0f } } },
        { "Metal", new Dictionary<string, float>() { 
            { "max_length_scale", 75f }, 
            { "min_length_scale", 15f }, 
            { "mass", 3.0f }, 
            { "base_mana_cost", 3.0f } } },
        // Add more materials as needed
    };
    // Physical attribute
    private float max_length_scale;
    private float min_length_scale;
    private float mass;
    private float base_mana_cost;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        // Initialize the road object
        rb = GetComponent<Rigidbody2D>();
        // Set material properties

        string material = "Wood"; // This should be set by the player

        max_length_scale = material_properties[material]["max_length_scale"];
        min_length_scale = material_properties[material]["min_length_scale"];
        mass = material_properties[material]["mass"];
        base_mana_cost = material_properties[material]["base_mana_cost"];
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
        float mana_cost = base_mana_cost * transform.localScale.x / max_length_scale;
        // This should be set by the player
    }
    
}