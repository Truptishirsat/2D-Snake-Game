using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "powerups/shieldeffect")]
public class ShieldPowerUp : PowerUpsEffect
{
    private Shield shield;
    private Snake snake;
    public float period = 2f;
    public override void Apply(GameObject target)
    {
        snake = target.GetComponent<Snake>();
        snake.isActiveShield = true;
    }

   
}
