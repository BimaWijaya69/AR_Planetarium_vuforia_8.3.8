using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistem : MonoBehaviour
{
    public static Sistem instance;
    public int ID;
    public GameObject TempatSpawn;
    public GameObject Gui_Utama;
    public GameObject[] KoleksiPlanet;
    public AudioClip[] SuaraPlanet;
    AudioSource Suara;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ID = 0;
        //SpawnObject();
        Gui_Utama.SetActive(false);
        Suara = gameObject.AddComponent<AudioSource>();
    }

    public void SpawnObject()
    {
        GameObject BendaSebelumnya = GameObject.FindGameObjectWithTag("Planet");
        if (BendaSebelumnya != null) Destroy(BendaSebelumnya);


        GameObject Benda = Instantiate(KoleksiPlanet[ID]);
        Benda.transform.SetParent(TempatSpawn.transform, false);
        Benda.transform.localScale = new Vector3(0.37f, 0.37f, 0.37f);
        TempatSpawn.GetComponent<Animation>().Play("PopUp");
        KumpulanSuara.instance.Panggil_Suara(1);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            GantiPlanet(true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GantiPlanet(false);
        }
    }

    public void GantiPlanet(bool kanan)
    {
        if (kanan)
        {
            if (ID >= KoleksiPlanet.Length - 1)
            {
                ID = 0;
            }
            else
            {
                ID++;
            }
        }
        else
        {
            if (ID <= 0)
            {
                ID = KoleksiPlanet.Length - 1;
            }
            else
            {
                ID--;
            }
        }

        SpawnObject();
        PanggilSuaraPlanet();
    }

    public void PanggilSuaraPlanet()
    {
        Suara.clip = SuaraPlanet[ID];
        Suara.Play();
    }
}
