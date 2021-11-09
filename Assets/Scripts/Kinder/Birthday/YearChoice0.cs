using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YearChoice0 : MonoBehaviour
{
    public GameObject correctAnswerBtn;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Blue")){
            string year = correctAnswerBtn.GetComponentInChildren<TextMeshProUGUI>().text;
            if(year.Equals(GameManager.Instance.year)){
                GameManager.Instance.totalOfCandies += 3;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Blue")){
            string year = correctAnswerBtn.GetComponentInChildren<TextMeshProUGUI>().text;
            if(year.Equals(GameManager.Instance.year)){
                GameManager.Instance.totalOfCandies -= 3;
            }
        }
    }
}
