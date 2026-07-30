using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera playerCam;
    [SerializeField] private CameraMove mouseLook;
    [SerializeField] private LayerMask interactionLayers;
    [SerializeField] private float rayDistance;

    private GameObject currentInteractable;
    private PlayerMovement player;
    private bool interactPressed;


    private void Awake()
    {
        player = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        RayCasting();
        ObjectInteractions();
    }

    private void RayCasting()
    {
        Ray camRay = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit, rayDistance, interactionLayers))
        {
            currentInteractable = hit.collider.gameObject;
        }
        else
        {
            currentInteractable = null;
        }
        Debug.DrawRay(camRay.origin, camRay.direction * rayDistance, Color.yellow);
    }

    private void ObjectInteractions()
    {
        if (currentInteractable != null)
        {
          
            if (currentInteractable.CompareTag("Radar") && interactPressed)
            {
                currentInteractable.GetComponent<Radar>().showRadar();
                mouseLook.enabled = false;
                player.enabled = false;
            }
            else if (currentInteractable.CompareTag("Radar") && !interactPressed)
            {
                currentInteractable.GetComponent<Radar>().hideRadar();
                mouseLook.enabled = true;
                player.enabled = true; 
            }
        }
    }


    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && currentInteractable != null)
        {
            interactPressed = true;
           
        }

        if(context.performed && player.enabled == false)
        {
            interactPressed = false;
        }

    }
}
