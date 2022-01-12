using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float strafeSpeed;

    private void Update()
    {
        MoveForward(speed);
        if(Input.GetKey(KeyCode.D))
        {
            MoveRight(strafeSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft(strafeSpeed);
        }
    }


    public void MoveForward(float speed)
    {
        if (GameManager.instance.gameRunning)
        {
            // this code makes movement smooth and frame independent
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            // transform.Translate(Vector3.forward * Time.deltaTime * GameManager.instance.arrowSpeed);

        }
    }

    public void MoveLeft(float strafeSpeed)
    {
        if (transform.position.x > (-1.28f) && GameManager.instance.gameRunning)
        {
            transform.Translate(Vector2.left * strafeSpeed * Time.deltaTime);
        }
    }

    public void MoveRight(float strafeSpeed)
    {
        if (transform.position.x < 1.3f && GameManager.instance.gameRunning)
        {
            transform.Translate(Vector2.right * strafeSpeed * Time.deltaTime);
        }

    }
}
