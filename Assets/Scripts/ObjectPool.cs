using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private GridObject[] _templates;
    [SerializeField] private int _capacity;

    private GridObject _spawned;
    private Dictionary<GameObject, GridObject> _pool = new Dictionary<GameObject, GridObject>();

    public void Initialize()
    {
        for (int templateIndex = 0; templateIndex < _templates.Length; templateIndex++)
        {
            for (int capacityIndex = 0; capacityIndex < _capacity; capacityIndex++)
            {

                _spawned = Instantiate(_templates[templateIndex], _container.transform);
                _spawned.gameObject.SetActive(false);
                _pool.Add(_spawned.gameObject, _templates[templateIndex]);

            }
        }
    }

    public void TryPlace(GridObject gridObject, Vector3 position)
    {
        var result = _pool.FirstOrDefault(p => p.Key.activeSelf == false && p.Value == gridObject);
        result.Key.SetActive(true);
        result.Key.transform.position = position;
    }
}
