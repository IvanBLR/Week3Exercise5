using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private GameObject _bridge;

    [SerializeField]
    private GameObject _chest;

    [SerializeField]
    private GameObject _potion;

    private NavMeshAgent _navMeshAgent;
    private Vector3 _destination;

    private Vector3 _chestPosition;

    private bool _isBroken;
    private bool _isOpend;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        _chestPosition = _chest.transform.position;
    }
    private void Update()
    {
        // Перемещаем персонажа в направлении _destination.
        _navMeshAgent.SetDestination(_destination);

        if (!Input.GetMouseButtonDown(0))
        {
            if (!_isBroken && transform.position.z > 5 && transform.GetComponent<Outline>().OutlineWidth < 2)
            {
                _bridge.GetComponent<Bridge>().Break();
                _isBroken = true;
            }
            if (!_isOpend && IsPlayerNearTheChest())
            {
                _chest.GetComponent<Chest>().Open();
                _isOpend = true;
            }

            return;
        }

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo))
            _destination = hitInfo.point;

      


    }
    private bool IsPlayerNearTheChest()
    {
        var minX = _chestPosition.x - 1;
        var maxX = _chestPosition.x + 1;

        var minZ = _chestPosition.z - 1;
        var maxZ = _chestPosition.z + 1;

        if (Enumerable.Range((int)minX + 1, (int)maxX - (int)minX - 1).Contains((int)transform.position.x) ||
            Enumerable.Range((int)minZ + 1, (int)maxZ - (int)minZ - 1).Contains((int)transform.position.z))
        {
            return true;
        }
        else return false;
    }

   
}