using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class Menu : MonoBehaviour
{
    [SerializeField] private Button kinderBtn;
    [SerializeField] private Button firstBtn;
    [SerializeField] private Button secondBtn;
    [SerializeField] private Button thirdBtn;

    [SerializeField] private TextMeshProUGUI candyText;
    
    [SerializeField] private Transform kinderContainer;
    [SerializeField] private Transform firstContainer;
    [SerializeField] private Transform secondContainer;
    [SerializeField] private Transform thirdContainer;

	private const float INITIAL_DELAY = 1f;
	private const float DELAY_BETWEEN_BUTTONS = 0.3f;

	private List<Button> buttons = new List<Button>();
	private List<Sequence> animationSequences = new List<Sequence>();

    UiManager uiManager;



    private void Awake() {
        
        kinderBtn?.onClick.AddListener(OnKinderPressed);
        firstBtn?.onClick.AddListener(OnFirstPressed);
        secondBtn?.onClick.AddListener(OnSecondPressed);
        thirdBtn?.onClick.AddListener(OnThirdPressed);

        buttons.Add(kinderBtn);
		buttons.Add(firstBtn);
		buttons.Add(secondBtn);
		buttons.Add(thirdBtn);

        int candy = PlayerPrefs.GetInt("Candy");

        candyText.text = $"{candy}/3";
    
        for (int i = candy+1; i < 4; i++)
		{
            buttons[i].interactable = false;
		}
    
        AnimateButtons();
    }


    private void OnDestroy() {
        kinderBtn?.onClick.RemoveListener(OnKinderPressed);
        firstBtn?.onClick.RemoveListener(OnFirstPressed);
        secondBtn?.onClick.RemoveListener(OnSecondPressed);
        thirdBtn?.onClick.RemoveListener(OnThirdPressed);
    }

    private void AnimateButtons()
	{
		for (int i = 0; i < 4; i++)
		{
			buttons[i].transform.localScale = Vector3.zero;
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
		var button = buttons[index];

		seq.Append(button.transform.DOScale(0.4f, 0.1f));
		seq.Append(button.transform.DOPunchScale(Vector3.one * 0.5f, 0.7f, 5, 0.6f).SetEase(Ease.OutCirc));
		seq.PrependInterval(delay);
	}

    private void OnKinderPressed()
    {
        
    }
    private void OnFirstPressed()
    {
        
    }
    private void OnSecondPressed()
    {

    }
    private void OnThirdPressed()
    {

    }
}
