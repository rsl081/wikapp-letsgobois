using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintBucket : MonoBehaviour
{
    public Color[] colorList;
    public Color curColor;
    public int colorCount;
    bool isLocked = false;
    bool isFirstClicked = false;

    // Update is called once per frame
    void Update()
    {
        // curColor = colorList[colorCount];

        // if(Input.touchCount > 0){

        //     Touch touch = Input.GetTouch(0);
        //     Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

        //     //var ray = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        //     RaycastHit2D hit  = Physics2D.Raycast(touchPos, -Vector2.up);

        //     switch(touch.phase){
        //         case TouchPhase.Began:
        //             if(isFirstClicked){
        //                 if(!isLocked && hit.collider != null){
        //                     SpriteRenderer sp = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                    
        //                     Debug.Log(++GameManager.Instance.totalOfCandies);
        //                     isLocked = true;
        //                     sp.color = curColor;
        //                 }
        //             }
        //         break;

        //     }
        // }
        curColor = colorList[colorCount];

        var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit  = Physics2D.Raycast(ray, -Vector2.up);

        if(Input.GetButton("Fire1")) {
            if(isFirstClicked){
                if(hit.collider != null && !isLocked){
                    
                    SpriteRenderer sp = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                    
                    Debug.Log(++GameManager.Instance.totalOfCandies);
                    isLocked = true;
                    sp.color = curColor;
                }
            }
        }
    }

    public void Paint(int colorCode) {

      
        colorCount = colorCode;
        isLocked = false;
        isFirstClicked = true;
        
    }
}
