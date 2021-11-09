using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color1 : MonoBehaviour
{
    public Color colorList;
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
        curColor = colorList;

        var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit  = Physics2D.Raycast(ray, -Vector2.up);

        if(Input.GetButton("Fire1")) {
            if(isFirstClicked){
                if(hit.collider != null && !isLocked){
                    // Blue
                    Color c = new Color(0.2392157f, 0.698f, 1.000f, 1.000f);
             
                    SpriteRenderer sp = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                        
                    //Comparing 2 color variables.
                    //https://answers.unity.com/questions/787056/comparing-2-color-variables.html
                    

                    if(hit.collider.CompareTag("Yellow")) {    
                        ++GameManager.Instance.totalOfCandies;
                    }else if(GameManager.Instance.totalOfCandies > 0 && hit.collider.CompareTag("Yellow")) {
                        --GameManager.Instance.totalOfCandies;
                    }else if((int)(c.r * 1000) == (int)(sp.color.r * 1000)){
                        --GameManager.Instance.totalOfCandies;
                        Debug.Log("mine");
                    }

                    isLocked = true;
                    sp.color = curColor;
                    

                    

                }
            }
        }

    }

    public void Paint() {

      
        //colorCount = colorCode;
        isLocked = false;
        isFirstClicked = true;
        
    }
}
