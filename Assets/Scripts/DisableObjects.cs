using UnityEngine;

public class DisableObjects : MonoBehaviour
{
    [SerializeField] private float _leftDisablePointX = -0.05f;

    private Camera _camera;


    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(_leftDisablePointX, 0));
        transform.position = new Vector3(disablePoint.x, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }
}
