using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

    [SerializeField] private ResourceManager _resourceManager;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject failPanel;

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

    }

    public void OpenWinPanel(bool val)
    {
        if (val)
        {
            winPanel.SetActive(true);
            _resourceManager =  FindAnyObjectByType<ResourceManager>();
            scoreText.text = "Score: " + _resourceManager.CurrentResource.ToString();
        }
        else
        {
            winPanel.SetActive(false);
        }

    }

    public void OpenFailPanel(bool val)
    {
        failPanel.SetActive(val);
    }

}
