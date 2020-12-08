using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 localscale;
    BossHealth healthscript;
    // Start is called before the first frame update
    void Start()
    {
        healthscript = transform.parent.gameObject.GetComponent<BossHealth>();
        localscale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localscale.x = healthscript.currHealth / healthscript.maxhealth;
        transform.localScale = localscale;
    }
}
