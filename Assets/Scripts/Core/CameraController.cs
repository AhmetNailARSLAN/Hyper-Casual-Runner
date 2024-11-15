using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; // Takip edilecek oyuncunun transformu
    [SerializeField] private Vector3 offset; // Kamera ile oyuncu arasýndaki mesafe
    [SerializeField] private float followSpeed = 10f; // Kamera takip hýzýný ayarlamak için

    private void LateUpdate()
    {
        // Hedef pozisyonu hesapla (oyuncunun pozisyonu + ofset)
        Vector3 targetPosition = player.position + offset;

        // Kamerayý yumuþak bir þekilde hedef pozisyona taþýmak için Lerp kullan
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
