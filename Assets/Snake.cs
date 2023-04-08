using System.Net.Mail;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    
    private Vector2 direction;
    public Transform snakeSegment;
    public int increaseLength;
    public int decreaseLength;

    private List<Transform> segments = new List<Transform>();

    private enum State{
        Alive,
        Dead
    }
    private State state;
    void Start()
    {
        state = State.Alive;
        ResetState();
    }

    void Update()
    {
        
            
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {   
            if(direction.y != -1)
            {
                direction = Vector2.up;
            }
        }else if(Input.GetKeyDown(KeyCode.DownArrow))
        {   
            if(direction.y != 1)
            {
                direction = Vector2.down;
            }
        }else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(direction.x != 1)
            {
                direction = Vector2.left;
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(direction.x != -1)
            {
            direction = Vector2.right;
            }
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
        }else if(other.tag == "Snake")
        {
           state = State.Dead;

        }else if(other.tag == "MassGainerFood")
        {
            GrowSnake(increaseLength);
        }else if(other.tag == "MassBurnerFood")
        {   
            ShrinkSnake(segments.Count);
            
        }

    
    }
    void FixedUpdate()
    {
        if(state == State.Alive)
        {
            float x = MathF.Round(transform.position.x) + direction.x;
            float y = MathF.Round(transform.position.y) + direction.y;

            for(int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].position = segments[i - 1].position; 
            }

            transform.position = new Vector2(x,y);
        }
        
    }
    


    private void ResetState()
    {
        for(int i = segments.Count - 1; i > 0; i--)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        direction = Vector2.right;
        transform.position = Vector3.zero;
        segments.Add(this.transform);
    }

    private void GrowSnake(int length)
    {
        for(int i = 0; i < length; i++)
        {
            Transform segment = Instantiate(snakeSegment);
            segment.position = segments[segments.Count - 1].position;
            segments.Add(segment);
        }
    }

    private void ShrinkSnake(int count)
    {
        int remainingsegments = count - decreaseLength;
        if(remainingsegments > 0)
        {
            ResetState();
            GrowSnake(remainingsegments - 1);
        }

    }

}
