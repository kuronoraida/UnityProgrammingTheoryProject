using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    protected float waitTime = 1.0f;
    protected const float waitTimeMin = 3.0f;
    protected const float waitTimeMax = 4.0f;

    
    protected Rigidbody animalRb;
    protected float jumpForce = 3.0f;

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

    // Move to a random point on navmesh
    public void MoveRandom()
    {
        
    }

    //POLYMORPHISM
    // Jump
    public virtual void Jump()
    {
        animalRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Repeating behaviour
    public void AnimalBehaviour()
    {
        Jump();

        waitTime = Random.Range(waitTimeMin, waitTimeMax);
        Invoke("AnimalBehaviour", waitTime);

        Debug.Log("invoked");
    }
}
