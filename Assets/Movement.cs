using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float JumpStr;
    private bool isGrounded; // Sledujeme zda je perníček na zemi
    public float moveSpeed = 5f; // Rychlost pohybu
    private Rigidbody2D rb;
    private Vector3 localScale;
    public float speed = 1f;
    private AudioSource audioSource;
    public LayerMask groundLayer;
    public Transform groundCheck;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Pokud kolidujeme s objektem, který má tag "Ground", jsme na zemi
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale; // Uloží původní měřítko
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Pohyb do stran
        float moveInput = Input.GetAxis("Horizontal"); // Hodnota -1 (doleva) až 1 (doprava)
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Otočení postavy
        if (moveInput > 0) // Pohyb doprava
        {
            transform.localScale = new Vector3(Mathf.Abs(localScale.x), localScale.y, localScale.z);
        }
        else if (moveInput < 0) // Pohyb doleva
        {
            transform.localScale = new Vector3(-Mathf.Abs(localScale.x), localScale.y, localScale.z);
        }

        // Skákání pouze pokud jsme na zemi
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Přidej sílu pro skok
            rb.AddForce(Vector2.up * JumpStr, ForceMode2D.Impulse);

            // Pusť zvuk
            audioSource.Play();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}
