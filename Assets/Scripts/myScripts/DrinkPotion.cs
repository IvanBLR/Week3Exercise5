using UnityEngine;

public class DrinkPotion : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.transform.tag == "Player")
        {
            transform.GetComponent<MeshRenderer>().enabled = false;
            _player.GetComponent<Outline>().OutlineWidth = 2;
        }
    }
}
