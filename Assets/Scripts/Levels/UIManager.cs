using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject mapSelectionPanel;
    public GameObject[] levelSelectionPanels;

    [Header("Our STAR UI")]
    public int candies;
    public TextMeshProUGUI candyText;
    public TextMeshProUGUI[] candyLevelText;
    public MapSelection[] mapSelections;
    public TextMeshProUGUI[] questStarsTexts;
    public TextMeshProUGUI[] lockedStarsTexts;
    public TextMeshProUGUI[] unlockStarsTexts;

  //  private List<Button> buttons = new List<Button>();
	private List<Sequence> animationSequences = new List<Sequence>();

	private const float INITIAL_DELAY = 1f;
	private const float DELAY_BETWEEN_BUTTONS = 0.3f;

    Tweener shakeTween;
    TweenCallback shakeTweenComplete;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);

        AnimateButtons();
    }

    public void Cheat(){
        candies+=72;
        EventCenter.GetInstance().EventTrigger("UpdateMap");
        UpdateLockedStarUI();
        // UpdateStarUI();
        // UpdateLockedStarUI();
        // UpdateUnLockedStarUI();

        
        //EventCenter.GetInstance().AddEventListener("PressStarButton", UpdateStarUI);
        //EventCenter.GetInstance().AddEventListener("PressStarButton", UpdateLockedStarUI);
        //EventCenter.GetInstance().AddEventListener("PressStarButton", UpdateUnLockedStarUI);
    }

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        UpdateStarUI();
        UpdateLockedStarUI();
        UpdateUnLockedStarUI();

        EventCenter.GetInstance().AddEventListener("PressStarButton", UpdateStarUI);
        EventCenter.GetInstance().AddEventListener("PressStarButton", UpdateLockedStarUI);
        EventCenter.GetInstance().AddEventListener("PressStarButton", UpdateUnLockedStarUI);

    }

    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener("PressStarButton", UpdateStarUI);
        EventCenter.GetInstance().RemoveEventListener("PressStarButton", UpdateLockedStarUI);
        EventCenter.GetInstance().RemoveEventListener("PressStarButton", UpdateUnLockedStarUI);
    }

    private void AnimateButtons()
	{
		for (int i = 0; i < 4; i++)
		{
			mapSelections[i].transform.localScale = Vector3.zero;
			AnimateButton(i, INITIAL_DELAY + DELAY_BETWEEN_BUTTONS * i);
		}
	}

    	private void AnimateButton(int index, float delay)
	{
		if (animationSequences.Count <= index)
		{
			animationSequences.Add(DOTween.Sequence());
		}
		else
		{
			if (animationSequences[index].IsPlaying())
			{
				animationSequences[index].Kill(true);
			}
		}

		var seq = animationSequences[index];
		var button = mapSelections[index];

		seq.Append(button.transform.DOScale(0.36f, 0.1f));
		seq.Append(button.transform.DOPunchScale(Vector3.one * 0.5f, 0.7f, 5, 0.6f).SetEase(Ease.OutCirc));
		seq.PrependInterval(delay);
	}

    

    //Update OUR Candies UI on the top left connor
    private void UpdateStarUI()
    {
        candies = Levels();
        candyText.text = candies.ToString();
    }

    public int Levels()
    {
        int num = 0;

        for(int i = 1; i <= 96; i++){
            num = num + PlayerPrefs.GetInt("Lv" + i);
        }

        return num;
    }

    private int KinderGartenLevel()
    {
        int num = 0;

        for(int i = 1; i <= 24; i++){
            num = num + PlayerPrefs.GetInt("Lv" + i);
        }

        return num;
    }
    private int FirstLevel()
    {
        int num = 0;

        for(int i = 25; i <= 48; i++){
            num = num + PlayerPrefs.GetInt("Lv" + i);
        }

        return num;
    }

    private void UpdateLockedStarUI()
    {
        
        for(int i = 0; i < mapSelections.Length; i++)
        {
            questStarsTexts[i].text = mapSelections[i].questNum.ToString();

            if (mapSelections[i].isUnlock == false)//If one of the Map is locked
            {
                lockedStarsTexts[i].text = candies.ToString() + "/" + mapSelections[i].endLevel * 3;
            }
        }
    }

    private void UpdateUnLockedStarUI()
    {
        
        for(int i = 0; i < mapSelections.Length; i++)
        {
            unlockStarsTexts[i].text = candies.ToString() + "/" + mapSelections[i].endLevel * 3;

            switch(i)
            {
                case 0://Kinder
                    unlockStarsTexts[i].text = (KinderGartenLevel()) + "/" +
                        (mapSelections[i].endLevel - mapSelections[i].startLevel + 1) * 3;

                    break;
                case 1://1st
                    unlockStarsTexts[i].text = (FirstLevel()) + "/" +
                        (mapSelections[i].endLevel - mapSelections[i].startLevel + 1) * 3;
                    break;
                case 2://2nd
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("Lv" + 6) + PlayerPrefs.GetInt("Lv" + 7) + PlayerPrefs.GetInt("Lv" + 8) + PlayerPrefs.GetInt("Lv" + 9)) + "/" + (mapSelections[i].endLevel - mapSelections[i].startLevel + 1) * 3;
                    break;
                case 3://3rd
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("Lv" + 10) + PlayerPrefs.GetInt("Lv" + 11) + PlayerPrefs.GetInt("Lv" + 12) + PlayerPrefs.GetInt("Lv" + 13)) + "/" + (mapSelections[i].endLevel - mapSelections[i].startLevel + 1) * 3;
                    break;
            }
        }
    }

    #region Called Inside Update Function

    //MARKER This method will be triggered when we press the (FOUR) map button
    public void PressMapButton(int _mapIndex)
    {
         
        if(mapSelections[_mapIndex].isUnlock == true)//You can open this map
        {
            levelSelectionPanels[_mapIndex].gameObject.SetActive(true);
            mapSelectionPanel.gameObject.SetActive(false);
        }
        else
        {
            mapSelections[_mapIndex].transform.DOShakePosition(3,3); //Shake if the card is lock
            Debug.Log("You cannot open this scene now. Please work hard to collect more candies");
        }
    }

    public void BackButton()
    {
        mapSelectionPanel.gameObject.SetActive(true);
        for(int i = 0; i < mapSelections.Length; i++)
        {
            levelSelectionPanels[i].gameObject.SetActive(false);
        }
    }

    //MARKER this method will be call on the SingleLevel button event
    public void BackMapSelection()
    {
        mapSelectionPanel.gameObject.SetActive(true);
        for (int i = 0; i < mapSelections.Length; i++)
        {
            levelSelectionPanels[i].gameObject.SetActive(false);
        }
        SceneManager.LoadScene("LevelSelection");

        //EventCenter.GetInstance().EventTrigger("UpdateMap");
    }

    #endregion
}
