using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform basePlayer;
    public MainCameraAnimation MCA;
    public FixedJoystick FJ;
    //public RotateMainCamera RMC;
    float speed = 30, boost = 2, sens = 150;

    public Slider sensSlider;
    public int hp = 5;

    public float Timer = 0;

    public Text Speed;
    // Start is called before the first frame update
    void Start()
    {
        Respawn(false);
    }

    // Update is called once per frame
    void Update()
    {
        sens = sensSlider.value;
        Rotate();
        Move();
        //if(Time.timeScale == 1) Shoot();
    }
    void Rotate()
    {
        float xAxis = 0;
        float yAxis = 0;

        //if(Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0)
        //{
        //    yAxis = Input.GetAxis("Mouse X") * 2;
        //}
        //if (Input.GetAxis("Mouse Y") < 0 || Input.GetAxis("Mouse Y") > 0)
        //{
        //    xAxis = Input.GetAxis("Mouse Y") * 2;
        //}

        yAxis = FJ.Horizontal;
        xAxis = - FJ.Vertical;

        Vector3 allAxis = new Vector3(xAxis, yAxis, 0) * sens * Time.deltaTime;
        Quaternion newOrientation = Quaternion.Euler(allAxis);
        transform.rotation *= newOrientation;
    }
    void Move()
    {
        float current_speed = speed;
        //if (Input.GetKey(KeyCode.Space)) current_speed *= boost;
        transform.Translate(Vector3.forward * current_speed * Time.deltaTime);
        Speed.text = "Скорость: " + current_speed;
    }
    public void Shoot()
    {
        //if (Input.GetMouseButton(0))
        if (Time.timeScale == 1)
        {
            if (Timer <= 0)
            {
                Vector3 firePosition = transform.position + transform.forward * 2;
                Instantiate(bullet, firePosition, transform.rotation);
            }
            Timer += Time.deltaTime;
        }
        else
        {
            Timer = 0;
        }
        if (Timer >= 0.3) Timer = 0;
    }
    void Respawn(bool b)
    {
        if (b) MCA.StartAnim();
        Vector3 randomPos = Random.onUnitSphere * 100;
        transform.position = randomPos;
        transform.LookAt(basePlayer);
    }
    private void OnTriggerEnter(Collider other)
    {
        Bullet bulletScripts = other.GetComponent<Bullet>();
        if (bulletScripts != null) return;
        hp--;
        Respawn(true);
    }
}
