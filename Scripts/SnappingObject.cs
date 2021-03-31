using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnappingObject : MonoBehaviour
{
     public GameObject fakeObj;
     public GameObject fakeO;

     public GameController gameController;

     public bool defined = false;
     public int checkResult = 0;

    void Start()
    {
       
    }


    public void ComputerSelect()
    {
        defined = true;
        fakeO.SetActive(true);
        checkResult = 2;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "draggableObject" && gameController.isGameOver==false)
        {
            fakeObj.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
            defined = true;
            gameController.CheckBoard();
            if (gameController.isGameOver == false)
            {
                gameController.PickRandomPiece();
                gameController.CheckBoard();
            }
           
            checkResult = 1;
        }
    }
}
