using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameMode currentMode; // Aktif oyun durumu

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

        currentMode = GameMode.Running; // Denemek i�in runningde ba�lat�yoruz
    }

    public void OnMenu()
    {
        currentMode = GameMode.Menu;

        // Men� i�in Baz� UI mekanikleri

    }

    public void OnGameRunning()
    {
        currentMode = GameMode.Running;
    }

    public void OnGameLost()
    {
        currentMode = GameMode.Lost;

        // oyun sonu ekran� i�in baz� ui mekanikleri
    }


    public void OnGameWon()
    {
        currentMode = GameMode.Won;

    }

}
public enum GameMode
{
    Menu,
    Running,
    Won,
    Lost
}
