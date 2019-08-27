using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class yonetici : MonoBehaviour {

    public Text puan_txt;
    public GameObject altin;
    public GameObject miknatis;
    public GameObject kutuk;
    public GameObject tas;
    public GameObject araba;

    List<GameObject> altinlar;
    List<GameObject> digerleri;
    List<GameObject> digerleri1;

    Transform cocuk;

    int puan=0;

    public GameObject oyunu_durdur_panel;

    void Start ()
    {
        altinlar = new List<GameObject>();
        digerleri = new List<GameObject>();
        digerleri1 = new List<GameObject>();

        cocuk = GameObject.Find("cocuk").transform;


        uretme(altin, 10, altinlar);

        uretme(miknatis, 1, digerleri);
        uretme(tas, 3, digerleri1);
        uretme(kutuk, 3, digerleri1);
        uretme(araba, 3, digerleri);

        InvokeRepeating("altin_uret", 0.0f, 1.0f);
        InvokeRepeating("engel_uret", 2.0f, 3.0f);
        InvokeRepeating("engel_uret1", 2.0f, 3.0f);

        puan_txt.text = "SKOR " + puan.ToString();

    }

   public void puan_arttir(int deger)
    {
        puan += deger;
       puan_txt.text ="SKOR " + puan.ToString();
    }

    void altin_uret()
    {
        foreach (GameObject altin in altinlar)
        {
            if (altin.activeSelf==false)
            {
                altin.SetActive(true);
                int rastgele = Random.Range(0, 2);
                if (rastgele==0)
                {
                    altin.transform.position = new Vector3(-1.0f, 9.0f, cocuk.position.z + 10.0f);
                }
                if (rastgele == 1)
                {
                    altin.transform.position = new Vector3(1.75f, 9.0f, cocuk.position.z + 10.0f);
                }

                return;
            }
        }
    }
    void engel_uret()
    {
        int rast = Random.Range(0, digerleri.Count);

        if (digerleri[rast].activeSelf==false)
        {
            digerleri[rast].SetActive(true);

            int rastgele = Random.Range(0, 2);


            if (rastgele == 0)
            {
                digerleri[rast].transform.position = new Vector3(-1.0f, 8.5f, cocuk.position.z + 10.0f);
            }
            if (rastgele == 1)
            {
                digerleri[rast].transform.position = new Vector3(1.75f, 8.5f, cocuk.position.z + 10.0f);
            }

            if (digerleri[rast].tag=="magnet")
            {
                if (cocuk.gameObject.GetComponent<karakter_kontrol>().miknatis_alindi == true)
                {
                    digerleri[rast].SetActive(false);
                }
                
            }
          

        }
        else
        {
            foreach (GameObject nesne in digerleri)
            {
                if (nesne.activeSelf==false)
                {
                    nesne.SetActive(true);

                    int rastgele2 = Random.Range(0, 2);


                    if (rastgele2 == 0)
                    {
                        nesne.transform.position = new Vector3(-1.0f, 8.5f, cocuk.position.z + 10.0f);
                    }
                    if (rastgele2 == 1)
                    {
                        nesne.transform.position = new Vector3(1.75f, 8.5f, cocuk.position.z + 10.0f);
                    }

                  

                    if (digerleri[rast].tag == "magnet")
                    {
                        if (cocuk.gameObject.GetComponent<karakter_kontrol>().miknatis_alindi == true)
                        {
                            nesne.SetActive(false);
                        }
                        
                    }

                    return;
                }
            }
        }
    }

    //taş ve kütük üretme için
    void engel_uret1()
    {
        int rast = Random.Range(0, digerleri1.Count);

        if (digerleri1[rast].activeSelf == false)
        {
            digerleri1[rast].SetActive(true);

            int rastgele = Random.Range(0, 2);


            if (rastgele == 0)
            {
                digerleri1[rast].transform.position = new Vector3(-1.0f, 8f, cocuk.position.z + 10.0f);
            }
            if (rastgele == 1)
            {
                digerleri1[rast].transform.position = new Vector3(1.75f, 8f, cocuk.position.z + 10.0f);
            }

        }
        else
        {
            foreach (GameObject nesne in digerleri1)
            {
                if (nesne.activeSelf == false)
                {
                    nesne.SetActive(true);

                    int rastgele2 = Random.Range(0, 2);


                    if (rastgele2 == 0)
                    {
                        nesne.transform.position = new Vector3(-1.0f, 8f, cocuk.position.z + 10.0f);
                    }
                    if (rastgele2 == 1)
                    {
                        nesne.transform.position = new Vector3(1.75f, 8f, cocuk.position.z + 10.0f);
                    }


                    return;
                }
            }
        }
    }






    void uretme(GameObject nesne, int miktar,List<GameObject> liste)
    {
        for (int i = 0; i < miktar; i++)
        {
            GameObject yeni_nesne = Instantiate(nesne);
            yeni_nesne.SetActive(false);
            liste.Add(yeni_nesne);
        }
    }

    public void tekrar_oyna()
    {
        SceneManager.LoadScene("main");
        Time.timeScale = 1.0f;
    }
    public void devam_et()
    {
        oyunu_durdur_panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void oyunu_durdur()
    {
        oyunu_durdur_panel.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void oyundan_cik()
    {
        Application.Quit();
    }
    void Update ()
    {
		
	}
}
