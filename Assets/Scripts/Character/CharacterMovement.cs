using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject planet;
    public float rotationSpeed = 12f;
    bool facingRight = true;
    
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        if (direction != 0) {
            planet.gameObject.transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime * direction));
            
            if (direction < 0 && facingRight || direction > 0 && !facingRight) {
                transform.eulerAngles = transform.eulerAngles + 180f * Vector3.up;
                facingRight = !facingRight;
            }
        }
    }
}
