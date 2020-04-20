using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice // Note how this class does not inherit from MonoBehaviour (Unity API's mega class)
{

    // This simple class has 1 job - to return an integer value between 1-6
    // Remember the Factory / Machine analogy - this is a dice rolling factory, with one machine - Roll() 

    public int Roll()
    {
        // This public function returns a random integer to whatever calls on it.

        int r = Random.Range(0, 6);
        return r;
    }
}
