using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ColObjetMagasin : MonoBehaviour
{
    public ObjetBoutique objet;
    bool canBuyObj = false;
    public GameObject dial;
    public GameObject dialTxt;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Avendre")
        {
            print(objet.prix);
            if (GameManager.Instance.or >= objet.prix)
            {
                print("passe "+objet.prix);
                canBuyObj = true;
                dial.SetActive(true);
                dialTxt.GetComponent<TextMeshProUGUI>().text = "Appuyer sur e pour acheter l'objet : " + objet.prix + " Po";
                StartCoroutine("HideDial");
            }
            else
            {
                print("passe pas" + objet.prix);

                dial.SetActive(true);
                dialTxt.GetComponent<TextMeshProUGUI>().text = "Ta pas assez de thune fils pars il te faut : " + objet.prix + " Po";
                StartCoroutine("HideDial");
            }
        }
        
    }


    private void Update()
    {
        if (canBuyObj && Input.GetKeyUp(KeyCode.E))
        {
            GameManager.Instance.or -= 10;
            PlayerPrefs.SetInt(objet.name, 1);
            Destroy(GameObject.Find(objet.name));
            GameManager.Instance.SaveData();
        }
    }

    IEnumerator HideDial()
    {
        yield return new WaitForSeconds(5);
        dial.SetActive(false);
    }

}
