using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecenterOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.localPosition = Vector3.zero;
        //transform.localRotation = Quaternion.identity;

        //Recenter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Recenter();
        }
    }

    void Recenter ()
    {
        print("Recentering...");
        transform.parent.localPosition = Vector3.zero;
        
        print("Before: " + transform.parent.localPosition);
        transform.parent.localRotation = Quaternion.Inverse(transform.localRotation);
        Vector3 cachedPosition = transform.position - transform.parent.parent.position;
        print("After: " + transform.parent.localPosition);
        transform.parent.localPosition = -cachedPosition;
    }

    IEnumerator RecenterCR ()
    {
        float waitTime = 5f;
        float t = 0f;

        while ((t += Time.deltaTime) < waitTime)
        {
            yield return new WaitForEndOfFrame();
        }
    }
}
