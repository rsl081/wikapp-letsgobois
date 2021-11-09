using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("9")){
            GameManager.Instance.totalOfCandies++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("9")){
            GameManager.Instance.totalOfCandies--;
        }
    }
}
