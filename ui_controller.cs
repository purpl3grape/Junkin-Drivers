using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_controller : MonoBehaviour
{
    GameObject[] ui_item;
    int item_selected;
    int player_tires = 4;
    int player_doors = 2;

    // Start is called before the first frame update
    void Start()
    {
        item_selected = 0;
        ui_item = new GameObject[3];



        ui_item[0] = gameObject.transform.GetChild(0).gameObject;
        ui_item[1] = gameObject.transform.GetChild(1).gameObject;

        if (ui_item[1] == null)
            throw new System.Exception();



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
           // Debug.Log("before" + item_selected);
             ui_item[item_selected].transform.localScale -= new Vector3(0.2f, 0.2f);
            

            item_selected += 1;
            if (item_selected >= 2)
                item_selected = 0;

            ui_item[item_selected].transform.localScale += new Vector3(0.2f, 0.2f);
          

            //Debug.Log("after" + item_selected);

        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (ui_item[item_selected].gameObject.tag == "tire")
            {
                if (player_tires > 0)
                {
                    Debug.Log("used tire");
                    player_tires -= 1;
                    //call tire item function use here
                }
                else if(player_tires == 0)
                {
                    Debug.Log("No Tires left Fool");
                    //play sound? or other notification
                }
                
            }
            else if (ui_item[item_selected].gameObject.tag == "door")
            {
                if (player_doors > 0) { 
                Debug.Log("used door");
                    player_doors -= 1;
                //call door item function use here
            }
                else if(player_doors == 0)
                {
                    Debug.Log("No Doors left fool");
                    //play sound? or other notification
                }

            }
        }




    }
}
