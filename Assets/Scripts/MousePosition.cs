using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    public float turn;
    public bool lockedCond;
    public GameObject pauseObj;

    public GameObject bacteriaMakignDevice;
    public GameObject bubblePart;
    public GameObject particleSlot;
    // Start is called before the first frame update
    void Start()
    {
        lockedCond = true;
        pauseObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   

        Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePositionWorld = cam.ScreenToWorldPoint(mousePosition);
        if(Input.GetMouseButton(0))
        {
            var bubbles = Instantiate(bubblePart, new Vector3(mousePositionWorld.x, mousePositionWorld.y, 0.5f), Quaternion.identity, particleSlot.transform);
            Destroy(bubbles, 2f);
        }

        if(Input.GetKeyDown(KeyCode.LeftAlt) && lockedCond == false)
        {   
            lockedCond = true;

        }
        else if (Input.GetKeyDown(KeyCode.LeftAlt))
        lockedCond = false;

        if(lockedCond == true)
        {
            pauseObj.SetActive(false);
            spongeControl();
            lockedNVisible();
            bacteriaMakignDevice.SetActive(true);
        }
        else
        {
            pauseObj.SetActive(true);
            lockedNVisible();
            bacteriaMakignDevice.SetActive(false);
        }


    }


    public void lockedNVisible()
    {
        if(lockedCond == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
        else if (lockedCond == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void spongeControl()
    {

        Vector3 mousePos = Input.mousePosition;
        player.transform.position = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.5f));
        
        turn -= Input.GetAxis("Mouse X") * 5;
        turn -= Input.GetAxis("Mouse Y") * 5;
       
        player.transform.localRotation = Quaternion.Euler(0, 0, turn);
    }
}
