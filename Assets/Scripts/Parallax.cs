using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f; // Animasyon geçiş hızını belirler

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update() // Sürekli çalışan fonksiyondur
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);

        // Belirlenen spriteler belli bir hızda sırasıyla oynatır
    }

}
