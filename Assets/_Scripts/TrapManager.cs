using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public GameObject selectionScreen;
    [SerializeField] private GameObject[] trapRadars;

    public void HideRadar()
    {
        foreach (var trapView in trapRadars)
        {
            if (trapView.activeInHierarchy)
            {
                trapView.gameObject.SetActive(false);
            }
        }
    
    }

}
