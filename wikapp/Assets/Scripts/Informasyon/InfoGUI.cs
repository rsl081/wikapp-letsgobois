using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InfoGUI : Singleton<InfoGUI>
{
    [SerializeField]GameObject nameTmp; 
    [SerializeField]GameObject ageTmp;
    [SerializeField]public TMP_Dropdown monthDropDown;
    [SerializeField]public TMP_Dropdown dayDropDown;
    [SerializeField]public TMP_Dropdown yearDropDown;
    [SerializeField]public TMP_Dropdown genderDropDown;
    [SerializeField]TMP_FontAsset nougatFont;

    string playername = "";
    string age = "";
    string month = "";
    string day = "";
    string year = "";
    string gender = "";

    public Player currentPlayer = new Player();
    public readonly string PLAYER_KEY = "MY_PLAYER";
    string player = "";
    private void Start() {
    
        PlayerPrefs.DeleteAll();
        if(PlayerPrefs.HasKey(PLAYER_KEY)){
            SceneManager.LoadScene("00_MapSelection");
        }
        // PlayerPrefs.SetInt("Candy", GameManager.Instance.candy = 1);
    }

    public void Submit() {
        playername = nameTmp.GetComponent<TMP_InputField>().text.Trim();
        age = ageTmp.GetComponent<TMP_InputField>().text.Trim();
        month = monthDropDown.options[monthDropDown.value].text;
        day = dayDropDown.options[dayDropDown.value].text;
        year = yearDropDown.options[yearDropDown.value].text;
        //birth = birthTmp.GetComponent<TMP_InputField>().text.Trim();
        gender = genderDropDown.options[genderDropDown.value].text;

        if(CheckField())  {
            currentPlayer = new Player();
            currentPlayer._name = playername;
            currentPlayer._age = age;
            currentPlayer._month = month;
            currentPlayer._day = int.Parse(day);
            currentPlayer._year = year;
            currentPlayer._gender = gender;

            player = JsonUtility.ToJson(currentPlayer);
            PlayerPrefs.SetString(PLAYER_KEY, player);
            PlayerPrefs.Save();
            SceneManager.LoadScene("LevelSelection");
        }

    }

    public Player LoadPlayer(){
        if(PlayerPrefs.HasKey(PLAYER_KEY)){
            string saveJson = PlayerPrefs.GetString(PLAYER_KEY);
            currentPlayer = JsonUtility.FromJson<Player>(saveJson);
            // string age = currentPlayer._age;
            // int converToInAge = int.Parse(age);
            // GameManager.Instance.age = converToInAge;
            return currentPlayer;
            //Debug.Log(CurrentPlayer._name);
            
        }
        //return currentPlayer;
        return null;
    }

    bool CheckField(){
        if(playername == "" || age == "" || gender == ""){
            if(playername == ""){
                nameTmp.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().font = nougatFont;
                nameTmp.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                nameTmp.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().text = "Missing Field";
                nameTmp.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            if(age == ""){
                ageTmp.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().font = nougatFont;
                ageTmp.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                ageTmp.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().text = "Missing Field";
                ageTmp.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            if(gender == ""){
                genderDropDown.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().font = nougatFont;
                genderDropDown.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                genderDropDown.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().text = "Missing Field";
                genderDropDown.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            return false;
        }
        return true;
    }



}

