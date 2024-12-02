using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Karakter Finish alanýna geldiðinde

            SoundManager.Instance.PlayFinishSound(); // Bitiþ sesini çal
            GameManager.Instance.OnGameWon();

        }
    }
}
