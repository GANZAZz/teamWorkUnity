using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 2f;
    public Transform _fetPos;
    public LayerMask _whatIsGround;

    private bool _turnFacing;
    private bool _isGrounded;
    private Rigidbody2D _rb;
    public float _checkRadius = 0.3f;

    

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        JumpLogic();
    }

    void FixedUpdate()
    {
        Flip();
        MovementLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(moveHorizontal * Speed, _rb.velocity.y);
    }

    private void JumpLogic()
    {
        _isGrounded = Physics2D.OverlapCircle(_fetPos.position, _checkRadius, _whatIsGround);

        if(_isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector2.up * JumpForce;
        }
    }

    public void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}