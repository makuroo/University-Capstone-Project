using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHover : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer rangeSR;
    private void OnMouseOver()
    {
        rangeSR.enabled = true ;
    }

    private void OnMouseExit()
    {
        rangeSR.enabled = false;
    }
}
