using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OyuncuKontrol : MonoBehaviour
{
    public AudioClip atisSesi, olmeSesi, canAlmaSesi, yaralanmaSesi;
    public Transform mermiPos;
    public GameObject mermi;
    public GameObject patlama;
    public GameObject patlama2;
    public Image canImaji;
    public OyunKontrol oKontrol;
    private float canDegeri = 100f;
    private AudioSource aSource;
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            aSource.PlayOneShot(atisSesi, 1f);
            GameObject go= Instantiate(mermi,mermiPos.position,mermiPos.rotation) as GameObject;
            GameObject goPatlama = Instantiate(patlama, mermiPos.position, mermiPos.rotation) as GameObject;
            GameObject goPatlama2 = Instantiate(patlama2, mermiPos.position, mermiPos.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = mermiPos.transform.forward * 10f;
            Destroy(go.gameObject, 2f);
            Destroy(goPatlama.gameObject, 2f);
            Destroy(goPatlama2.gameObject, 2f);

        }
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("zombi"))
        {
            aSource.PlayOneShot(yaralanmaSesi, 1f);
            canDegeri -= 10f;
            float x = canDegeri / 100f;
            canImaji.fillAmount = x;
            canImaji.color = Color.Lerp(Color.red, Color.green,x);
            if (canDegeri<=0)
            {
                aSource.PlayOneShot(olmeSesi, 1f);
                oKontrol.oyunBitti();
            }
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag.Equals("kalp"))
        {
            aSource.PlayOneShot(canAlmaSesi, 1f);
            canDegeri += 10f;
            float x = canDegeri / 100f;
            canImaji.fillAmount = x;
            canImaji.color = Color.Lerp(Color.red, Color.green, x);
            Destroy(c.gameObject);
        }
    }
}
