using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraControll : MonoBehaviour
{
    public Transform Player;
    public Vector3 Camera;
    public float x, y, z;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Camera = new Vector3 (0,0,-7);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position;
        if(!(transform.rotation == Player.rotation)) 
        {
            //x = Mathf.Lerp(transform.rotation.eulerAngles.x, Player.rotation.eulerAngles.x, speed);
            x = Mathf.LerpAngle(transform.rotation.eulerAngles.x, Player.rotation.eulerAngles.x, speed * Time.deltaTime);
            y = Mathf.LerpAngle(transform.rotation.eulerAngles.y, Player.rotation.eulerAngles.y, speed * Time.deltaTime);
            z = Mathf.LerpAngle(transform.rotation.eulerAngles.z, Player.rotation.eulerAngles.z, speed * Time.deltaTime);
            //x = Player.rotation.eulerAngles.x;
            //y = Player.rotation.eulerAngles.y;
            //z = Player.rotation.eulerAngles.z;
            transform.rotation = Quaternion.Euler(x, y, z);
        }
    }
}
