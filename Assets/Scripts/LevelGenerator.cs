using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GridObject[] _templates;
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private Transform _player;
    [SerializeField] private float _viewRange;
    [SerializeField] private float _cellSize;

    private HashSet<Vector3Int> _collisionsMatrix = new HashSet<Vector3Int>();
    private int _startPositionView = 0;

    private void Start()
    {
        _objectPool.Initialize();
    }

    private void Update()
    {
        FillRange(_player.position, _viewRange);
        _objectPool.DisableObjectAboardScreen();
    }

    private void FillRange(Vector3 center, float viewRange)
    {
        var cellCountOnAxis = (int)(viewRange / _cellSize);
        var fillAreaCenter = WorldToGridPosition(center);

        for (int x = _startPositionView; x < cellCountOnAxis; x++)
        {
            TryCreateOnLayer(GridLayer.Ground, fillAreaCenter + new Vector3Int(x, 0, 0));
            TryCreateOnLayer(GridLayer.OnGround, fillAreaCenter + new Vector3Int(x, 0, 0));
        }
    }

    private void TryCreateOnLayer(GridLayer layer, Vector3Int gridPosition)
    {
        gridPosition.y = (int)layer;

        if (_collisionsMatrix.Contains(gridPosition))
            return;
        else
           _collisionsMatrix.Add(gridPosition);

        var template = GetRandomTemplate(layer);

        if (template == null)
            return;

        var position = GridToWorldPosition(gridPosition);

        if (_objectPool.TryGameObject(template.TypeObject, out GridObject gridObject))
        {
            gridObject.gameObject.SetActive(true);
            gridObject.gameObject.transform.position = position;
        }
    }

    private GridObject GetRandomTemplate(GridLayer layer)
    {
        var variants = _templates.Where(template => template.Layer == layer);

        if (variants.Count() == 1)
            return variants.First();

        foreach (var template in variants)
        {
            if (template.Chance > Random.Range(0, 100))
            {
                return template;
            }
        }

        return null;
    }

    private Vector3 GridToWorldPosition(Vector3Int gridPosition)
    {
        return new Vector3(
            gridPosition.x * _cellSize,
            gridPosition.y * _cellSize,
            gridPosition.z * _cellSize);
    }

    private Vector3Int WorldToGridPosition(Vector3 worldPosition)
    {
        return new Vector3Int(
            (int)(worldPosition.x / _cellSize),
            (int)(worldPosition.y / _cellSize),
            (int)(worldPosition.z / _cellSize));
    }
}
