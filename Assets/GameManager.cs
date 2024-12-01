using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player; // Odkaz na GingerBread
    public Canvas gameOverCanvas; // Odkaz na Game Over Canvas
    public float fallThreshold = -10f; // Výška, při které je Game Over
    private AudioSource audioSource; //audio pro over
    private bool gameOverTriggered = false;
    public Transform spawnPoint;
    public GameObject playerPrefab;

    void Start()
    {
        // Pokud už existuje GingerBread, přesun ho na spawnPoint
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = spawnPoint.position;
        }
        else
        {
            // Pokud GingerBread neexistuje (např. první načtení scény), vytvoř ho
            Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
             }

            Debug.Log("GameManager Start triggered - Canvas disabled and game initialized");
        // Skryj Game Over Canvas na začátku
        gameOverCanvas.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Debug.Log("Time.timeScale = " + Time.timeScale);
        if (player != null)
        // Kontrola, jestli GingerBread spadl pod určitou výšku
        if (player.position.y <= fallThreshold)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (gameOverTriggered) return; // Pokud už byl Game Over, zastav další akce

        gameOverTriggered = true; // Nastav flag, aby se Game Over provedl jen jednou
        Debug.Log("Game Over triggered");

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
            
            
        // Zobraz Game Over Canvas
        gameOverCanvas.enabled = true;

        // Zastav pohyb hry (pauza)
        Time.timeScale = 1f;
    }

    public void PlayAgain()
    {
        Debug.Log("PlayAgain triggered - Time scale set to 1");
        // Obnov čas
        Time.timeScale = 1f;

        // Načti aktuální scénu znovu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
