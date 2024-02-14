using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform teleportDestination; // Teleportasyon hedefi

    public void TeleportPlayerToStartPosition(Transform playerTransform, Vector3 position)
    {
        playerTransform.position = position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.TeleportToStartPosition(teleportDestination.position);
            }
        }
    }
}