using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    //int correctAnswer = 0;
    //int questionsSeen = 0;

    [SerializeField] GameObject canvasSubmit;
    [SerializeField] GameObject canvasQuiz;
    Quiz quiz;

    private void Start() {

        quiz = FindObjectOfType<Quiz>();

    
    }

    private void Update() {
        if(quiz.isComplete){

            canvasSubmit.SetActive(true);
            canvasQuiz.SetActive(false);

        }
    }


    public int GetCorrectAnswers()
    {
        return GameManager.Instance.totalOfCandies;
    }

    public void IncrementCorrecntAnswer(){
        GameManager.Instance.totalOfCandies++;
    }

    public int GetQuestionSeen()
    {
        return GameManager.Instance.totalScore;
    }

    public void IncrementQuesitonsSeen()
    {
        GameManager.Instance.totalScore++;
    }

    public int CalculateScore()
    {
        //To acheive float to int
        return Mathf.RoundToInt(GameManager.Instance.totalOfCandies / (float) GameManager.Instance.totalScore * 100);
    }


}
