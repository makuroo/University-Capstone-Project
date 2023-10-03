using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHover : MonoBehaviour
{
    [SerializeField] protected GameObject rangeGO;
    private void OnMouseOver()
    {
        rangeGO.SetActive(true);
    }

    private void OnMouseExit()
    {
        rangeGO.SetActive(false);
    }
}
