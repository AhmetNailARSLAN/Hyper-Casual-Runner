using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Karakter Finish alan�na geldi�inde

            SoundManager.Instance.PlayFinishSound(); // Biti� sesini �al
            GameManager.Instance.OnGameWon();

        }
    }
}
