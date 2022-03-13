using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyMath;

public class Mover : MonoBehaviour
{
    Vector3 displacement;
    [SerializeField] Vector3 velocity, accelaration, damping;
    float cameraSize;
    [SerializeField] Transform referencia;

    private void Start()
    {
        cameraSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
    }
    private void Update()
    {
        Move();
        CheckCollisions();
    }
    public void Move()
    {
        accelaration = referencia.position - transform.position;
        velocity = velocity + accelaration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        transform.position = transform.position + new Vector3(displacement.x, displacement.y, 0);
    }

    private void CheckCollisions()
    {
        if (transform.position.x >= cameraSize || transform.position.x <= -cameraSize)
        {
            if (transform.position.x <= -cameraSize) transform.position = new Vector3(-cameraSize, transform.position.y, 0);
            else if (transform.position.x >= cameraSize) transform.position = new Vector3(cameraSize, transform.position.y, 0);
            velocity.x = velocity.x * -1;
            velocity.x = velocity.x - damping.x;
        }
        if (transform.position.y >= cameraSize || transform.position.y <= -cameraSize)
        {
            if (transform.position.y <= -cameraSize) transform.position = new Vector3(transform.position.x, -cameraSize, 0);
            else if (transform.position.y >= cameraSize) transform.position = new Vector3(cameraSize, cameraSize, 0);
            velocity.y = velocity.y * -1;
            velocity.y = velocity.y - damping.y;
        }
    }
}
