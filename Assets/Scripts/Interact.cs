using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public bool enableHack;
    public bool enableDoor;
    public bool enablePhone;
    public bool enablePipe;

    public Transform cameraTransform;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var raycast = Raycast();

            if (enableDoor)
            {
                try
                {
                    var door = raycast.collider.gameObject.gameObject.GetComponent<Door>();

                    if (!door.open)
                    {
                        door.open = true;
                        door.Move(-90, 1);
                    }
                    else
                    {
                        door.open = false;
                        door.Move(0f, 1);
                    }
                }catch {}
            }

            if (enablePhone)
            {
                try
                {
                    var phone = raycast.collider.gameObject.gameObject.GetComponent<Phone>();
                    phone.PickUp();
                }
                catch { }
            }

            if (enablePipe)
            {
                try
                {
                    var pipe = raycast.collider.gameObject.gameObject.GetComponent<Pipe>();
                    if (!pipe.smoking)
                        pipe.Smoke();
                }
                catch { }
            }

            if (enableHack && raycast.collider.transform.tag == "Computer")
            {
                var computer = raycast.collider.gameObject.transform.GetComponent<Computer>();
                computer.StartHacking();
                enableHack = false;
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
