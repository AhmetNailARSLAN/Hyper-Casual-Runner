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
        // oyun baþladýðýnda random bir renk alsýn
        int i = Random.Range(0, materials.Length);
        gameObject.GetComponent<MeshRenderer>().material = materials[i];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.Instance.PlayBreakSound();
            // Duvarý geçebildi mi?
            if (collision.gameObject.GetComponent<ResourceManager>().ReduceResource(resource))
            {
                // Duvara kýrdýðýnda
                collision.gameObject.GetComponent<PlayerAnimations>().KickAnimaiton();

                Destroy(gameObject);
            }
            else
            {
                // Duvara çarptýðýnda
                // Oyunu sonlandýracak mekanikler
                GameManager.Instance.OnGameLost();
            }
            
        }
    }

}
