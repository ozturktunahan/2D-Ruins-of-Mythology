using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeDamage : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        DamageEnemyPL(other);
    }

    public void DamageEnemyPL(Collision2D other)
    {
        if(other.transform.tag == "Player"){
            other.transform.GetComponent<PlayerMovement>().DecPlayerHP(damage);
        }
    }
    
}