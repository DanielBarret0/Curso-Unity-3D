using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rig;
    public float speed = 5f;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;  // frente
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += -transform.forward; // trás
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += -transform.right;  // esquerda
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;   // direita
        }

        // normaliza para manter velocidade constante na diagonal
        moveDirection = moveDirection.normalized * speed;

        // Mantém a velocidade vertical original (gravedad ou pulo)
        rig.linearVelocity = new Vector3(moveDirection.x, rig.linearVelocity.y, moveDirection.z);
}
}