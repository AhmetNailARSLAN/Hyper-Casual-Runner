using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resourceText; // Kaynak texti

    private int currentResource = 0; // Toplam kaynak

    private void Start()
    {
        resourceText.text = currentResource.ToString();
    }

    // Kaynak toplama
    public void AddResource(int resourceCount)
    {
        currentResource += resourceCount;
        resourceText.text = currentResource.ToString();
    }

    // Kaynak kaybetme
    public void ReduceResource(int resourceCount)
    {
        currentResource -= resourceCount;
        if (currentResource < 0) currentResource = 0;
        resourceText.text = currentResource.ToString();
    }
    // Kaynak �arpma
    public void MultiplyResource(int resourceCount)
    {
        currentResource *= resourceCount;
        resourceText.text = currentResource.ToString();
    }
    // Kaynak b�lme
    public void DivideResource(int resourceCount)
    {
        currentResource /= resourceCount;
        if (currentResource < 0) currentResource = 0;
        resourceText.text = currentResource.ToString();
    }

}
