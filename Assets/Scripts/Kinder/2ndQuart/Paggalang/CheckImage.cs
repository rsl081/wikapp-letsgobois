using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckImage : MonoBehaviour
{
    [SerializeField] GameObject[] checkImg;
    bool isOn;
    bool isOFF;
    int selectedImage = 0;

    private void Start() {
        GameManager.Instance.totalScore = checkImg.Length;
    }


    private void Update() {
        
        for(int i = 0; i < checkImg.Length; i++){

            checkImg[selectedImage].SetActive(isOn);

        }
    }

    public void IsAlreadyOpen(bool isOn)
    {
        this.isOn = isOn;
    }
    public bool IsAlreadyOpen()
    {
        return this.isOn;
    }

    public void ImageChange(int img)
    {
        isOn = !isOn;
        selectedImage = img;   
        if(!checkImg[img].activeInHierarchy){
            GameManager.Instance.totalOfCandies++;
        }else{
            GameManager.Instance.totalOfCandies--;
        }
    }

}
