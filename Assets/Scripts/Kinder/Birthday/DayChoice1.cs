using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DayChoice1 : MonoBehaviour
{
    public GameObject correctAnswerBtn;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Yellow")){
            string day = correctAnswerBtn.GetComponentInChildren<TextMeshProUGUI>().text;
            if(day.Equals(GameManager.Instance.day)){
                GameManager.Instance.totalOfCandies += 3;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Yellow")){
            string day = correctAnswerBtn.GetComponentInChildren<TextMeshProUGUI>().text;
            if(day.Equals(GameManager.Instance.day)){
                GameManager.Instance.totalOfCandies -= 3;
            }
        }
    }
}
