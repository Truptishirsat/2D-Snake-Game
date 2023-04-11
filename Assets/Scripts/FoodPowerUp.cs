
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "powerups/foodeffect")]
public class FoodPowerUp : PowerUpsEffect
{
   private Snake snake;
   private SnakeB snakeB;
   public override void Apply(GameObject target)
    {

        switch(target.name)
        {
            case "Snake":
                snake = target.GetComponent<Snake>();
                snake.score = 2 * snake.score; 
                break;

            case "SnakeB":
                snakeB = target.GetComponent<SnakeB>();
                snakeB.score = 2 * snakeB.score; 
                break;
        }
        
    }
}
