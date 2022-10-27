using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject Explosion;
    [SerializeField] GameObject bullet;
    public Transform target;
    public BoxCollider BX;
    float speed;

    public float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        speed *= Random.Range(0.5f, 2);
        //BX = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) transform.LookAt(target);
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        Timer += Time.deltaTime;
        if(Timer >= 5)
        {
            Shoot();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") return;
        if(BX.enabled == true) BX.enabled = false;
        GameObject g = Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(g, 2);
        Destroy(gameObject, 1);
    }
    void Shoot()
    {
        Vector3 firePosition = transform.position + transform.forward * 2;
        Instantiate(bullet, firePosition, transform.rotation);
        Timer = 0;
    }
}
