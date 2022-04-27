using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_canvas_script : MonoBehaviour
{
    float anim_speed = 0.5f;
    Vector3 clue_1_old_scale;
    Vector3 clue_2_old_scale;
    Vector3 clue_3_old_scale;

    public GameObject second_group;

    public Transform clue_1;
    public Transform clue_1_transform;

    public Transform clue_2;
    public Transform clue_2_transform;

    public Transform clue_3;
    public Transform clue_3_transform;

    void Start()
    {
        clue_1.gameObject.SetActive(true);
        clue_1_old_scale = clue_1.transform.localScale;
        clue_1.transform.localScale = new Vector3(0, 0, 0);
        clue_1.transform.DOScale(clue_1_old_scale, anim_speed).SetEase(Ease.OutBack);
    }
    void Update()
    {
        if (Input.GetKeyUp("s")) {
            clue_1_get_small_anim();
        }
     
    }
    public void clue_1_get_small_anim() {
        
        clue_1.transform.DOMove(clue_1_transform.position, anim_speed).SetEase(Ease.InBack);
        clue_1.transform.DOScale(clue_1_transform.localScale, anim_speed).SetEase(Ease.InBack);     
        clue_1.transform.DOLocalRotate(new Vector3(0, 0, 0), anim_speed);
    }
    public void clue_1_get_more_small_anim()
    {
        clue_1.GetChild(1).gameObject.SetActive(true);
        clue_1.GetChild(1).transform.localScale = Vector3.zero;
        clue_1.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), anim_speed).SetEase(Ease.OutBack);
        clue_2_get_big_anim();


    }
    public void clue_2_get_big_anim() {
        clue_2.gameObject.SetActive(true);
        clue_2_old_scale = clue_2.transform.localScale;
        clue_2.transform.localScale = new Vector3(0, 0, 0);
        clue_2.transform.DOScale(clue_2_old_scale, anim_speed).SetEase(Ease.OutBack);
        second_group.SetActive(true);

    }
    public void clue_2_get_small_anim()
    {

        clue_2.transform.DOMove(clue_2_transform.position, anim_speed).SetEase(Ease.InBack);
        clue_2.transform.DOScale(clue_2_transform.localScale, anim_speed).SetEase(Ease.InBack);
        clue_2.transform.DOLocalRotate(new Vector3(0, 0, 0), anim_speed);
    }
    public void clue_2_get_more_small_anim()
    {
        clue_2.GetChild(1).gameObject.SetActive(true);
        clue_2.GetChild(1).transform.localScale = Vector3.zero;
        clue_2.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), anim_speed).SetEase(Ease.OutBack);
        clue_3_get_big_anim();
    }
    public void clue_3_get_big_anim()
    {
        clue_3.gameObject.SetActive(true);
        clue_3_old_scale = clue_3.transform.localScale;
        clue_3.transform.localScale = new Vector3(0, 0, 0);
        clue_3.transform.DOScale(clue_3_old_scale, anim_speed).SetEase(Ease.OutBack);
        

    }
    public void clue_3_get_small_anim()
    {

        clue_3.transform.DOMove(clue_3_transform.position, anim_speed).SetEase(Ease.InBack);
        clue_3.transform.DOScale(clue_3_transform.localScale, anim_speed).SetEase(Ease.InBack);
        clue_3.transform.DOLocalRotate(new Vector3(0, 0, 0), anim_speed);
    }

}
