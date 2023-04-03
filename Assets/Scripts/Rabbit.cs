using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Rabbit : Animal
{
    // POLYMORPHISM
    public override void Jump()
    {
        animalRb.AddForce(transform.up * jumpForce * 2, ForceMode.Impulse);
        animalRb.AddForce(transform.forward * jumpForce, ForceMode.Impulse);
    }
}
