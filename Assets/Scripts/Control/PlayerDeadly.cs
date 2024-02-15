using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadly : MonoBehaviour
{
    public bool DeadlyToFire;
    public bool DeadlyToWater;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger)
        {
            return;
        }

        PlayerStateSingleton.PlayerState.PlayerType? type = other.gameObject.GetComponent<PlayerController>()?.type;

        if (type == null)
        {
            return;
        }


        
        bool playerIsWater = type == PlayerStateSingleton.PlayerState.PlayerType.WATER;
        bool playerIsFire = type == PlayerStateSingleton.PlayerState.PlayerType.FIRE;
        bool isDeadlyToCollidingPlayer = (playerIsWater && DeadlyToWater) || (playerIsFire && DeadlyToFire);

        if (isDeadlyToCollidingPlayer)
        {
            if (PlayerStateSingleton.Instance.Get((PlayerStateSingleton.PlayerState.PlayerType) type).InvincibilityFrames == 0)
            {
                PlayerStateSingleton.Instance.Get((PlayerStateSingleton.PlayerState.PlayerType) type).IsDead = true;
            }
        }
    }
}
