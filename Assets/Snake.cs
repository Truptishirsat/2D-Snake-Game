
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
    public bool isActiveShield;

    public bool isSpeedActive;
    public float cooldown = 3f;

    public int score = 5;

    private float timer = 0.0f;
    private Shield shield;
    public List<Transform> segments = new List<Transform>();

   
    private enum State{
        Alive,
        Dead
    }
    private State state;
   

    void Awake()
    {
        shield = FindObjectOfType<Shield>();
        isActiveShield = false;
        isSpeedActive = false;

    }
    void Start()
    {
        state = State.Alive;
        ResetState();
    }

    void Update()
    {
        if(isActiveShield == true || isSpeedActive == true)
        {
            timer += Time.deltaTime;
        }
        else{
            timer = 0.0f;
        }
        if(timer >= cooldown)
        {
            isActiveShield = false;
            isSpeedActive = false;
            Time.fixedDeltaTime = 0.08f;
            timer = 0.0f;
        }
        
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
            if(!isActiveShield)
            {
                state = State.Dead;
            }
        }else if(other.tag == "MassGainerFood")
        {
            GrowSnake(increaseLength);
        }else if(other.tag == "MassBurnerFood")
        {   
            score -= 2;
            ShrinkSnake(segments.Count);
            
        }else if(other.tag == "Shield")
        {
            if(isActiveShield == true)
            {
               if(timer >= 3f)
               {
                    isActiveShield = false;
                    state = State.Alive;
               }
            }
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
