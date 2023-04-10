using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "powerups/speedeffect")]
public class Speedpowerup : PowerUpsEffect
{
    private Snake snake;
    public override void Apply(GameObject target)
    {
        snake = target.GetComponent<Snake>();
        snake.isSpeedActive = true;
        Time.fixedDeltaTime = 0.04f;
    }
}

