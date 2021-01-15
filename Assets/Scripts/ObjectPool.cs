using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private GridObject[] _templates;
    [SerializeField] private int _capacity;

    private GridObject _spawned;
    private List<GridObject> _pool = new List<GridObject>();
    
    public void Initialize()
    {
        for (int i = 0; i < _capacity; i++)
        {
            foreach (var prefab in _templates)
            {
                _spawned = Instantiate(prefab, _container.transform);
                _spawned.gameObject.SetActive(false);
                _pool.Add(_spawned);
            }
        }
    }

    public bool TryGameObject(string TypeObject, out GridObject result) 
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false && p.TypeObject == TypeObject);
        return result != null;
    }

    public void TryDisableObject(float disablePointX)
    {
        foreach (var item in _pool)
        {
            if (item.gameObject.activeSelf == true)
            {
                if (item.transform.position.x < disablePointX)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
    }
}
