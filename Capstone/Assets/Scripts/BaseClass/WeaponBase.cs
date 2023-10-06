using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{

    [SerializeField] protected GameObject tower;

    [SerializeField] private List<WeaponDatas> weaponData;
    public List<WeaponDatas> _weaponData { get; private set; }

    [SerializeField] private GameObject currTarget;
    public GameObject _currTarget { get;  set; }

    [SerializeField] SpriteRenderer sr;
    public SpriteRenderer _sr { get; private set; }

    [SerializeField] Animator anim;
    public Animator _anim { get; private set; }

    public abstract void Shoot();

    public void InitializeData()
    {
        _anim = anim;
        _sr = sr;
        _sr.sprite = weaponData[tower.GetComponent<TowerBase>()._tier].sprite;
        _weaponData = weaponData;
    }

    public void FaceTarget(Transform weapon)
    {
        Vector2 dir =  _currTarget.transform.position - transform.position;
        weapon.transform.up = dir;
    }
}
