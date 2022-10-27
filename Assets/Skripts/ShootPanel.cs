using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Player player;
    public bool isShoot = false;
    void Update()
    {
        if(isShoot)player.Shoot();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //player.Shoot();
        isShoot = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isShoot = false;
        //player.Shoot();
    }
}
