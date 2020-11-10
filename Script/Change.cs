using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Change : MonoBehaviour
{
    public Cannon execute;
    public GameObject objectToDisable;
    public static bool disable = false;
    public void OnMouseDown()
    {
        StartCoroutine("Hold");
    }

    private IEnumerator Hold()
    {
        yield return new WaitForSeconds(2f);
        objectToDisable.SetActive(false);
        execute.SendMessage("shoot");
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(0);
    }
}
