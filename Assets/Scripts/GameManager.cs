using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public readonly string PLAYER_KEY = "MY_PLAYER";
    public int totalOfCandies = 0;
    public int totalScore = 0;
    public int age = 0;
    //public string birth = "";
    public string year = "";
    public int day = 0;
    public string month = "";

    //These two variable would found in pagbawas game
    public int xyz = 0;
    public int www = 0;
}
