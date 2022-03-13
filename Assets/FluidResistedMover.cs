using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyMath;

public class FluidResistedMover : MonoBehaviour
{
    Vector3 displacement;
    [SerializeField] Vector3 velocity, accelaration, damping;
    Vector3 weight;

    float cameraSize, frontalArea;


    [SerializeField] float mass, gravity;
    [SerializeField] [Range(0f, 1f)] float mu;
    private void Start()
    {
        cameraSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
        frontalArea = transform.localScale.x;
        weight = mass * new Vector3(0,gravity,0);   
    }
    private void Update()
    {

        ApplyForce(weight);
        if (transform.position.y <= 0) {
            float fluidResistanceMagnitude = -0.5f * velocity.magnitude * velocity.magnitude * frontalArea * mu;
            ApplyForce(fluidResistanceMagnitude * velocity.normalized);
        }
        Move();
        CheckCollisions();

        accelaration = Vector3.zero;

    }
    public void Move()
    {

        velocity = velocity + (accelaration * Time.deltaTime);
        displacement = velocity * Time.deltaTime;
        base.transform.position = base.transform.position + displacement;
 

        accelaration.Draw(base.transform.position, Color.red);
        velocity.Draw(base.transform.position, Color.cyan);
        base.transform.position.Draw(Color.white);
    }

    private void CheckCollisions()
    {

        if (base.transform.position.x >= cameraSize || base.transform.position.x <= -cameraSize) { 
            if(base.transform.position.x <= -cameraSize) transform.position = new Vector3(-cameraSize, transform.position.y, 0);
            else if(base.transform.position.x >= cameraSize) transform.position = new Vector3(cameraSize, transform.position.y, 0);
            velocity.x = velocity.x * -1;
            velocity.x = velocity.x - damping.x;
        }
        if (base.transform.position.y >= cameraSize || base.transform.position.y <= -cameraSize)
        {
            if (base.transform.position.y <= -cameraSize) transform.position = new Vector3(transform.position.x, -cameraSize, 0);
            else if (base.transform.position.y >= cameraSize) transform.position = new Vector3(cameraSize, cameraSize, 0);
            velocity.y = velocity.y * -1;
            velocity.y = velocity.y - damping.y;
        }
    }
    void ApplyForce(Vector3 force) { accelaration += force / mass; }

    void ApplyGravity(Vector3 gravity) { accelaration += mass * gravity; }
}
