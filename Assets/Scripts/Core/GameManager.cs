using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Canvas canvas;
    public GameObject managers;

    public GameMode currentMode; // Aktif oyun durumu

    private int currentLevel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        OnGameRunning();
    }

    public void OnMenu()
    {
        currentMode = GameMode.Menu;

        // Menü için Bazý UI mekanikleri

    }

    public void OnGameRunning()
    {
        //Game Modu Running olarak deðiþtir ve karakteri koþtur
        currentMode = GameMode.Running;
        PlayerAnimations.Instance.RunAnimation();
    }

    public void OnGameFailed()
    {
        //Game Modu Failed olarak deðiþtir ve kaybetme mekanikleri uygula
        currentMode = GameMode.Failed;
        PlayerAnimations.Instance.LoseAnimation();
        GameUIManager.Instance.OpenFailPanel(true);
        SoundManager.Instance.PlayCrashSound();
    }


    public void OnGameWon()
    {
        //Game Modu won olarak deðiþtir ve kazanma mekanikleri
        currentMode = GameMode.Won;
        PlayerAnimations.Instance.WinAnimation();
        GameUIManager.Instance.OpenWinPanel(true);
    }

    public void RestartGame()
    {
        // Fail Panelini kapat
        GameUIManager.Instance.OpenFailPanel(false);

        // Bulunduðumuz sahneyi yeniden Baþlatýr
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        OnGameRunning();
    }

    public void NextLevel()
    {
        // Paneli geri kapat
        GameUIManager.Instance.OpenWinPanel(false);

        // Yeni sahneye geçerken kaybolmasýný istemediðimiz objeler
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(managers);

        // Bir sonraki leveli yükle
        SceneManager.LoadScene(currentLevel + 1);
        currentLevel++;

        // Tekrardan koþu moduna geçmek için
        OnGameRunning();
    }

}
public enum GameMode
{
    Menu,
    Running,
    Won,
    Failed
}
