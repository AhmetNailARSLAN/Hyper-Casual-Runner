using UnityEngine;

public class CollectableResources : MonoBehaviour
{
    [SerializeField] private int resourceAmount = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<ResourceManager>().AddResource(resourceAmount);
            SoundManager.Instance.PlayCollectSound();
            Destroy(gameObject);
        }
    }
}
