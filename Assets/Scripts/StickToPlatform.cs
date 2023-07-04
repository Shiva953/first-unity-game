using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name == "Player"){ //gameobject is the floor
            collision.gameObject.transform.SetParent(transform); //making the floor parent of the player(parenting it)
        }
    }
    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.name == "Player"){ //gameobject is the floor
            collision.gameObject.transform.SetParent(null);//removing the floor as the parent(unparenting it)
        }
    }
}
