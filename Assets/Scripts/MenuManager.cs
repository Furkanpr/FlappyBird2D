using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour

{
    public static bool gameIsPause;
    public GameObject Panel;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }
    // Ana men�de oyna tu�una bas�ld���nda oyun sahnesine ge�i� yapar

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("test");
    }
    // Ana men�de oyundan ��k tu�una bas�ld���nda uygulamadan ��k�� yapar.


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPause)
                Resume();
            else
                Pause();
        }
                // Klavyede "P" tu�una bas�ld���nda pause fonksiyonu �al���p oyun durur. e�er oyun durmu�sa devam eder oyun.

    }

        public void Resume()
        {
            Panel.SetActive(false);
            Time.timeScale = 1f;
            gameIsPause = false;
        }
    // Oyun durmu�sa devam ettirir, duraktlatma men�s�n� pasif yapar.
        public void Pause()
        {
            Panel.SetActive(true);
            Time.timeScale = 0f;
            gameIsPause = true;
        }
    // oyunu durdurur, duraklatma men�s�n� aktif yapar.

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    // duraklatma men�s�n�nden ana men�ye ge�i�ini yapar

    }


