using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Russel
//Populate random age to the button
public class Age : MonoBehaviour
{
    public List<GameObject> btnChoices;
    List<int> agesToChooseFrom = new List<int>(new int[]{3,4,5});
    InfoGUI infoGUI;
    public Player currentPlayer = new Player();
    // Start is called before the first frame update
    void Start()
    {
        string saveJson = PlayerPrefs.GetString(GameManager.Instance.PLAYER_KEY);

        //Json
        currentPlayer = JsonUtility.FromJson<Player>(saveJson);
        int convertToIntAge = int.Parse(currentPlayer._age);
        GameManager.Instance.age = convertToIntAge;


        bool ageIsAlreadyExist = agesToChooseFrom.Contains(GameManager.Instance.age);

        //if age is already exist
        if(ageIsAlreadyExist){
            agesToChooseFrom.Remove(GameManager.Instance.age);
            //The data was remove, the list now became 2 digit  numbersToChooseFrom [num1, num2]
            //This is the reason why I add two digits
            agesToChooseFrom.Add(GameManager.Instance.age);
            int x = GameManager.Instance.age;
            int newAge = x += 5;
            agesToChooseFrom.Add(newAge);

        }else{
            agesToChooseFrom.Add(GameManager.Instance.age);
        }
       
        foreach(GameObject btn in btnChoices){
            int index = Random.Range(0, agesToChooseFrom.Count);
            int i = agesToChooseFrom[index];  
            btn.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();  
            agesToChooseFrom.RemoveAt(index);  
        }

        
    }
}
