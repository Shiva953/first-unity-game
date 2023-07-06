using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    bool dead = false;
    [SerializeField] AudioSource deathSound;
    void Update(){ //for every frame
        if(transform.position.y < -0.1f && !dead){
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy")){
            GetComponent<MeshRenderer>().enabled = false; //disabling the mesh renderer
            GetComponent<Rigidbody>().isKinematic = true; //disabling the rigid body
            GetComponent<playerMovement>().enabled = false; //disabling the player movement script
            Die();
        }
    }
    void Die(){
        //basically all of these should be valid if player DIES 
        Invoke(nameof(ReloadLevel) , 1f); //reload 1.3s after death
        deathSound.Play();
        Debug.Log("ded");
        dead = true;
    }
    void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //RELOAD THE ENTIRE SCENE
    }
}
