using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera playerCam;
    [SerializeField] private CameraMove mouseLook;
    [SerializeField] private LayerMask interactionLayers;
    [SerializeField] private float rayDistance;

    [SerializeField] private Transform followPoint;
    [SerializeField] private Transform dropPoint;

    private GameObject handItem;
    private bool canPlaceItem;
    private int buttonCounter;
    private bool itemInHand;
    private GameObject currentInteractable;
    private PlayerMovement player;
    private bool interactPressed;

    private TrapPlacement placementPoint;

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
        if (!interactPressed && itemInHand == true)
        {
            itemInHand = false;
            handItem.transform.parent = null;
            handItem.transform.position = dropPoint.position;
            handItem = null;

        }

        if (currentInteractable != null)
        {
          
            if (currentInteractable.CompareTag("Radar") && interactPressed && !itemInHand)
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


            if (currentInteractable.CompareTag("Trap") && interactPressed && !itemInHand)
            {
                itemInHand = true;
                currentInteractable.transform.parent = followPoint;
                currentInteractable.transform.position = followPoint.position;
                handItem = currentInteractable;
                handItem.GetComponent<Collider>().isTrigger = false;
            }

            if (currentInteractable.CompareTag("Placement Point") && handItem != null)
            {
                canPlaceItem = true;
                placementPoint = currentInteractable.GetComponent<TrapPlacement>();
            }

            else
            {
                canPlaceItem = false;
            }
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && currentInteractable != null && buttonCounter == 0)
        {
            interactPressed = true;
            buttonCounter++;
           
        }

        if (context.canceled && buttonCounter == 1)
        {
            buttonCounter++;
        }

        if (context.performed && buttonCounter == 2)
        {
            if (canPlaceItem)
            {
                placementPoint.SpawnTrap();
            }

            interactPressed = false;
            buttonCounter = 0;

        }

    }
    public GameObject CheckItem()
    {
        return handItem;
    }
}
