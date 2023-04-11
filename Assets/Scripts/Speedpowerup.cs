using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "powerups/speedeffect")]
public class Speedpowerup : PowerUpsEffect
{
    private Snake snake;
    private SnakeB snakeB;
    public override void Apply(GameObject target)
    {
        
        switch(target.name)
        {
            case "Snake":
                snake = target.GetComponent<Snake>();
                snake.isSpeedActive = true;
                Time.fixedDeltaTime = 0.04f;
                
                break;
            case "SnakeB":
                snakeB = target.GetComponent<SnakeB>();
                snakeB.isSpeedActive = true;
                Time.fixedDeltaTime = 0.04f;
                
                break;

        }
    }
}

