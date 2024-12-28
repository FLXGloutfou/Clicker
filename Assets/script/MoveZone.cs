using System.Collections;
using UnityEngine;

public class MoveZone : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    public Transform _woodPos;
    public Transform _shopPos;
    public GameObject _rightButton;
    public GameObject _leftButton;
    public GameObject _sellPanel;



    private bool _isMoving;
    public bool _onWood;

    public void Start()
    {
        _leftButton.SetActive(false);
    }
    public void GoLeft()
    {
        if (!_isMoving)
        {
            _leftButton.SetActive(true);
            _sellPanel.SetActive(false);
            StartCoroutine(MoveRight());
            _rightButton.SetActive(false);
        }

    }
    private IEnumerator MoveLeft()
    {
        _isMoving = true;
        _onWood = false;

        while (Vector3.Distance(transform.position, _shopPos.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _shopPos.position, _speed * Time.deltaTime);
            yield return null;
        }
        transform.position = _shopPos.position;
        _isMoving = false;
    }

    public void GoRight()
    {
        if (!_isMoving)
        {
            _leftButton.SetActive(false);            
            StartCoroutine(MoveLeft());
            _rightButton.SetActive(true);
            _sellPanel.SetActive(true);
        }
        
    }
    private IEnumerator MoveRight()
    {
        _isMoving = true;
        
        while (Vector3.Distance(transform.position, _woodPos.position) > 0.1f)
        {     
            transform.position = Vector3.MoveTowards(transform.position, _woodPos.position, _speed * Time.deltaTime);
            yield return null;
        }
        transform.position = _woodPos.position;
        _isMoving = false;
        _onWood = true;
    }



    public void OnZoneClicked()
    {
        if (_onWood == true)
        {
            Manager.Instance.AddWood(5);           
        }
    }
}