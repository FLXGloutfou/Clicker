using UnityEngine;

public class ClickZone : MonoBehaviour
{
    public Rect clickZone = new Rect(100, 100, 1800,900);
    public Camera cameraScript;
    public Manager manager;

    void OnGUI()
    {
        GUI.Box(clickZone, "Zone de clic");
    }

    void Update()
    {
        if (cameraScript != null && cameraScript.onWood)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Input.mousePosition;
                mousePosition.y = Screen.height - mousePosition.y;

                if (clickZone.Contains(mousePosition))
                {
                    Debug.Log("Clic détecté dans la zone !");
                    OnZoneClicked();
                }
            }
        }
        
    }

    void OnZoneClicked()
    {
        manager.AddMoney(10);
    }
}
