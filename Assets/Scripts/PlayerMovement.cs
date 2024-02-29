using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;

    [SerializeField] private int movementSpeed;
    [SerializeField] private int jumpForce;
    [SerializeField] private LayerMask groundLayer;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        //move left-right
        _rigidbody2D.velocity = new Vector2(horizontalInput * movementSpeed, _rigidbody2D.velocity.y);

        //player jump
        if (IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            }
                
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(
            _boxCollider2D.bounds.center, _boxCollider2D.bounds.size,
            0, Vector2.down, 0.1f, groundLayer);
        return raycastHit2D.collider != null;
    }
}
