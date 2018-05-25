using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedireccionarObjetivo : MonoBehaviour {

	private string unidadAliada;
	private string unidadEnemiga;

	// Use this for initialization
	void Start () {
		unidadAliada = this.name;
		seleccionarUnidadEnemiga ();
		Debug.Log (unidadAliada);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (unidadEnemiga);
		seleccionarUnidadEnemiga ();
	}

	void OnTriggerEnter(Collider other)
	{
		
		if(other.gameObject.tag == unidadEnemiga)
		{
			other.gameObject.GetComponent<MovimientoPersonaje> ().banderaRedireccionamiento = true;
		}

	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == unidadEnemiga)
		{

			other.gameObject.GetComponent<MovimientoPersonaje> ().banderaRedireccionamiento = true;

		}

	}

	private void seleccionarUnidadEnemiga()
	{
		switch(unidadAliada){
		case "Collider Redireccion Rojo":
			unidadEnemiga = "UnidadAzul";
			break;
		case "Collider Redireccion Azul":
			unidadEnemiga = "UnidadRoja";
			break;
		}
	}
}
