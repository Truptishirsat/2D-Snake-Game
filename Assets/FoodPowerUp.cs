
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "powerups/foodeffect")]
public class FoodPowerUp : PowerUpsEffect
{
   private Snake snake;
   public override void Apply(GameObject target)
    {
        snake = target.GetComponent<Snake>();
        snake.score = 2 * snake.score; 
        Debug.Log("Score:" + snake.score);
    }
}
