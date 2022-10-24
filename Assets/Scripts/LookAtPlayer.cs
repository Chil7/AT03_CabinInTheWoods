using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Update()
    {
        //Gets Players position and reverse y position for text to not be backwards
        Vector3 targetPosition = new Vector3(player.transform.position.x, -player.transform.position.y, player.transform.position.z);
        //Looks at Player
        transform.LookAt(targetPosition);
    }
}
