using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpells : MonoBehaviour
{
    public GameObject[] spells;
    public AudioClip[] magicSfx;
    private AudioSource audioSource;
    private bool CanSpellAtack = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        SpellMisc();
        SpellFire();
        Spellheal();
        SpellIce();
    }

    public void SpellMisc()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1) && CanSpellAtack)
        {
            audioSource.PlayOneShot(magicSfx[3]);
            // GameObject go = Instantiate(spells[0], new Vector3(transform.position.x, transform.position.y, transform.position.z + 1));
            GameObject go = Instantiate(spells[0], transform.position + (transform.forward * 5), transform.rotation);
            go.transform.position += Vector3.up;
            go.name = "SpellMisc";
            CanSpellAtack = false;
            StartCoroutine("AttackSpell");
            Destroy(go, 3);
        }
    }
    public void SpellFire()
    {
        if (Input.GetKeyUp(KeyCode.Alpha2) && CanSpellAtack)
        {
            audioSource.PlayOneShot(magicSfx[0]);
            GameObject go = Instantiate(spells[1], transform.position + (transform.forward * 5), transform.rotation);
            go.transform.position += Vector3.up;
            go.name = "SpellFire";
            CanSpellAtack = false;
            StartCoroutine("AttackSpell");
            Destroy(go, 3);
        }
    }
    public void Spellheal()
    {
        if (Input.GetKeyUp(KeyCode.Alpha3) && CanSpellAtack)
        {
            audioSource.PlayOneShot(magicSfx[1]);
            GameObject go = Instantiate(spells[4], transform.position,transform.rotation); ;
            go.name = "Spellheal";
            CanSpellAtack = false;
            print("avant  : " + GameManager.Instance.life);
            GameManager.Instance.life += 5;
            print("apres : "+GameManager.Instance.life);
            StartCoroutine("AttackSpell");
            Destroy(go, 3);
        }
    }
    public void SpellIce()
    {
        if (Input.GetKeyUp(KeyCode.Alpha4) && CanSpellAtack)
        {
            audioSource.PlayOneShot(magicSfx[0]);
            GameObject go = Instantiate(spells[3], transform.position + (transform.forward * 5), transform.rotation); ;
            go.transform.position += Vector3.up;
            go.name = "SpellIce";
            CanSpellAtack = false;
            StartCoroutine("AttackSpell");
            Destroy(go, 3);
        }
    }
    IEnumerator AttackSpell()
    {
        yield return new WaitForSeconds(1);
        CanSpellAtack = true;
    }
}
