using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public static WindController instance; //변수 선언부
    public Vector2 windDirection = new Vector2(-1f, 0f); // Adjust the wind direction as needed
    public float windForce = 1f; // Adjust the wind force as needed
    public LayerMask affectedLayers; // Layers to be affected by wind

    private void Awake()
    {
        WindController.instance = this; //변수 초기화부
    }
    void Update()
    {
        ApplyWindForce();
    }

    void ApplyWindForce()
    {
        // Apply wind force to objects in the scene
        Collider2D[] colliders = Physics2D.OverlapAreaAll(new Vector2(-100f, -100f), new Vector2(100f, 100f), affectedLayers);
        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(windDirection * windForce * Time.deltaTime, ForceMode2D.Force);
            }
        }
    }
}