using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected List<WeaponDatas> weaponData;
    [SerializeField] protected GameObject tower;
    [SerializeField] SpriteRenderer sr;
    public SpriteRenderer _Sr { get; private set; }

    [SerializeField] Animator anim;
    public Animator _Anim { get; private set; }

    public abstract void Shoot();

    public void InitializeData()
    {
        _Anim = anim;
        _Sr = sr;
    }
}
