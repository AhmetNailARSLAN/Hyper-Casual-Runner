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
    [SerializeField] private Material[] materials;

    private void Start()
    {
        resourceText.text = resource.ToString();

        int i = Random.Range(0, materials.Length);
        gameObject.GetComponent<MeshRenderer>().material = materials[i];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Duvar� ge�ebildi mi?
            if (collision.gameObject.GetComponent<ResourceManager>().ReduceResource(resource))
            {
                // Baz� efektler eklenebilir
                collision.gameObject.GetComponent<PlayerAnimations>().KickAnimaiton();
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
