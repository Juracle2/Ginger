using UnityEngine;
using UnityEngine.SceneManagement;

public class Reward : MonoBehaviour
{
    public string nextSceneName; // Jméno scény, která se má na?íst

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kontrola kolize s hrá?em
        if (collision.CompareTag("Player"))
        {
            // Skrytí nebo zni?ení MilkReward
            gameObject.SetActive(false);
            Destroy(gameObject);

            // Na?tení další scény
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
