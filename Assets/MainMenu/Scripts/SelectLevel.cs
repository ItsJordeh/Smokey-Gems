using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    public Dropdown dropDown;

    public void LoadSelectedScene()
    {

        string selectedLevel = dropDown.options[dropDown.value].text;
       // Scene scene;

        switch (selectedLevel)
        {

            case "Jordan's Test Level":
                SceneManager.LoadScene("JordanTestLevel");
                break;
            case "CJ's Test Level":

                break;
            case "Xenon's Test Level":
                
                //scene = SceneManager.GetSceneByName("JordanTestLevel");
                break;
        }

        //SceneManager.LoadScene(scene);



    }



    
}
