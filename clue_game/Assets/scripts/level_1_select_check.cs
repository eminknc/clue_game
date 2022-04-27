using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level_1_select_check : MonoBehaviour
{
    public int selection_limit = 0;
    public GameObject[] first_images = new GameObject[4];
    public List<GameObject> select_objects = new List<GameObject>();
    Sequence seq;
    public Transform firs_grup;
    public Transform firs_grup_transform;

    public GameObject check_prefab;
    public GameObject false_prefab;
    Vector3 grup_old_pos;
    public Sprite image_1;
    public Sprite image_2;

    public void select(GameObject obj)
    {
        selection_limit++;
        for (int i = 0; i < selection_limit; i++)
        {

            first_images[i].transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
            first_images[i].GetComponent<Image>().sprite = image_2;
        }
        select_objects.Add(obj);
        if (selection_limit == 4) kontrol();
    }
    public void un_select(GameObject obj)
    {
        selection_limit--;
        for (int i = 0; i < first_images.Length; i++)
        {

            first_images[i].transform.localScale = new Vector3(1, 1, 1);
            first_images[i].GetComponent<Image>().sprite = image_1;
        }
        for (int i = 0; i < selection_limit; i++)
        {

            first_images[i].transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
            first_images[i].GetComponent<Image>().sprite = image_2;
        }
        select_objects.Remove(obj);
    }
    public void kontrol()
    {

        float anim_speed = 0.3f;
        int dogru_sayisi = 0;
        grup_old_pos = firs_grup.transform.position;
        seq = DOTween.Sequence();
        Tween tw_1 = firs_grup.transform.DOMove(firs_grup_transform.position, anim_speed).SetEase(Ease.OutBack);
        Tween tw_2 = first_images[0].transform.DOScale(Vector3.zero, anim_speed);
        Tween tw_3;
        if (select_objects[0].gameObject.name == "konusma10 1" || select_objects[0].gameObject.name == "konusma10 1 (1)" || select_objects[0].gameObject.name == "konusma10 1 (8)" || select_objects[0].gameObject.name == "konusma10 1 (4)")
        {
            GameObject clon = Instantiate(check_prefab, firs_grup.transform);
            clon.transform.position = first_images[0].transform.position;
            clon.transform.localScale = Vector3.zero;
            tw_3 = clon.transform.DOScale(new Vector3(1, 1, 1), anim_speed);
            dogru_sayisi++;
        }
        else
        {
            GameObject clon = Instantiate(false_prefab, firs_grup.transform);
            clon.transform.position = first_images[0].transform.position;
            clon.transform.localScale = Vector3.zero;
            tw_3 = clon.transform.DOScale(new Vector3(1, 1, 1), anim_speed);
        }

        Tween tw_4 = first_images[1].transform.DOScale(Vector3.zero, anim_speed);
        Tween tw_5;
        if (select_objects[1].gameObject.name == "konusma10 1" || select_objects[1].gameObject.name == "konusma10 1 (1)" || select_objects[1].gameObject.name == "konusma10 1 (8)" || select_objects[1].gameObject.name == "konusma10 1 (4)")
        {
            GameObject clon = Instantiate(check_prefab, firs_grup.transform);
            clon.transform.position = first_images[1].transform.position;
            clon.transform.localScale = Vector3.zero;
            tw_5 = clon.transform.DOScale(new Vector3(1, 1, 1), anim_speed);
            dogru_sayisi++;
        }
        else
        {
            GameObject clon = Instantiate(false_prefab, firs_grup.transform);
            clon.transform.position = first_images[1].transform.position;
            clon.transform.localScale = Vector3.zero;
            tw_5 = clon.transform.DOScale(new Vector3(1, 1, 1), anim_speed);
        }

        Tween tw_6 = first_images[2].transform.DOScale(Vector3.zero, anim_speed);
        Tween tw_7;
        if (select_objects[2].gameObject.name == "konusma10 1" || select_objects[2].gameObject.name == "konusma10 1 (1)" || select_objects[2].gameObject.name == "konusma10 1 (8)" || select_objects[2].gameObject.name == "konusma10 1 (4)")
        {
            GameObject clon = Instantiate(check_prefab, firs_grup.transform);
            clon.transform.position = first_images[2].transform.position;
            clon.transform.localScale = Vector3.zero;
            tw_7 = clon.transform.DOScale(new Vector3(1, 1, 1), anim_speed);
            dogru_sayisi++;
        }
        else
        {
            GameObject clon = Instantiate(false_prefab, firs_grup.transform);
            clon.transform.position = first_images[2].transform.position;
            clon.transform.localScale = Vector3.zero;
            tw_7 = clon.transform.DOScale(new Vector3(1, 1, 1), anim_speed);
        }

        Tween tw_8 = first_images[3].transform.DOScale(Vector3.zero, anim_speed);
        Tween tw_9;
        if (select_objects[3].gameObject.name == "konusma10 1" || select_objects[3].gameObject.name == "konusma10 1 (1)" || select_objects[3].gameObject.name == "konusma10 1 (8)" || select_objects[3].gameObject.name == "konusma10 1 (4)")
        {
            GameObject clon = Instantiate(check_prefab, firs_grup.transform);
            clon.transform.position = first_images[3].transform.position;
            clon.transform.localScale = Vector3.zero;
            tw_9 = clon.transform.DOScale(new Vector3(1, 1, 1), anim_speed);
            dogru_sayisi++;
        }
        else
        {
            GameObject clon = Instantiate(false_prefab, firs_grup.transform);
            clon.transform.position = first_images[3].transform.position;
            clon.transform.localScale = Vector3.zero;
            tw_9 = clon.transform.DOScale(new Vector3(1, 1, 1), anim_speed);
        }





        seq.Append(tw_1).Append(tw_2).Append(tw_3).Append(tw_4).Append(tw_5).Append(tw_6).Append(tw_7)
            .Append(tw_8).Append(tw_9).OnComplete(() => kontrol2(dogru_sayisi));


    }
    public void kontrol2(int dogru_sayisi)
    {

        if (dogru_sayisi < 4)
        {
            
            StartCoroutine(wait());
            Destroy(select_objects[0].transform.GetChild(3).gameObject);
            Destroy(select_objects[1].transform.GetChild(3).gameObject);
            Destroy(select_objects[2].transform.GetChild(3).gameObject);
            Destroy(select_objects[3].transform.GetChild(3).gameObject);
            select_objects[0].GetComponent<select_script>().selected = false;
            select_objects[1].GetComponent<select_script>().selected = false;
            select_objects[2].GetComponent<select_script>().selected = false;
            select_objects[3].GetComponent<select_script>().selected = false;
            selection_limit = 0;
            select_objects.Clear();

        }
        else
        {

            
            Destroy(select_objects[0].transform.GetChild(3).gameObject);
            Destroy(select_objects[1].transform.GetChild(3).gameObject);
            Destroy(select_objects[2].transform.GetChild(3).gameObject);
            Destroy(select_objects[3].transform.GetChild(3).gameObject);
            select_objects[0].GetComponent<select_script>().selected = false;
            select_objects[1].GetComponent<select_script>().selected = false;
            select_objects[2].GetComponent<select_script>().selected = false;
            select_objects[3].GetComponent<select_script>().selected = false;
            selection_limit = 0;
            GameObject[] check_false_objs = GameObject.FindGameObjectsWithTag("check_false");
            for (int i = 0; i < check_false_objs.Length; i++)
            {
                Destroy(check_false_objs[i].gameObject);
            }
            GameObject[] caracters_objs = GameObject.FindGameObjectsWithTag("caracters");
            for (int i = 0; i < caracters_objs.Length; i++)
            {
                if (caracters_objs[i] != select_objects[0] && caracters_objs[i] != select_objects[1] && caracters_objs[i] != select_objects[2] && caracters_objs[i] != select_objects[3])
                {
                    Destroy(caracters_objs[i].gameObject);
                }
                caracters_objs[i].GetComponent<select_script>().clue_count++;
            }
            transform.GetComponent<ui_canvas_script>().clue_1_get_more_small_anim();

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
        firs_grup.transform.position = grup_old_pos;
        seq = DOTween.Sequence();
        Tween tw_1 = first_images[0].transform.DOScale(new Vector3(1, 1, 1), anim_speed).SetEase(Ease.OutBack);
        Tween tw_2 = first_images[1].transform.DOScale(new Vector3(1, 1, 1), anim_speed).SetEase(Ease.OutBack);
        Tween tw_3 = first_images[2].transform.DOScale(new Vector3(1, 1, 1), anim_speed).SetEase(Ease.OutBack);
        Tween tw_4 = first_images[3].transform.DOScale(new Vector3(1, 1, 1), anim_speed).SetEase(Ease.OutBack);
        seq.Append(tw_1).Append(tw_2).Append(tw_3).Append(tw_4);
    }

}
