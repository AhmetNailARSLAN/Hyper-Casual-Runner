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
            // Duvar� ge�ebildi mi?
            if (collision.gameObject.GetComponent<ResourceManager>().ReduceResource(resource))
            {
                // Baz� efektler eklenebilir
                Destroy(gameObject);
            }
            else
            {
                // Oyunu sonland�racak mekanikler
                GameManager.Instance.OnGameLost();
            }
            
        }
    }

}
