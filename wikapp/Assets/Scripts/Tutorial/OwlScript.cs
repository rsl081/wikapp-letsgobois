using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OwlScript : MonoBehaviour
{
    [SerializeField]
    Transform[] owlLocation;

    [SerializeField]
    float moveSpeed;

    bool timeToMove = true;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 xPos = new Vector3(owlLocation[1].position.x, transform.position.y);
        MoveOwl(xPos);
    }
    void MoveOwl(Vector3 newPosition)
    {
        if(transform != null){
            transform.DOMove(newPosition, moveSpeed).SetEase(Ease.Linear).OnComplete((() =>{
            if(timeToMove){
                timeToMove = !timeToMove;
                Vector3 xPos = new Vector3(owlLocation[0].position.x, transform.position.y);
                MoveOwl(xPos);
            }else{
                timeToMove = !timeToMove;
                Vector3 xPos = new Vector3(owlLocation[1].position.x, transform.position.y);
                MoveOwl(xPos);
            }
         })).Play();
        }
         
    }

}
