using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public enum type
    {
        semi_auto,
        auto,
        points,
        charge,
        beam
    }

    public bool Infinity;

    float magazine_Max; //화기의 최대보유 탄약수

    public type _type;

    [Range(0, 50)] //탄창크기
    public float magazine_size;

    public void check()
    {
        if (Infinity)
        {
            magazine_Max = Mathf.Infinity;
        }
        else
        {

        }
    }

    [Range(0, 50)] //재장전 시간 낮을수록빠름
    public float reload;

    [Range(0, 50)] //데미지
    public float damage;

    [Range(0, 50)] //사격후 다음발사까지의 시간 낮을수록 연사가 빠름
    public float delay;

    [Range(0, 50)] //탄속
    public float bullet_speed;

    [Range(0, 50)] //탄 사정거리
    public float range;

    [Range(0, 50)] //탄 적중시 넉백정도
    public float knockback;

    [Range(0, 50)] //탄퍼짐 정도 높을수록 집탄률이 좋지못함
    public float spread;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
