using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbarscript : MonoBehaviour
{
    Vector3 localscale;
    Enemy[] Dillos;
    // Start is called before the first frame update
    void Start()
    {
        Dillos = GameObject.FindObjectsOfType<Enemy>();
        localscale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localscale.x = Dillos[0].currHealth / Dillos[0].maxhealth;
        transform.localScale = localscale;
    }
}
