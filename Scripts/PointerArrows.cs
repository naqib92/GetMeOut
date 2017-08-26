using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointerArrows : MonoBehaviour {



    public Transform target;
   // public float speed;
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);

        /**
        Vector3 targetDir = target.position - transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    **/
    }
}
