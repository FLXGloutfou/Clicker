using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform woodPos;

    [SerializeField]
    private Transform shopPos;


    private bool isMoving;
    public bool onWood;

    public void GoRight()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveRight());
        }

    }
    private IEnumerator MoveRight()
    {
        isMoving = true;
        onWood = false;

        while (Vector3.Distance(transform.position, shopPos.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, shopPos.position, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = shopPos.position;
        isMoving = false;
    }

    public void GoLeft()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveLeft());
        }
        
    }
    private IEnumerator MoveLeft()
    {
        isMoving = true;
        
        while (Vector3.Distance(transform.position, woodPos.position) > 0.1f)
        {     
            transform.position = Vector3.MoveTowards(transform.position, woodPos.position, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = woodPos.position;
        isMoving = false;
        onWood = true;
    }

    
}