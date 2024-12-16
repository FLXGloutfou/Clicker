using System.Collections;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public Transform woodPos;
    public Transform shopPos;
    public GameObject rightButton;
    public GameObject leftButton;
    public GameObject sellPanel;



    private bool isMoving;
    public bool onWood;

    public void Start()
    {
        leftButton.SetActive(false);
    }
    public void GoLeft()
    {
        if (!isMoving)
        {
            leftButton.SetActive(true);
            sellPanel.SetActive(false);
            StartCoroutine(MoveRight());
            rightButton.SetActive(false);
        }

    }
    private IEnumerator MoveLeft()
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

    public void GoRight()
    {
        if (!isMoving)
        {
            leftButton.SetActive(false);            
            StartCoroutine(MoveLeft());
            rightButton.SetActive(true);
            sellPanel.SetActive(true);
        }
        
    }
    private IEnumerator MoveRight()
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