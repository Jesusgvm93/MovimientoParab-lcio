using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cannon : MonoBehaviour
{
    public int angle;
    public int velocity;
    public double distance;
    public string velocidad, angulo, distancia;
    public static bool enable = true;
    public static bool enable2 = true;
    public static bool disable = false;
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public GameObject objectToEnable;
    public GameObject objectToEnable2;
    public GameObject objectToEnable3;
    public GameObject objectToDisable;
    public InputField velocityB, angleB, distanceB;

    void Update()
    {
        if (velocity <= -1 || angle <= -1 || distance <= -1 || angle > 91)
        {
            Debug.Log("Todos los campos deben ser digilenciados con valores positivos");
            SceneManager.LoadScene(0);
        }
        else
        {
                faceMouse();
                if (Input.GetButtonDown("Fire2"))
                {
                    check();
                    shoot();
                    xMax();
                }     
        }
        
    }
    void faceMouse()
    {
        transform.rotation = Quaternion.Euler(0, 0, (angle - 90));
    }

    public void shoot()
    {
        StartCoroutine("Shoot");
        GameObject newBulletPrefab = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        newBulletPrefab.GetComponent<Rigidbody2D>().velocity = transform.up * velocity;
    }

    public void setget()
    {
        velocidad = velocityB.text;
        int a = Convert.ToInt32(velocidad);
        velocity = a;
        angulo = angleB.text;
        int b = Convert.ToInt32(angulo);
        angle = b;
        distancia = distanceB.text;
        double c = Convert.ToDouble(distancia);
        //double d = Math.Round(c, 2);
        distance = c;
    }

    public void xMax()
    {
        double a = Convert.ToDouble(angle);
        double b = a * (Math.PI / 180);
        double c = Math.Sin(2 * b);
        double d = Convert.ToDouble(velocity);
        double e = ((d * d) * c) / 9.8;
        double f = Math.Round(e, 2);
        double g = Math.Round( f * 0.05f ,2);
        double h = f + g;
        double i = f - g;
        
        Debug.Log(f);
        Debug.Log(h);
        Debug.Log(i);

        if (distance == f || (distance >= i && distance <= h))
        {
            StartCoroutine("Congrats");
            Debug.Log("Felicitaciones");
        }

        else
        {
            StartCoroutine("Failed");
            Debug.Log("Intenta de Nuevo");
        }

    }

    public void check()
    {
        if (string.IsNullOrEmpty(velocityB.text) || string.IsNullOrEmpty(angleB.text) || string.IsNullOrEmpty(distanceB.text))
        {
            StartCoroutine("checkB");
        }
    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Congrats()
    {
        yield return new WaitForSeconds(5f);
        objectToEnable.SetActive(true);
    }

    public IEnumerator Failed()
    {
        yield return new WaitForSeconds(5f);
        objectToEnable2.SetActive(true);
    }

    public IEnumerator checkB()
    {
        objectToEnable3.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }



}
