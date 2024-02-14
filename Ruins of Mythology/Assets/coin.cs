using UnityEngine;
using UnityEngine.Audio;

public class coin : MonoBehaviour
{
    public AudioClip coinsound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = coinsound;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.coinscore += 1;
            audioSource.Play(); 
            gameObject.SetActive(false);
        }
    }
}
