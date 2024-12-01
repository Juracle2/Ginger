using UnityEngine;

public class CloudGroupMovement2 : MonoBehaviour
{
    public float speed = 2f; //rychlost
    private float screenWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //šířka obrazovky SS
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        // Projdi každého potomka (mraky) a posuň je
        foreach (Transform cloud in transform)
        {
            cloud.Translate(Vector3.right * speed * Time.deltaTime);

            // Resetuj pozici, pokud zmizí z obrazovky
            if (cloud.position.x >= screenWidth + 1f)
            {
                float newStartPosition = -screenWidth - 1f;
                cloud.position = new Vector3(newStartPosition, cloud.position.y, cloud.position.z);
            }
        }
    }
}
