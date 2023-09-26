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
    // Ana menüde oyna tuþuna basýldýðýnda oyun sahnesine geçiþ yapar

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("test");
    }
    // Ana menüde oyundan çýk tuþuna basýldýðýnda uygulamadan çýkýþ yapar.


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPause)
                Resume();
            else
                Pause();
        }
                // Klavyede "P" tuþuna basýldýðýnda pause fonksiyonu çalýþýp oyun durur. eðer oyun durmuþsa devam eder oyun.

    }

        public void Resume()
        {
            Panel.SetActive(false);
            Time.timeScale = 1f;
            gameIsPause = false;
        }
    // Oyun durmuþsa devam ettirir, duraktlatma menüsünü pasif yapar.
        public void Pause()
        {
            Panel.SetActive(true);
            Time.timeScale = 0f;
            gameIsPause = true;
        }
    // oyunu durdurur, duraklatma menüsünü aktif yapar.

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    // duraklatma menüsününden ana menüye geçiþini yapar

    }


