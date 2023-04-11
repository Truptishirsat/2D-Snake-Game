using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    private MassGainerFood food;
    private Vector3 previousPosition;
    private float spawnRange = 20f;


    float timer = 0.0f;
    void Awake()
    {
        food = FindObjectOfType<MassGainerFood>();
    }
    void Start()
    {
        transform.position = food.RandomizePosition();
    }

    void Update()
    {
        if(previousPosition == transform.position)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
        }

        previousPosition = transform.position;

        if(timer >= spawnRange)
        {
            transform.position = food.RandomizePosition();
            GetComponent<SpriteRenderer>().enabled = true;  
            GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
