using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Birthday : MonoBehaviour
{
    public List<GameObject> btnChoicesMonth;
    public List<GameObject> btnChoicesDay;
    public List<GameObject> btnChoicesYear;

    List<string> monthsToChooseFrom = new List<string>(new string[]{
        "January","February","March",
        "April","May","June",
        "July", "August","September",
        "October","November","December"
        });

    //Todo make this year connected to the dropdown in InfGui
    List<string> yearsToChooseFrom = new List<string>(new string[]{
        "2016","2017","2018","2019"});

    List<int> daysToChooseFrom = new List<int>();

    public Player currentPlayer = new Player();
    
    // Start is called before the first frame update
    void Start()
    {
        string saveJson = PlayerPrefs.GetString(GameManager.Instance.PLAYER_KEY);
        //Json
        currentPlayer = JsonUtility.FromJson<Player>(saveJson);
        
        GameManager.Instance.month = currentPlayer._month;
        GameManager.Instance.day = currentPlayer._day;
        GameManager.Instance.year = currentPlayer._year;

        List<string> newMonth = new List<string>();
        foreach(string numOfMonth in monthsToChooseFrom) {

            if(numOfMonth.Equals(GameManager.Instance.month)){
                int index = Random.Range(0, btnChoicesMonth.Count);
                btnChoicesMonth[index].GetComponentInChildren<TextMeshProUGUI>()
                                        .text = numOfMonth.ToString();  
                btnChoicesMonth.RemoveAt(index); 
            }else{
                newMonth.Add(numOfMonth);
            }
        }
        int indexBtnChoiceMonth = Random.Range(0, btnChoicesDay.Count);
        int indexNewMonthCount = Random.Range(0, newMonth.Count);
        string month = newMonth[indexNewMonthCount];
        btnChoicesDay[indexBtnChoiceMonth].GetComponentInChildren<TextMeshProUGUI>().text = month.ToString();  


        //=== DAY ===
        for(int i = 1; i <= 31; i++){
            daysToChooseFrom.Add(i);
        }
        
        List<int> newDay = new List<int>();
        foreach(int numOfDay in daysToChooseFrom) {

            if(numOfDay == GameManager.Instance.day){
                int index = Random.Range(0, btnChoicesDay.Count);
                btnChoicesDay[index].GetComponentInChildren<TextMeshProUGUI>()
                                        .text = numOfDay.ToString();  
                btnChoicesDay.RemoveAt(index); 
            }else{
                newDay.Add(numOfDay);
            }
        }
        int indexBtnChoiceDay = Random.Range(0, btnChoicesDay.Count);
        int indexNewDayCount = Random.Range(0, newDay.Count);
        int day = newDay[indexNewDayCount];
        btnChoicesDay[indexBtnChoiceDay].GetComponentInChildren<TextMeshProUGUI>().text = day.ToString();  

        //=== Year ===
        List<string> newYear = new List<string>();
        foreach(string numOfYear in yearsToChooseFrom) {
            if(numOfYear.Equals(GameManager.Instance.year)){
                int index = Random.Range(0, btnChoicesYear.Count);
                btnChoicesYear[index].GetComponentInChildren<TextMeshProUGUI>()
                                        .text = numOfYear;  
                btnChoicesYear.RemoveAt(index); 
                
            }else{
                newYear.Add(numOfYear);
            }
        }
        int indexBtnChoiceYear = Random.Range(0, btnChoicesYear.Count);
        int indexNewYearCount = Random.Range(0, newYear.Count);
        string year = newYear[indexNewYearCount];
        btnChoicesYear[indexBtnChoiceYear].GetComponentInChildren<TextMeshProUGUI>().text = year;  

       
       
    }//end of Start
}
