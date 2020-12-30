using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    bool isOpen = false;
    public GameObject obj;

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) 
        {
            if (isOpen)
            {
                Close();
            }
            else if(!isOpen)
            {
                Open();
            }
        }
    }

    private void Close()
    {
        obj.SetActive(false);
        isOpen = false;

    }
    private void Open()
    {
        obj.SetActive(true);
        isOpen = true;

    }
}
