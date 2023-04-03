using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Animal
{
    // POLYMORPHISM
    public override void Jump()
    {
        animalRb.AddForce(Vector3.up * jumpForce * 2, ForceMode.Impulse);
    }
}
