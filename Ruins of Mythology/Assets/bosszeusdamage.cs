using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosszeusdamage : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        DamagePlayer(other);
    }

    private void DamagePlayer(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.DecPlayerHP(damage);
                //playerMovement.PlayHurtAnimation();
            }
        }
    }
}