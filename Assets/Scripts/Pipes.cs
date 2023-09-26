using UnityEngine;

public class Pipes : MonoBehaviour
{
    public Transform top; // üst boru
    public Transform bottom; // alt boru

    public float speed = 5f; // boruların geliş hızı
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        // Kameranın açısını belirlenir
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }
    // Scripte koyulan objeyi sola haraket ettirir, eğer obje kamera açısından çıkarsa obje yok edilir
}
