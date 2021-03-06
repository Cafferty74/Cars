using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public float steeringSpeed;
    public float accBrakeSpeed;
    public float moveSpeed;
    public bool GameOver = false;

    Camera cam;
    float rotationRad;
    float dx, dy;
    Vector3 acceleration;
    public float offcetToCamera = 3f;

    void Start()
    {
        cam = Camera.main;
    }
    void CalcMovement(float inputY)
    {
        dx = -Mathf.Sin(rotationRad);
        dy = Mathf.Cos(rotationRad);
        // В Юнити нулевой угол поворота повернут на 90, поэтому проекции инвертированы!!!
        acceleration = new Vector3(dx, dy)*accBrakeSpeed* inputY;
        offcetToCamera -= acceleration.y * Time.deltaTime;

    }
    void Move()
    {
        transform.position += new Vector3(dx, dy) * moveSpeed * Time.deltaTime;
    }

    void Update()
    {
        if (GameOver)
            return;
        var inputSteer = Input.GetAxis("Horizontal");
        var inputSpeed = Input.GetAxis("Vertical");
        transform.Rotate(0, 0, -inputSteer * steeringSpeed * Time.deltaTime);
        CalcRotation();
        CalcMovement(inputSpeed);
        Move();

        

        var camPosition = cam.transform.position;
        camPosition.y = transform.position.y;
        cam.transform.position = camPosition;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       gameManager.HandleCollision(collision.gameObject);
    }

    void CalcRotation()
    {
        var rotation = transform.rotation.eulerAngles.z;
        rotationRad = rotation / 360 * 2 * Mathf.PI;
        Debug.Log("rotation " + rotationRad);
    }


}
