using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private GameObject radarToShow;
    private bool radarOnScreen;

    public void showRadar() 
    {
        if (!radarOnScreen) 
        {
            radarToShow.SetActive(true);
            radarOnScreen = true;
        }     
    }

    public void hideRadar()
    {
        if (radarOnScreen)
        {
            radarToShow.SetActive(false);
            radarOnScreen = false;
        }
    }
}
