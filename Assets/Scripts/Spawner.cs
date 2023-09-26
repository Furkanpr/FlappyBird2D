using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f; // Saniyede ne kadar boru üreteceğini belirler
    public float minHeight = -1f; // borunun minumum boyutunu belirler
    public float maxHeight = 2f; // borunun maksimum boyutunu belirler

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    // fonksiyonu tekrar tekrar çağırmamızı sağlar hızınıda spawnRate belirler.

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    // Sürekli çağırdığımız fonksiyonu çağırmayı durdurur
    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        // Boruları klonlama işlemini yapar ve rotasyon olmadığını belirtir
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        // boruların yukarı ve aşağıya göre spawn konumu ayarlar.
    }

}
