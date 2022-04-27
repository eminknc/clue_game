using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select_script : MonoBehaviour
{
    public bool selected = false;
    public Transform hiza;
    public GameObject select_effect;
    public GameObject effect_clon = null;
    public GameObject canvass;
    public GameObject kafes;
    bool down_up = false;
    public int clue_count = 1;


    void OnMouseDown()
    {
        down_up = true;
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.2f);
        down_up = false;

    }
    void OnMouseUp()
    {
        if (down_up)
        {
            if (selected == false)
            {
                if (clue_count == 1)
                {
                    if (canvass.GetComponent<level_1_select_check>().selection_limit < 4)
                    {
                        effect_clon = Instantiate(select_effect, hiza.position, Quaternion.identity, transform);
                        selected = true;
                        canvass.GetComponent<level_1_select_check>().select(gameObject);

                    }
                }
                else if (clue_count == 2)
                {
                    if (canvass.GetComponent<secont_group_selection>().selection_limit < 2)
                    {
                        effect_clon = Instantiate(select_effect, hiza.position, Quaternion.identity, transform);
                        selected = true;
                        canvass.GetComponent<secont_group_selection>().select(gameObject);

                    }

                }
                else if (clue_count == 3) {
                    if (gameObject.name == "konusma10 1 (8)") {

                        kafes.SetActive(true);
                        StartCoroutine(win_wait());
                    }
                }
            }
            else
            {
                if (clue_count == 1)
                {
                    Destroy(effect_clon.gameObject);
                    selected = false;
                    canvass.GetComponent<level_1_select_check>().un_select(gameObject);
                }
                else if (clue_count == 2)
                {
                    Destroy(effect_clon.gameObject);
                    selected = false;
                    canvass.GetComponent<secont_group_selection>().un_select(gameObject);

                }
                
            }
        }
    }
    IEnumerator win_wait() {
        yield return new WaitForSeconds(5);
        Application.LoadLevel("SampleScene");
    
    }
}
