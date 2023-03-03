using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneLift : MonoBehaviour
{

    public float delayTime;
    //public Animator anim;

    private Animation anim;
    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animation>();
        StartCoroutine(Go());

    }

    IEnumerator Go()
    {
        while (true)
        {
            anim.Play();
            yield return new WaitForSeconds(1f);
        }

    }


}

