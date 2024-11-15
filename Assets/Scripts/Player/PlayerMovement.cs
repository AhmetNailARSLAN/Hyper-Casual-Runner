using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Hareket Ayarlarý")]
    [SerializeField] private float limitX = 5f;         // Sað-sol hareket sýnýrý
    [SerializeField] private float sidewaySpeed = 10f;  // Sað-sol hýz
    [SerializeField] private float forwardSpeed = 5f;   // Ýleri hareket hýzý

    private float targetX; // Hedef pozisyon (X ekseni)

    private void Update()
    {
        // Oyuncunun ileri hareketi
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Eðer fareye týklanýyorsa, hareketi kontrol et
        if (Input.GetMouseButton(0))
        {
            HandleSidewayMovement();
        }
    }

    private void HandleSidewayMovement()
    {
        // Ekranýn ortasýna göre fare konumunu normalize et (-1 ile 1 arasýnda bir deðer)
        float mouseXNormalized = (Input.mousePosition.x / Screen.width) * 2 - 1;

        // Sað-sol limitini uygula
        targetX = Mathf.Clamp(mouseXNormalized * limitX, -limitX, limitX);

        // Mevcut pozisyonu hedef pozisyona yumuþakça hareket ettir
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Lerp(currentPosition.x, targetX, sidewaySpeed * Time.deltaTime);

        // Yeni pozisyonu uygula
        transform.position = currentPosition;
    }
}
