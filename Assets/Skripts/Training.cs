using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    public GameObject Ship, Training_Object;

    public GameObject[] List;

    public int what_list_open;

    public void Open_Training()
    {
        Ship.SetActive(false);
        Training_Object.SetActive(true);
        List[0].SetActive(true);
    }

    public void Close_Training()
    {
        Ship.SetActive(true);
        Training_Object.SetActive(false);
        List[what_list_open].SetActive(false);
        what_list_open = 0;
    }
    public void Next_List()
    {
        for(int i = 0; i < List.Length; i++)
        {
            if(List[i].activeSelf == true)
            {
                what_list_open = i;
            }
        }
        List[what_list_open].SetActive(false);
        if(List.Length - 1 > what_list_open) what_list_open += 1;
        List[what_list_open].SetActive(true);
    }

    public void Pref_List()
    {
        for (int i = 0; i < List.Length; i++)
        {
            if (List[i].activeSelf == true)
            {
                what_list_open = i;
            }
        }
        List[what_list_open].SetActive(false);
        if (0 < what_list_open) what_list_open -= 1;
        List[what_list_open].SetActive(true);
    }
}
