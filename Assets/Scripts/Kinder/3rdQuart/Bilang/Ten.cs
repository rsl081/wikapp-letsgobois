using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ten : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("10")){
            GameManager.Instance.totalOfCandies++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("10")){
            GameManager.Instance.totalOfCandies--;
        }
    }
}
