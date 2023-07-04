using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy")){
            Die();
        }
    }
    void Die(){
        GetComponent<MeshRenderer>().enabled = false; //disabling the mesh renderer
        GetComponent<Rigidbody>().isKinematic = true; //disabling the rigid body
        GetComponent<playerMovement>().enabled = false; //disabling the player movement script
        //basically all of these should be valid if player DIES 
        ReloadLevel(); //reload as soon as death
    }
    void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //RELOAD THE ENTIRE SCENE
    }
}
