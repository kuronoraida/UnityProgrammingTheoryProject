using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    protected float waitTime = 1.0f;
    protected const float waitTimeMin = 3.0f;
    protected const float waitTimeMax = 4.0f;

    protected Vector3 randomPoint;
    protected const float randomXrange = 10.0f;
    protected const float randomYrange = 10.0f;

    protected Rigidbody animalRb;
    protected float jumpForce = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        animalRb = GetComponent<Rigidbody>();

        Invoke("AnimalBehaviour", waitTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ABSTRACTION
    // Move randomly
    public void MoveRandom()
    {
        randomPoint = new Vector3(Random.Range(-randomXrange, randomXrange), transform.position.y, Random.Range(-randomYrange, randomYrange));
        transform.LookAt(randomPoint);
        Jump();
    }

    //POLYMORPHISM
    // Jump
    public virtual void Jump()
    {
        animalRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        animalRb.AddForce(transform.forward * jumpForce, ForceMode.Impulse);
    }

    // Repeating behaviour
    public void AnimalBehaviour()
    {
        MoveRandom();
        Jump();

        waitTime = Random.Range(waitTimeMin, waitTimeMax);
        Invoke("AnimalBehaviour", waitTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animalRb.velocity = Vector3.zero;
            animalRb.angularVelocity = Vector3.zero;
        }
    }
}
