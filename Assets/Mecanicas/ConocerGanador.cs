using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConocerGanador : MonoBehaviour {

	public Main main;
	public string ganador;
	public bool bandera;

	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		main = GameObject.Find("Main Camera").GetComponent<Main>();
		bandera = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(bandera){
			ganador = "El ganador es el jugador " + main.compararVida ();
			bandera = false;
		}
	}
}
