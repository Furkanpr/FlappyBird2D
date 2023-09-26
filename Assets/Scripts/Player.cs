using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    public float strength = 5f;
    public float gravity = -9.81f;
    public float tilt = 5f;

    private Vector3 direction;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Spriterenderer compenentini erişmemizi sağlar
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        // Animasyonları sürekli 0.15 hızıyla çağırır.
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
        // Oyun bittiğinde başlangıç konumumuzda başlamasını sağlar

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        // Boşluk tuşu ve farenin sağ tıkına basınca işleve girer
        {
            direction = Vector3.up * strength;
            // kuşun 5f gücünde yukarıya doğru hareket etmesini sağlar
        }

        
        direction.y += gravity * Time.deltaTime;
        // yerçekimini her karede y ekseninde uygulamızı sağlar.

        transform.position += direction * Time.deltaTime;
        // güncel pozisyonuna göre haraket eder.

        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;

        // Kuşun eğimli haraket etmesini sağlar

    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0) {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }
         // Eklenen spriteleri animasyon biçimde sırasıyla oynatır.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Engel")) {
            FindObjectOfType<GameManager>().GameOver();
            // engel tagını çarptığında GameOver fonksiyonu devreye girer.
        } else if (other.gameObject.CompareTag("Skor")) {
            FindObjectOfType<GameManager>().IncreaseScore();
            // Skor tagını çarptığında IncreaseScore fonksiyonu devreye girer.
        }
    }

}
