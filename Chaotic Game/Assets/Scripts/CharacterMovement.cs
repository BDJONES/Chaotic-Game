using Unity.Netcode;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    public float speed = 5f;
    Animator characterAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            characterAnimator.SetBool("Walking", true);
            MoveForward();
        }
        else
        {
            characterAnimator.SetBool("Walking", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            characterAnimator.SetBool("Walking Backward", true);
            MoveBack();
        }
        else
        {
            characterAnimator.SetBool("Walking Backward", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            characterAnimator.SetBool("Strafing Left", true);
            MoveLeft();
        }
        else
        {
            characterAnimator.SetBool("Strafing Left", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            characterAnimator.SetBool("Strafing Right", true);
            MoveRight();
        }
        else
        {
            characterAnimator.SetBool("Strafing Right", false);
        }
    }

    void MoveForward()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
        Debug.Log("Moving Forward");
    }
    void MoveLeft()
    {
        transform.Translate(speed *  Time.deltaTime * Vector3.left);
        transform.Rotate(new Vector3(0, -90, 0));
        Debug.Log("Moving Left");
    }

    void MoveRight()
    {
        transform.Translate((speed / 4) * Time.deltaTime * -Vector3.left);
        Debug.Log("Moving Right");
    }

    void MoveBack()
    {
        transform.Translate((speed / 4) * Time.deltaTime * -Vector3.forward);
        Debug.Log("Moving Backward");
    }
}