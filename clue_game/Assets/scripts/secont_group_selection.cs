using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secont_group_selection : MonoBehaviour
{
    public int selection_limit = 0;
    public GameObject[] secont_images = new GameObject[2];
    public List<GameObject> select_objects = new List<GameObject>();
    Sequence seq;
    Vector3 grup_old_pos;
    public Transform secont_grup;
    public Transform secont_grup_transform;
    public GameObject check_prefab;
    public GameObject false_prefab;
    public Sprite image_1;
    public Sprite image_2;

    public void select(GameObject obj)
    {
        selection_limit++;
        for (int i = 0; i < selection_limit; i++)
        {

            secont_images[i].transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
            secont_images[i].GetComponent<Image>().sprite = image_2;
        }
        select_objects.Add(obj);
        if (selection_limit == 2) kontrol();
    }
    public void un_select(GameObject obj)
    {
        selection_limit--;
        for (int i = 0; i < secont_images.Length; i++)
        {

            secont_images[i].transform.localScale = new Vector3(1, 1, 1);
            secont_images[i].GetComponent<Image>().sprite = image_1;
        }
        for (int i = 0; i < selection_limit; i++)
        {

            secont_images[i].transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
            secont_images[i].GetComponent<Image>().sprite = image_2;
        }
        select_objects.Remove(obj);

    }
    public void kontrol()
    {
        float anim_speed = 0.3f;
        int dogru_sayisi = 0;
        grup_old_pos = secont_grup.transform.position;
        seq = DOTween.Sequence();
        Tween tw_1 = secont_grup.transform.DOMove(secont_grup_transform.position, anim_speed).SetEase(Ease.OutBack);
        Tween tw_2 = secont_images[0].transform.DOScale(Vector3.zero, anim_speed);
        Tween tw_3;
        if (select_objects[0].gameObject.name == "konusma10 1" || select_objects[0].gameObject.name == "konusma10 1 (8)")
        {
            GameObject clon = Instantiate(check_prefab, secont_grup.transform);
            clon.transform.position = secont_images[0].transform.position;
            clon.transform.localScale = Vector3.zero;
            tw_3 = clon.transform.DOScale(new Vector3(1, 1, 1), anim_speed);
            dogru_sayisi++;
        }
        else
        {
            GameObject clon = Instantiate(false_prefab, secont_grup.transform);
            clon.transform.position = secont_images[0].transform.position;
            clon.transform.localScale = Vector3.zero;
            tw_3 = clon.transform.DOScale(new Vector3(1, 1, 1), anim_speed);
        }

        Tween tw_4 = secont_images[1].transform.DOScale(Vector3.zero, anim_speed);
        Tween tw_5;
        if (select_objects[1].gameObject.name == "konusma10 1" || select_objects[1].gameObject.name == "konusma10 1 (8)")
        {
            GameObject clon = Instantiate(check_prefab, secont_grup.transform);
            clon.transform.position = secont_images[1].transform.position;
            clon.transform.localScale = Vector3.zero;
            tw_5 = clon.transform.DOScale(new Vector3(1, 1, 1), anim_speed);
            dogru_sayisi++;
        }
        else
        {
            GameObject clon = Instantiate(false_prefab, secont_grup.transform);
            clon.transform.position = secont_images[1].transform.position;
            clon.transform.localScale = Vector3.zero;
            tw_5 = clon.transform.DOScale(new Vector3(1, 1, 1), anim_speed);
        }

        seq.Append(tw_1).Append(tw_2).Append(tw_3).Append(tw_4).Append(tw_5).OnComplete(() => kontrol2(dogru_sayisi));
    }
    public void kontrol2(int dogru_sayisi)
    {

        if (dogru_sayisi < 2)
        {
            StartCoroutine(wait());
            Destroy(select_objects[0].transform.GetChild(3).gameObject);
            Destroy(select_objects[1].transform.GetChild(3).gameObject);
            select_objects[0].GetComponent<select_script>().selected = false;
            select_objects[1].GetComponent<select_script>().selected = false;
            selection_limit = 0;
            select_objects.Clear();

        }
        else
        {
            Destroy(select_objects[0].transform.GetChild(3).gameObject);
            Destroy(select_objects[1].transform.GetChild(3).gameObject); ;
            select_objects[0].GetComponent<select_script>().selected = false;
            select_objects[1].GetComponent<select_script>().selected = false;
            selection_limit = 0;
            GameObject[] check_false_objs = GameObject.FindGameObjectsWithTag("check_false");
            for (int i = 0; i < check_false_objs.Length; i++)
            {
                Destroy(check_false_objs[i].gameObject);
            }
            GameObject[] caracters_objs = GameObject.FindGameObjectsWithTag("caracters");
            for (int i = 0; i < caracters_objs.Length; i++)
            {
                if (caracters_objs[i] != select_objects[0] && caracters_objs[i] != select_objects[1])
                {
                    Destroy(caracters_objs[i].gameObject);
                }
                caracters_objs[i].GetComponent<select_script>().clue_count++;
            }
            transform.GetComponent<ui_canvas_script>().clue_2_get_more_small_anim();
            
        }

    }
    IEnumerator wait()
    {

        yield return new WaitForSeconds(1);
        float anim_speed = 0.3f;
        GameObject[] check_false_objs = GameObject.FindGameObjectsWithTag("check_false");
        for (int i = 0; i < check_false_objs.Length; i++)
        {
            Destroy(check_false_objs[i].gameObject);
        }
        secont_grup.transform.position = grup_old_pos;
        seq = DOTween.Sequence();
        Tween tw_1 = secont_images[0].transform.DOScale(new Vector3(1, 1, 1), anim_speed).SetEase(Ease.OutBack);
        Tween tw_2 = secont_images[1].transform.DOScale(new Vector3(1, 1, 1), anim_speed).SetEase(Ease.OutBack);
        seq.Append(tw_1).Append(tw_2);
    }
}
