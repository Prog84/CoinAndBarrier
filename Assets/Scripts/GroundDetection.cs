using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public bool IsGrounded { get; private set; }
    
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Ground ground))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Ground ground))
        {
            IsGrounded = false;
        }
    }
}
