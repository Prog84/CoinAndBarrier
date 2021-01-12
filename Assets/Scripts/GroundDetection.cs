using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    private bool _isGrounded;
    public bool IsGrounded => _isGrounded;

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Ground ground))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Ground ground))
        {
            _isGrounded = false;
        }
    }
}
