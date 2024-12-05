using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Ui : MonoBehaviour
{

    public GameObject upgradewindow;
    private bool Upgradeisopen = false;

    public void OpenUpgradeWindow()
    {
        if (Upgradeisopen != true)
        {
            upgradewindow.SetActive(true);
            Upgradeisopen = true;
        }
        else
        {
            upgradewindow.SetActive(false);
            Upgradeisopen = false;
        }
        
    }

}
