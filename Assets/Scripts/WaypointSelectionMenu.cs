using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSelectionMenu : MonoBehaviour
{
    [SerializeField] private GameObject waypointMenu;

    [SerializeField] private Transform bedroomWP;
    [SerializeField] private Transform bathroomWP;
    [SerializeField] private Transform livingRoomWP;
    [SerializeField] private Transform kitchenWP;
    [SerializeField] private Transform firePlaceWP;

    
    private MouseLook mouseLook;

    private void Awake()
    {
        mouseLook = GetComponentInChildren<MouseLook>();
    }

    //Enables Mouse cursor on screen
    public bool CursorEnabled
    {
        set
        {
            Cursor.visible = value;
            if (value == true)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    //If Selection menu is active, It toggles off
    void Start()
    {
        if (waypointMenu.activeSelf == true)
        {
            ToggleWayPointMenu();
        }
    }

    private void Update()
    {
        //Toggles Selection menu on and off
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            ToggleWayPointMenu();
            ToggleMouseLook();
            
            
        }
    }

    //Enables or disables selection menu panel
    public bool ToggleWayPointMenu()
    {
        waypointMenu.SetActive(!waypointMenu.activeSelf);
        CursorEnabled = waypointMenu.activeSelf;
        return waypointMenu.activeSelf;
    }

    //Enables or disables mouse look script
    public bool ToggleMouseLook()
    {
        mouseLook.enabled = !mouseLook.enabled;
        return mouseLook.enabled;
    }

    public void TeleportToBedRoom(int num)
    {
        //teleports to bedroom
        transform.position = bedroomWP.position;
    }

    public void TeleportToBathroom()
    {
        //teleports to bathroom
        transform.position = bathroomWP.position;
    }

    public void TeleportToLivingRoom()
    {
        //teleports to living room
        transform.position = livingRoomWP.position;
    }

    public void TeleportToKitchen()
    {
        //teleports to kitchen
        transform.position = kitchenWP.position;
    }

    public void TeleportToFirePlace()
    {
        //teleports to the fireplace
        transform.position= firePlaceWP.position;
    }
}
