using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;
    public Animator animator;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI playerScoreText2;
    public int coinscore;
    public int olivescore = 3;
    float speedAmount = 5f;
    float jumpAmount = 6f;
    private Vector3 respawnPoint;
    public GameObject gameOverPanel;
    public GameOverScreen gameOverScreen;

    public void TeleportToStartPosition(Vector3 position)
    {
        transform.position = position;
    }

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        coinscore = 0;
        olivescore = 3;
        respawnPoint = transform.position;
        animator = GetComponent<Animator>();

        playerScoreText = GameObject.Find("PlayerScoreText").GetComponent<TextMeshProUGUI>();
        playerScoreText2 = GameObject.Find("PlayerScoreText2").GetComponent<TextMeshProUGUI>();
        gameOverScreen = FindObjectOfType<GameOverScreen>();
    }

    void Update()
    {
        playerScoreText.text = coinscore.ToString();
        playerScoreText2.text = olivescore.ToString();
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.velocity.y, 0))
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NextLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawnPoint = transform.position;

            // Yeni sahneye geçildiğinde oyuncuyu doğru konumlandır
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.TeleportToStartPosition(respawnPoint);
                }
            }
        }
    }

    public void DecPlayerHP(int amount)
    {
        if (olivescore <= 0)
        {
            return;
        }

        olivescore -= amount;
        if (olivescore <= 0)
        {
            animator.SetTrigger("isDeath");
            if (gameOverScreen != null && !gameOverScreen.gameOverPanel.activeSelf)
            {
                gameOverScreen.ShowGameOverScreen();
            }
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
