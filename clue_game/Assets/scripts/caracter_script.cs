using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caracter_script : MonoBehaviour
{
    public bool random = true;
    public GameObject hair_and_head_group;
    public GameObject býyýk_group;
    public GameObject eye_glasses_group;
    public GameObject accessory_group;

    public bool[] animler = new bool[8];
    public bool[] hair_and_head = new bool[7];
    public bool[] býyýk = new bool[6];
    public bool[] eye_glasses = new bool[8];
    public bool[] accessory = new bool[1];
    public bool[] mesh_textures = new bool[4];

    public GameObject obj_mesh;
    public Texture2D[] textures = new Texture2D[4];
    public bool flag = true;

    void Start()
    {
        if (random)
        {
            int rand = Random.Range(0, animler.Length);
            animler[rand] = true;
            rand = Random.Range(0, hair_and_head.Length);
            hair_and_head[rand] = true;
            rand = Random.Range(0, býyýk.Length);
            býyýk[rand] = true;
            rand = Random.Range(0, eye_glasses.Length);
            eye_glasses[rand] = true;
            rand = Random.Range(0, accessory.Length);
            accessory[rand] = true;
            rand = Random.Range(0, mesh_textures.Length);
            mesh_textures[rand] = true;
        }
        set_anim();
        set_hair();
        set_biyik();
        set_glasses();
        set_accessory();
        StartCoroutine(fix_it());

    }
    IEnumerator fix_it()
    {

        Vector3 old_pos = transform.position;
        Vector3 old_rot = transform.eulerAngles;
        for (; ; )
        {
            if (flag)
            {
                yield return new WaitForSeconds(5);
                transform.position = old_pos;
                transform.eulerAngles = old_rot;
            }
            else { break; }
        }


    }


    public void set_anim()
    {
        for (int i = 0; i < animler.Length; i++)
        {
            if (animler[i] == true)
            {
                GetComponent<Animator>().SetBool("anim" + (i + 1).ToString(), true);
                break;
            }

        }


    }
    public void set_hair()
    {
        for (int i = 0; i < hair_and_head.Length; i++)
        {
            if (hair_and_head[i] == true)
            {
                hair_and_head_group.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }

        }
    }
    public void set_biyik()
    {
        for (int i = 0; i < býyýk.Length; i++)
        {
            if (býyýk[i] == true)
            {
                býyýk_group.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }

        }
    }
    public void set_glasses()
    {
        for (int i = 0; i < eye_glasses.Length; i++)
        {
            if (eye_glasses[i] == true)
            {
                eye_glasses_group.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }

        }
    }
    public void set_accessory()
    {
        for (int i = 0; i < accessory.Length; i++)
        {
            if (accessory[i] == true)
            {
                accessory_group.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }

        }

    }
    public void set_texture()
    {
        for (int i = 0; i < mesh_textures.Length; i++)
        {
            if (mesh_textures[i] == true)
            {
                obj_mesh.GetComponent<SkinnedMeshRenderer>().material.SetTexture("_MainTex", textures[i]);
            }

        }

    }

}
