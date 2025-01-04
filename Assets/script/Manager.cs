using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{

    public static Manager Instance;
    private void Awake()
    {
        if (Manager.Instance == null)
        {
            Manager.Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //_____________________________________________________________________________//
    //DEV_VARIABLE//
    public int woodboost;
    
    //_____________________________________________________________________________//
    //VARIABLE//

    public int _wood = 0;
    public int _money = 0;
    public int _autoLumberCost = 100;
    public int _autoLumberToolCost = 500;
    private int _woodPerMin;
    private int _autoLumberNumber = 0;
    private int _maxToolUp = 0;
    private int _autoLumberValue = 10;
    private int _logPrice = 1;

    private bool _isAutoClicking = false;
    

    [SerializeField]
    public Sprite[] _icons;
    public Image _axeIcone;
    private int _currentIconIndex = 0;

    public GameObject _feedBack;
    public Text _feedBackText;


    //______________________________________________________________________________//

    private void Start()
    {
        FeedBack("allez dans la zone de bois pour commencé à récolter !");
    }



    public void SetWood(int newAmount)
    {
        _wood = newAmount;
    }
    public void AddWood(int amount)
    {
        SetWood(_wood+amount+woodboost);
    }


    public void ButtonSellWood()
    { 
        _money = _money + _wood * _logPrice;
        SetWood(0);
    }

    public void ButtonAutoWood()
    {
        if (_money > _autoLumberCost)
        {
            _money -= _autoLumberCost;
            _autoLumberCost += 100 + 200 * _autoLumberNumber;

            _autoLumberNumber++;
            if (!_isAutoClicking)
            {
                StartCoroutine(CreateAutoClic());
            }
        }
        else
        {
            FeedBack("Pas assez d'argent");
        }

    }

    public IEnumerator CreateAutoClic()
    {
        
        _isAutoClicking = true;

        while (_autoLumberNumber > 0)
        {
            _woodPerMin = _autoLumberNumber * _autoLumberValue;
            AddWood(_woodPerMin);
            yield return new WaitForSeconds(1f);
        }

        _isAutoClicking = false;
    }


    public void AutoValueIncrease()
    {
        if (_money > _autoLumberToolCost && _maxToolUp <= 3)
        {
            _maxToolUp++;
            _money -= _autoLumberToolCost;
            _autoLumberToolCost = _autoLumberToolCost + 2500 * _maxToolUp;
            _autoLumberValue += 5 * (_maxToolUp + 1);

            _currentIconIndex = (_currentIconIndex + 1) % _icons.Length;
            _axeIcone.sprite = _icons[_currentIconIndex];
        }
        else
        {
            FeedBack("Pas assez d'argent");
        }
    }

    public void FeedBack(string info)
    {
        StartCoroutine(FeedBackPanel(info));
    }

    private IEnumerator FeedBackPanel(string info)
    {
        _feedBackText.text = info;
        _feedBack.SetActive(true);

        yield return new WaitForSeconds(2f);

        _feedBack.SetActive(false);
    }

}

