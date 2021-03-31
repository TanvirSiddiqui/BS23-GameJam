using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragObj : MonoBehaviour
{
   
    float ZPosition;
    Vector3 Offset;
    bool Dragging;
    bool DragFlag = true;
   
    [SerializeField] GameObject obj;
    [SerializeField] GameController gameController;
    

    public Camera MainCamera;
    [Space]
    [SerializeField]
    public UnityEvent OnBeginDrag;
    [SerializeField]
    public UnityEvent OnEndDrag;


    // Start is called before the first frame update
    void Start()
    {
        ZPosition = MainCamera.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dragging)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZPosition);
            transform.position = MainCamera.ScreenToWorldPoint(position + new Vector3(Offset.x, Offset.y));
        }
    }

     void OnMouseDown()
    {
        if (!Dragging )
        {
            BeginDrag();
        }
    }

    void OnMouseUp()
    {
        EndDrag();
    }

    void BeginDrag()
    {
        if (DragFlag) {
            OnBeginDrag.Invoke();
          //  audioSource.PlayOneShot(pickup);
            Dragging = true;
            Offset = MainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
            obj.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void EndDrag()
    {
        obj.GetComponent<BoxCollider>().enabled = true;
        OnEndDrag.Invoke();
        Dragging = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        gameController.CheckBoard();  
        if (collision.gameObject.tag == "Deck")
        {
            obj.GetComponent<MeshRenderer>().enabled = false;
            DragFlag = false;
           // Debug.Log("Dragging Stopped");
        }
    }


}
