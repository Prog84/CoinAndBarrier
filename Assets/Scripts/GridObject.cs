using UnityEngine;

public class GridObject : MonoBehaviour
{
    [SerializeField] private GridLayer _layer;
    [SerializeField] private NameObject _nameObject;
    [SerializeField] private int _chance;

    public GridLayer Layer => _layer;

    public NameObject NameObject => _nameObject;

    public int Chance => _chance;

    private void OnValidate()
    {
        _chance = Mathf.Clamp(_chance, 1, 100);
    }
}
