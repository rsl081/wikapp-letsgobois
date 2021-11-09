using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgeChoices2 : MonoBehaviour
{
    public GameObject correctAnswerBtn;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("CorrectAge")){
            string age = correctAnswerBtn.GetComponentInChildren<TextMeshProUGUI>().text;
            int parseToIntAge = int.Parse(age);
            if(GameManager.Instance.age == parseToIntAge){
                GameManager.Instance.totalOfCandies += 3;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("CorrectAge")){
            string age = correctAnswerBtn.GetComponentInChildren<TextMeshProUGUI>().text;
            int parseToIntAge = int.Parse(age);
            if(GameManager.Instance.age == parseToIntAge){
                GameManager.Instance.totalOfCandies -= 3;
            }
        }
    }
}
