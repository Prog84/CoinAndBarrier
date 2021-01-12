using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject[] _prefabTemplates;
    [SerializeField] private int _capacity;

    private Camera _camera;
    private GridObject _spawned;
    private List<GridObject> _pool = new List<GridObject>();
    

    protected void Initialize()
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            foreach (var prefab in _prefabTemplates)
            {
                _spawned = Instantiate(prefab, _container.transform).GetComponent<GridObject>();
                _spawned.gameObject.SetActive(false);
                _pool.Add(_spawned);
            }
        }
    }

    protected bool TryGameObject(NameObject nameObject, out GridObject result) 
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false && p.NameObject == nameObject);
        return result != null;
    }

    protected void DisableObjectAboardScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (var item in _pool)
        {
            if (item.gameObject.activeSelf == true)
            {
                if (item.transform.position.x < disablePoint.x)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
    }
}
