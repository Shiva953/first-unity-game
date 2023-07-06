using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int counter = 0;
    [SerializeField] Text coinsText;
    [SerializeField] AudioSource collectionSound;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Coin")){
            Destroy(other.gameObject);
            collectionSound.Play();
            counter++;
            coinsText.text = "Coins : " + counter;
        }
    }
}
