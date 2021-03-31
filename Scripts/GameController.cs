using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public SnappingObject[] points;
    SnappingObject player;

    public TextMesh infoText;
    public TextMesh instructionText;
    public bool isGameOver = false;

    float resetTimer = 3f;

    void Start()
    {
        player = GetComponent<SnappingObject>();
        PickRandomPiece();
        infoText.text = "Tic Tac Toe!!";
        instructionText.text = "Drag and drop cubes in the board";
    }

    // Update is called once per frame
    void Update()
    {  
        if (isGameOver==true){
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0f)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
     public void PickRandomPiece()
    {
        int availablePoints = 0;
       
        foreach(SnappingObject point in points)
        {
            if (point.defined == false)
            {
                availablePoints++;
            }
        }

        if (availablePoints > 0)
        {
            SnappingObject randomPoints = points[Random.Range(0, points.Length)];
            while (randomPoints.defined == true)
            {
                randomPoints = points[Random.Range(0, points.Length)];
            }
            randomPoints.ComputerSelect();
        }

        if (availablePoints == 1)
        {
            isGameOver = true;
        }

    }

    public void CheckBoard()
    {
        //Horizontal Check
        for(int y = 0; y < 3; y++)
        {
            SnappingObject checkPoint = null;
            int matches = 0;

            for(int x=0;x<3; x++)
            {
                SnappingObject currentPoint = points[y * 3 + x];

                if (checkPoint == null)
                {
                    if(currentPoint.checkResult != 0)
                    {
                        checkPoint = currentPoint;
                        matches++;
                    }
                }else if (currentPoint.checkResult == checkPoint.checkResult)
                {
                    matches++;
                }
            }
            if (matches == 3)
            {
                if (checkPoint.checkResult == 1)
                {
                    infoText.text = "CONGRATS, YOU WON!";
                    isGameOver = true;
                }
                else
                {
                    infoText.text = "HAHA! YOU LOST!";
                    isGameOver = true;
                }
                return;
            }
        }
        // Vertical Check
        for (int y = 0; y < 3; y++)
        {
            SnappingObject checkPoint = null;
            int matches = 0;

            for (int x = 0; x < 3; x++)
            {
                SnappingObject currentPoint = points[x * 3 + y];

                if (checkPoint == null)
                {
                    if (currentPoint.checkResult != 0)
                    {
                        checkPoint = currentPoint;
                        matches++;
                    }
                }
                else if (currentPoint.checkResult == checkPoint.checkResult)
                {
                    matches++;
                }
            }
            if (matches == 3)
            {
                if (checkPoint.checkResult == 1)
                {
                    infoText.text = "CONGRATS, YOU WON!";
                    isGameOver = true;
                }
                else
                {
                    infoText.text = "HAHA! YOU LOST!";
                    isGameOver = true;
                }
                return;
            }
        }

    }

}
