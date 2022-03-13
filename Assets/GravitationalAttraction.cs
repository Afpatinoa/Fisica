using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyMath;

public class GravitationalAttraction : MonoBehaviour
{
    [SerializeField] bool canMove;
    Vector3 displacement, diferencia;
    [SerializeField] Vector3 velocity, accelaration, damping, force;
    float cameraSize;
    GravitationalAttraction masaReferencia;
    [SerializeField] Transform referencia;
    [SerializeField] float mass, maxForce;

    private void Start()
    {
        cameraSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
        masaReferencia = referencia.GetComponent<GravitationalAttraction>();
    }
    private void Update()
    {
        diferencia = referencia.position - transform.position;

        force = ((mass * masaReferencia.mass) / (diferencia.magnitude * diferencia.magnitude)) * diferencia.normalized;
        if (force.magnitude > maxForce) force = force.normalized * maxForce;
        ApplyForce(force);

        if (canMove) Move();

        accelaration = Vector3.zero;
    }
    public void Move()
    {
        //accelaration = referencia.position - transform.position;
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
    void ApplyForce(Vector3 force) { accelaration += force / mass; }
}