using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public Cannon check;
        public void OnMouseDown()
    {
        StartCoroutine("Revisar");
    }

    private IEnumerator Revisar()
    {
        yield return new WaitForSeconds(0.1f);
        check.SendMessage("check");
      
    }
}

