using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftEar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("EarLeft")){
            GameManager.Instance.totalOfCandies++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("EarLeft")){
            GameManager.Instance.totalOfCandies--;
        }
    }
}
