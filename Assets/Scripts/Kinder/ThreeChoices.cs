using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeChoices : BaseDragAndDrop
{
    public void PressSubmit()
    {
        //base.PressSubmit();
        if(!locked) {
            int totalOfCandies = GameManager.Instance.totalOfCandies;
            int totalOfScore = GameManager.Instance.totalScore;
            Debug.Log(totalOfCandies);

            float passed = 0.90f * totalOfScore;

            float middle = 0.50f * totalOfScore;

            float failed = 0.20f * totalOfScore;

            //0.80 
            // float passed = 0.90f * totalOfScore;

            // float middle = 0.70f * totalOfScore;

            // float failed = 0.20f * totalOfScore;


            if(totalOfCandies >= Mathf.Round(passed) && totalOfCandies <= totalOfScore){ 
                //Debug.Log(totalOfCandies +"|"+Mathf.Round(passed));
                FindObjectOfType<SingleLevel>().PressCandiesButton(3);
            }else if(totalOfCandies >= Mathf.Round(middle)){
               //Debug.Log("GameManager.Instance.totalScore");
                FindObjectOfType<SingleLevel>().PressCandiesButton(2);
            }else if(totalOfCandies >= Mathf.Round(failed)){
                //Debug.Log("GameManager.Instance.totalScor");
                FindObjectOfType<SingleLevel>().PressCandiesButton(1);
            }else{
                FindObjectOfType<SingleLevel>().PressCandiesButton(0);
            }
            locked = true;
        }
    }
}
