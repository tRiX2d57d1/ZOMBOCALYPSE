using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{ public GameObject Playercam;
    public float range = 100f;
    public float damage = 25f;
    public Animator playeranimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(playeranimator.GetBool("isShooting"))
        {
            playeranimator.SetBool("isShooting", false);
        }
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        playeranimator.SetBool("isShooting", true);
        RaycastHit hit;
        if(Physics.Raycast(Playercam.transform.position, transform.forward, out hit, range))
        {
            EnemyManager enemymanager = hit.transform.GetComponent<EnemyManager>();
            if(enemymanager!= null)
            {
                enemymanager.Hit(damage);
            }
        }
    }
}
