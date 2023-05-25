using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack : MonoBehaviour
{
    public Transform cameraTransform;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var raycast = Raycast();
            if (raycast.collider.transform.tag == "Computer")
            {
                var computer = raycast.collider.gameObject.transform.GetComponent<Computer>();
                computer.StartHacking();
            }
        }
    }

    RaycastHit Raycast()
    {
        RaycastHit hit;
        Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit);
        
        return hit;
    }
}
