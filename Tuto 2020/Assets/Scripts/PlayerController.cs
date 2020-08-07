using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 jumpSpeed;

    [SerializeField]
    private float speed = 5f;

    private PlayerMotor motor;
    private ConfigurableJoint joint;
    private Animator animator;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    bool IsGrounded()
    {
        Vector3 dwn = transform.TransformDirection(Vector3.down);

        return (Physics.Raycast(transform.position, dwn, 1));
    }

    private void Update()
    {

        // On va calculer la vélocité du mouvement du joueur en un Vecteur 3D
        float _xMov = Input.GetAxis("Horizontal");
        float _zMov = Input.GetAxis("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical) * speed;

        motor.Move(_velocity);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumpSpeed.y;

            gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
        }
    }
}