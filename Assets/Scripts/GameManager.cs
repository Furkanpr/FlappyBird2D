using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Spawner spawner;

    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public int score { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        // kare h�z�n� ayarlar

        player = FindObjectOfType<Player>(); 
        spawner = FindObjectOfType<Spawner>();

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        // Skoru art�rabilmek i�in stringi integera d�n��t�r�r. 

        playButton.SetActive(false);
        gameOver.SetActive(false);

        // Butonlar� pasif yapar

        Time.timeScale = 1f;
        player.enabled = true;
        // Oyun �al���r durumunda olur

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
        // oyun durur ve butonlar aktif hale gelir
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        // oyun durur.
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        // Borular�n aras�ndan ge�ildi�inde skor art�r�r.
    }

}
