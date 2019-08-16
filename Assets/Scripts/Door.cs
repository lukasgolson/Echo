﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject _cameraController;
    [SerializeField]
    private bool isOpen;
    [SerializeField]
    private bool isMoving;
    private Vector3 rotationClone;
    [SerializeField]
    private Quaternion startingRotation;
    [SerializeField]
    private Quaternion endingRotation;
    [SerializeField]
    private float startingY;
    [SerializeField]
    private float endingY;
    [SerializeField]
    private float currentY;
    [SerializeField]
    private Quaternion currentRotation;
    static float t = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        _cameraController = GameObject.Find("CameraTransform");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, currentY-transform.rotation.y,0);
        t += 0.5f * Time.deltaTime;
        currentY = Mathf.Lerp(startingY,endingY, t);
        endingY = endingRotation.y;
        if(isMoving){
            if(isOpen){
                 if(currentY == endingY){
                isOpen=false;
                isMoving = false;
                }
                endingRotation = startingRotation;
                endingRotation.y = startingRotation.y + 90;
                currentY = Mathf.Lerp(startingY,endingY, t);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(1,transform.rotation.x,currentY,transform.rotation.z),0.1f);
               t += 0.5f * Time.deltaTime;
            }else{
                if(currentY == endingY){
                 isOpen=true;
                 isMoving = false;
                    }
               endingRotation = startingRotation;
                endingY = startingY - 90;
                currentY = Mathf.Lerp(startingY * 360,endingY * 360, t);
                transform.rotation = Quaternion.Euler(0, currentY+transform.rotation.y,0);
               t += 0.5f * Time.deltaTime;
                
            }
            
        }
    }

    void OnMouseOver(){
        if(Input.GetButtonDown("Interact")){
            
            if(!isMoving){
            if(Vector3.Distance(gameObject.transform.position, _cameraController.transform.position) < 3){
                t=0.0f;
                startingY = transform.rotation.y * 128;
                isMoving = true;            
            }
            }
        }
    }
}
