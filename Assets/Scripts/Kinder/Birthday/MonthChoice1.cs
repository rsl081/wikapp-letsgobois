using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonthChoice1 : MonoBehaviour
{
    public GameObject correctAnswerBtn;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Red")){
            string month = correctAnswerBtn.GetComponentInChildren<TextMeshProUGUI>().text;
            if(month.Equals(GameManager.Instance.month)){
                GameManager.Instance.totalOfCandies += 3;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Red")){
            string month = correctAnswerBtn.GetComponentInChildren<TextMeshProUGUI>().text;
            if(month.Equals(GameManager.Instance.month)){
                GameManager.Instance.totalOfCandies -= 3;
            }
        }
    }
}
