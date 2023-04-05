using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    //private Vector2 _direction;
    private Vector2 direction;
    private Vector2 _direction;
    
    void Start()
    {
        ResetState();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else
        {
            return;
        }
        
        
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wall")
        {
            Vector3 position = transform.position;

            if(direction.x != 0)
            {
                position.x = - other.transform.position.x + direction.x;
            }
            else if(direction.y != 0)
            {
                position.y = - other.transform.position.y + direction.y;
            }

            transform.position = position;
        }

    
    }
    void FixedUpdate()
    {
        float x = MathF.Round(transform.position.x) + direction.x;
        float y = MathF.Round(transform.position.y) + direction.y;

        transform.position = new Vector2(x,y);
    }
    


    private void ResetState()
    {
        _direction = Vector2.right;
        transform.position = Vector3.zero;
    }
}
