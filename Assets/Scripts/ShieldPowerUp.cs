using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "powerups/shieldeffect")]
public class ShieldPowerUp : PowerUpsEffect
{
    private Shield shield;
    private Snake snake;

    private SnakeB snakeB;
    public float period = 2f;
    public override void Apply(GameObject target)
    {
    
        switch(target.name)
        {
            case "SnakeA":
                snake = target.GetComponent<Snake>();
                snake.isActiveShield = true;
                break;

            case "SnakeB":
                snakeB = target.GetComponent<SnakeB>();
                snakeB.isActiveShield = true;
                break;
        }
    }

   
}
