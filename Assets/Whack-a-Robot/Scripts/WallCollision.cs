using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    public Transform player;
    public Rigidbody playerRB;
    public int BrakingPower;

    void FixedUpdate()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            playerRB.AddForce((2 * -playerRB.velocity) * Time.deltaTime);
            print("In a wall");
        }
    }
}
