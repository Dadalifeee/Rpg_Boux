using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpells : MonoBehaviour
{
    public GameObject[] spells;
    public AudioClip[] magicSfx;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Spell1();
        Spell2();
    }

    public void Spell1()
    {
        if (Input.GetKey("a"))
        {
            audioSource.PlayOneShot(magicSfx[0]);
            GameObject go = Instantiate(spells[0], new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);
            Destroy(go, 3);
            GetComponent<SphereCollider>().enabled = true;
            StartCoroutine("DisableCollider");
        }
    }
    public void Spell2()
    {
        if (Input.GetKey("e"))
        {
            print("oui");
            audioSource.PlayOneShot(magicSfx[1]);
            GameObject go = Instantiate(spells[1], new Vector3(0, transform.position.y, 1), Quaternion.identity);
            Destroy(go, 3);
            GetComponent<SphereCollider>().enabled = true;
            StartCoroutine("DisableCollider");
        }
    }
    public void Spell3()
    {
        GameObject go = Instantiate(spells[2], transform.position, Quaternion.identity);
        Destroy(go, 3);
    }
    public void Spell4()
    {
        GameObject go = Instantiate(spells[3], transform.position, Quaternion.identity);
        Destroy(go, 3);
    }
    IEnumerable DisableCollider()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SphereCollider>().enabled = false;
    }
}
