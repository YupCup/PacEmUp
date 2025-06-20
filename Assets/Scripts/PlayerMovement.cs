using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;

    Vector2 inputVector;

    void Update() {
        inputVector = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        transform.position += (Vector3)inputVector * speed * Time.deltaTime;

        Vector3 position = transform.position;
        if (transform.position.x < -18) position.x = -18;
        if (transform.position.x > 18) position.x = 18;

        if (transform.position.y < -11) position.y = 11;
        if (transform.position.y > 11) position.y = -11;

        transform.position = position;
    }
}
