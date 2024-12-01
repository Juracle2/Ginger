using UnityEngine;
using UnityEngine.SceneManagement;

public class Reward : MonoBehaviour
{
    public string nextSceneName; // Jm�no sc�ny, kter� se m� na?�st

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kontrola kolize s hr�?em
        if (collision.CompareTag("Player"))
        {
            // Skryt� nebo zni?en� MilkReward
            gameObject.SetActive(false);
            Destroy(gameObject);

            // Na?ten� dal�� sc�ny
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
