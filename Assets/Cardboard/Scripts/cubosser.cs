﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class cubosser : MonoBehaviour {

    //public string acargar;
    private int npregunta = variables.npa;
    private float ini;
    private float tiempo = variables.tiempo;
    private bool fun;
    public int numerocubo;
    private int respuesta = 0;
    private string url = "https://logical-children.herokuapp.com/users/authentication.txt?";
    private int preguntaactual = variables.npa;
    void Awake()
    {

    }

    public void SetGazedAt(bool gazedAt)
    {

        GetComponent<Renderer>().material.color = Color.green;
        ini = Time.time;
        fun = true;
        GameObject.Find("letrero").GetComponent<TextMesh>().text = "   " + "Evaluando!!!!";
    }

    public void OnGazeEnter()
    {
        throw new NotImplementedException();
    }

    public void OnGazeExit()
    {
        GetComponent<Renderer>().material.color = Color.red;
        GameObject.Find("letrero").GetComponent<TextMesh>().text = "";

        fun = false;
    }

    public void OnGazeTrigger()
    {
        throw new NotImplementedException();
    }
    void Update()
    {

        if (fun)
        {
            //GameObject.Find("letrero").GetComponent<TextMesh>().text = ""+ (int)(Time.time - ini);

            if ((Time.time - ini) >= tiempo)
            {
                GameObject.Find("letrero").GetComponent<TextMesh>().text = "CARGADO!!!!";
                fun = false;

                if (numerocubo == 3)
                {
                    variables.npa = 2;
                    GameObject.Find("letrero").GetComponent<TextMesh>().text = "la respuesta es: rostro triste";
                    url = "https://logical-children.herokuapp.com/students/history?";

					url = url + "student_id=" + variables.id + "&nivel=" + (variables.modo - 1) + "&intentos_fallidos=" + variables.intentos_fallidos + "&modulo_evaluado=" + 2 + "&num_pregunta=" + preguntaactual + "&acerto_pregunta=" + "1";
                    Debug.Log(url);
                    WWW www = new WWW(url);
                    StartCoroutine("GetdataEnumerator", www);
                    variables.intentos_fallidos = 0;
                    SceneManager.LoadScene("ser2");

                }
            }
        }
    }
}
