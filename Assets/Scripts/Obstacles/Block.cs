using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private int resource = 1;

    [Header("Referances")]
    [SerializeField] private TextMeshPro resourceText;

    private void Start()
    {
        resourceText.text = resource.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Duvarý geçebildi mi?
            if (collision.gameObject.GetComponent<ResourceManager>().ReduceResource(resource))
            {
                // Bazý efektler eklenebilir
                Destroy(gameObject);
            }
            else
            {
                // Oyunu sonlandýracak mekanikler
                GameManager.Instance.OnGameLost();
            }
            
        }
    }

}
