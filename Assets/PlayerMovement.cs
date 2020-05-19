using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float MovementSpeed = 10f;
    public float gravitySpeed = 9.8f;

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardVector = Vector3.Normalize(Vector3.ProjectOnPlane(GameManager.currentCamera.transform.forward, Vector3.up));

        Vector3 vert = Input.GetAxisRaw("Vertical") * forwardVector;
        Vector3 hor = Input.GetAxisRaw("Horizontal") * (Quaternion.Euler(0, 90, 0) * forwardVector);

        Vector3 movementDir = Vector3.Normalize(vert + hor);

        characterController.Move(movementDir * MovementSpeed * Time.deltaTime + (Vector3.down * gravitySpeed * Time.deltaTime));


    }
}
