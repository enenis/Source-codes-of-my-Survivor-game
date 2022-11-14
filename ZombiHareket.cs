using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiHareket : MonoBehaviour
{
    //add
    public GameObject kalp;
    private GameObject oyuncu;
    private int zombiCan = 3;
    private float mesafe;
    private int zombiPuan = 1;
    private OyunKontrol oKontrol;
    private AudioSource aSource;
    private bool zombieOluyor = false;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        oyuncu = GameObject.Find("FPSController");
        oKontrol = GameObject.Find("__Script").GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;
        mesafe=Vector3.Distance(transform.position,oyuncu.transform.position);
        if (mesafe<2f)
        {
            if (!aSource.isPlaying)
                aSource.Play();
            if(!zombieOluyor)
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
        }
        else
        {
            if (aSource.isPlaying)
                aSource.Stop();
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("mermi"))
        {
            Debug.Log("çarptý");
            zombiCan-=1;
            if (zombiCan==0)
            {
                zombieOluyor = true;
                oKontrol.PuanArttir(zombiPuan);
                Instantiate(kalp, transform.position, Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.667f);
            }
        }   
    }
}
