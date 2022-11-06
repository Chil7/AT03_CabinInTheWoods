using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private GameObject waypointMenu;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip teleportClip;

    private AudioSource audioSource;
    private MouseLook mouseLook;
    public Waypoint[] waypoints;

    public static SelectionManager instance;

    private void Awake()
    {
        mouseLook = FindObjectOfType<MouseLook>();
        audioSource = GetComponent<AudioSource>();

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

    //Enables or disables mouse look script
    public bool ToggleMouseLook()
    {
        mouseLook.enabled = !mouseLook.enabled;
        return mouseLook.enabled;
    }

    //Enables or disables selection menu panel
    public bool ToggleWayPointMenu()
    {
        waypointMenu.SetActive(!waypointMenu.activeSelf);
        CursorEnabled = waypointMenu.activeSelf;
        return waypointMenu.activeSelf;
    }

    public void TeleportTo(string name)
    {
        Waypoint w = Array.Find(waypoints, waypoint => waypoint.name == name);
        if (w == null)
        {
            Debug.LogWarning("Waypoint: " + name + " not found!");
            return;
        }
        player.transform.position = w.waypointTransForm.position;
        audioSource.PlayOneShot(teleportClip);
    }

}
