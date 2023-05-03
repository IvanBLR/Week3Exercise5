using UnityEngine;

public class FireBurn : MonoBehaviour
{
    [SerializeField]
    private GameObject _fire;
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.transform.tag == "Player")
        {
            _fire.gameObject.SetActive(true);
            Destroy(transform.gameObject);
        }
    }
}
