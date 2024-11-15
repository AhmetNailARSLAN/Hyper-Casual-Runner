using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; // Takip edilecek oyuncunun transformu
    [SerializeField] private Vector3 offset; // Kamera ile oyuncu aras�ndaki mesafe
    [SerializeField] private float followSpeed = 10f; // Kamera takip h�z�n� ayarlamak i�in

    private void LateUpdate()
    {
        // Hedef pozisyonu hesapla (oyuncunun pozisyonu + ofset)
        Vector3 targetPosition = player.position + offset;

        // Kameray� yumu�ak bir �ekilde hedef pozisyona ta��mak i�in Lerp kullan
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
