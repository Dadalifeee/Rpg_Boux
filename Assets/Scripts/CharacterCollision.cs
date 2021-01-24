using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterCollision : MonoBehaviour
{
    public GameObject dial;
    public GameObject dialTxt;
    public GameObject sword;
    public GameObject shield;
    public RectTransform lifeBar;
    bool quest2done = false;
    public CharacterCtrl character;
    private void OnTriggerEnter(Collider other)
    {
        // Declencher el dialogue
        if(other.gameObject.name == "TriggerDialogue1")
        {
            if (sword.activeInHierarchy && shield.activeInHierarchy)
            {
                dial.SetActive(true);
                dialTxt.GetComponent<TextMeshProUGUI>().text = "Bravo frerot c'est bien tu peux passer";
                Destroy(GameObject.Find("ObstacleQuete"));
            }
            else
            {
                dial.SetActive(true);
                dialTxt.GetComponent<TextMeshProUGUI>().text = "Pour passer frerot il te faut une �p�e et un bouclier cherche jeune, dehors les monstres sont m�chants.";
            }
            // Coroutine pour masquer dialogue
            StartCoroutine("HideDial");
        }
        if (other.gameObject.name == "TriggerDialogue2")
        {
            if (!quest2done)
            {
                dial.SetActive(true);
                dialTxt.GetComponent<TextMeshProUGUI>().text = "R�cup�re un oeil de dragon fils bonne chance.";
            }
            else
            {
                dial.SetActive(true);
                dialTxt.GetComponent<TextMeshProUGUI>().text = "GG la zone woula t fort tiens voila l'oseille pour tes efforts.";
                GameManager.Instance.or += 10;
                GameManager.Instance.SaveData();
            }
            // Coroutine pour masquer dialogue
            StartCoroutine("HideDial");
        }

        if (other.gameObject.name == "Sword_pick")
        {
            character.canAttack = true;
            Destroy(other.gameObject);
            sword.SetActive(true);
        }

        if (other.gameObject.name == "Shield_pick")
        {
            Destroy(other.gameObject);
            shield.SetActive(true);
        }

        if (other.gameObject.name == "Fiole" )
        {
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("Fiole", PlayerPrefs.GetInt("Fiole") + 1);
        }

        if (other.gameObject.name == "FioleBleue")
        {
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("FioleBleue", PlayerPrefs.GetInt("FioleBleue") + 1);
        }

        if (other.gameObject.name == "oeil")
        {
            quest2done = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Mob")
        {
            GameManager.Instance.life--;
            print("Ma vie : "+ GameManager.Instance.life);
            lifeBar.localScale = new Vector3(lifeBar.localScale.x - 0.1f, lifeBar.localScale.y, lifeBar.localScale.z);
            if(GameManager.Instance.life <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if(other.gameObject.name == "Ocean")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
    }
    IEnumerator HideDial()
    {
        yield return new WaitForSeconds(5);
        dial.SetActive(false);
    }
}
