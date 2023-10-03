using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSite : MonoBehaviour
{
    [SerializeField] GameObject tower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(tower, transform.position, Quaternion.identity);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
