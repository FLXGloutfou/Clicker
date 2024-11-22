using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform targetPostition;

    public void GoLeft()
    {
        Debug.Log("onbouge");
        while (transform.position != targetPostition.position)
        {   
            Vector3 dir = targetPostition.position - targetPostition.position;
            transform.Translate(dir * speed * Time.deltaTime);
        }
        
    }

}
