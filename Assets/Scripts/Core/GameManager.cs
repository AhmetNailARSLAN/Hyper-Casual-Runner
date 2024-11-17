using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameMode currentMode; // Aktif oyun durumu
    private PlayerAnimations playerAnimations;

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

        playerAnimations = FindAnyObjectByType<PlayerAnimations>();

        OnGameRunning(); // Denemek için runningde baþlatýyoruz
    }

    public void OnMenu()
    {
        currentMode = GameMode.Menu;

        // Menü için Bazý UI mekanikleri

    }

    public void OnGameRunning()
    {
        currentMode = GameMode.Running;
        playerAnimations.RunAnimation();
    }

    public void OnGameLost()
    {
        currentMode = GameMode.Lost;
        playerAnimations.LoseAnimation();
        // oyun sonu ekraný için bazý ui mekanikleri
    }


    public void OnGameWon()
    {
        currentMode = GameMode.Won;
        playerAnimations.WinAnimation();
    }

}
public enum GameMode
{
    Menu,
    Running,
    Won,
    Lost
}
