using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Five : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("5")){
            GameManager.Instance.totalOfCandies++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("5")){
            GameManager.Instance.totalOfCandies--;
        }
    }
}
