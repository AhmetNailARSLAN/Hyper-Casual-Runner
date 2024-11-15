using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Hareket Ayarlar�")]
    [SerializeField] private float limitX = 5f;         // Sa�-sol hareket s�n�r�
    [SerializeField] private float sidewaySpeed = 10f;  // Sa�-sol h�z
    [SerializeField] private float forwardSpeed = 5f;   // �leri hareket h�z�

    private float targetX; // Hedef pozisyon (X ekseni)

    private void Update()
    {
        // Oyuncunun ileri hareketi
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // E�er fareye t�klan�yorsa, hareketi kontrol et
        if (Input.GetMouseButton(0))
        {
            HandleSidewayMovement();
        }
    }

    private void HandleSidewayMovement()
    {
        // Ekran�n ortas�na g�re fare konumunu normalize et (-1 ile 1 aras�nda bir de�er)
        float mouseXNormalized = (Input.mousePosition.x / Screen.width) * 2 - 1;

        // Sa�-sol limitini uygula
        targetX = Mathf.Clamp(mouseXNormalized * limitX, -limitX, limitX);

        // Mevcut pozisyonu hedef pozisyona yumu�ak�a hareket ettir
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Lerp(currentPosition.x, targetX, sidewaySpeed * Time.deltaTime);

        // Yeni pozisyonu uygula
        transform.position = currentPosition;
    }
}
