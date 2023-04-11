
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp1 : MonoBehaviour
{
    public PowerUpsEffect powerup;
    private MassGainerFood food;

    void Awake()
    {
        food = FindObjectOfType<MassGainerFood>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Snake")
        {
            PickUp(other.gameObject);    
        }
    }


    void PickUp(GameObject player)
    {
        powerup.Apply(player);  // Apply effect to player.
        gameObject.GetComponent<SpriteRenderer>().enabled = false;     
        food.RandomizePosition();
    }

    
}
