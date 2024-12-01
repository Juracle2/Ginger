using UnityEngine;

public class DoorController : MonoBehaviour
{
    public SpriteRenderer doorSprite; // Odkaz na sprite renderer dveří
    public Sprite openDoor;    // Sprite pro otevřené dveře
    public Sprite closedDoor;  // Sprite pro zavřené dveře
    private bool isPlayerNearby = false; // Kontrola, jestli je GingerBread blízko
    private bool isDoorOpen = false; // Stav dveří
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D doorCollider;

    void Start()
    {
        // Ujistíme se, že dveře jsou zavřené na začátku
        doorSprite.sprite = closedDoor;
        spriteRenderer = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<BoxCollider2D>();
        spriteRenderer.sprite = closedDoor;
        doorCollider.enabled = true;
    }

    void Update()
    {
        // Kontrola vstupu hráče
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerNearby())
        {
            ToggleDoor();
        }
    }
    private bool IsPlayerNearby()
    {
        // Zkontroluj, jestli je hráč blízko dveří
        // Tohle předpokládá, že hráč má Tag "Player"
        Collider2D player = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Player"));
        return player != null;
    }

    private void ToggleDoor()
    {
        if (isDoorOpen)
        {
            // Zavři dveře
            spriteRenderer.sprite = closedDoor;
            doorCollider.enabled = true; // Aktivuj Collider
            isDoorOpen = false;
        }
        else
        {
            // Otevři dveře
            spriteRenderer.sprite = openDoor;
            doorCollider.enabled = false; // Deaktivuj Collider
            isDoorOpen = true;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kontrolujeme, zda objekt s tagem "Player" (GingerBread) vstoupil do triggeru
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true; // Hráč je blízko
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Když hráč opustí trigger
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false; // Hráč je pryč
        }
    }

    void OpenDoor()
    {
        isDoorOpen = true; // Nastavíme dveře jako otevřené
        doorSprite.sprite = openDoor; // Změníme sprite na otevřené dveře
        Debug.Log("Dveře jsou otevřené!");
        // Zde můžete přidat další logiku, např. zvuk otevření dveří nebo animaci
    }
}
