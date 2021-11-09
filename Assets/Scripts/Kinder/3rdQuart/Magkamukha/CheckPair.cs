using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPair : MonoBehaviour
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
            if(0 == img || 3 == img){
                GameManager.Instance.totalOfCandies+=2;
            }
        }else{
            if((GameManager.Instance.totalOfCandies > 0) && (0 == img || 3 == img)){
                GameManager.Instance.totalOfCandies-=2;
            }
        }

    }

    public void ImageChange1(int img)
    {
        isOn = !isOn;
        selectedImage = img;   
        if(!checkImg[img].activeInHierarchy){
            if((1 == img || 2 == img)){
                GameManager.Instance.totalOfCandies-=1;
            }
        }else{
            if((1 == img || 2 == img)){
                GameManager.Instance.totalOfCandies+=1;
            }
        }
    }

}
