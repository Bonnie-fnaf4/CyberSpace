using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    [SerializeField] GameObject dustParticle;
    public int hp = 10;
    float angle = 10;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * angle * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Meteorit scriptMeteorite = other.GetComponent<Meteorit>();
        //Enemy scriptEnemy = other.GetComponent<Enemy>();
        //if(scriptMeteorite != null)
        //{
        if(other.tag == "Enemy")
        {
            hp--;
            GameObject g = Instantiate(dustParticle, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(g, 1);
        }
        //}
    }
}
