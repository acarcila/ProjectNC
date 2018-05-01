using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionRango : MonoBehaviour {

	private MovimientoPersonaje personajeMovimiento;
	private UnidadStats personaje;
	private Collider objetivoActual;

	// Use this for initialization
	void Start () {
		personaje = GetComponentInParent<UnidadStats> ();
		personajeMovimiento = GetComponentInParent<MovimientoPersonaje> ();

		setCastilloAsObjetivo ();
	}

	void Update(){
		if (objetivoActual != null) {
			if (!objetivoActual.gameObject.activeInHierarchy) {
				setCastilloAsObjetivo ();
			}
		} else 
		{
			setCastilloAsObjetivo ();
		}
	}

	void OnTriggerEnter(Collider objetivo){
		if(objetivo.gameObject.tag == personaje.unidadEnemiga)
		{
				objetivoActual = objetivo;	
				personajeMovimiento.meta = objetivoActual.gameObject.transform;
		}
	}

	void OnTriggerStay(Collider objetivo){
		if(objetivo.gameObject.tag == personaje.unidadEnemiga)
		{
			objetivoActual = objetivo;	
			personajeMovimiento.meta = objetivoActual.gameObject.transform;
		}
	}

	void OnTriggerExit(Collider objetivo){
		Debug.Log (objetivo.gameObject.name);
		if(objetivo == objetivoActual)
		{
			setCastilloAsObjetivo ();
		}

	}

	private void setCastilloAsObjetivo()
	{
		if (personaje.unidadEnemiga == "UnidadRoja") {
			personajeMovimiento.meta = GameObject.Find ("Castillo Rojo").transform;
			objetivoActual = GameObject.Find ("Castillo Rojo").GetComponent<Collider> ();
		} else if (personaje.unidadEnemiga == "UnidadAzul") {
			personajeMovimiento.meta = GameObject.Find ("Castillo Azul").transform;
			objetivoActual = GameObject.Find ("Castillo Azul").GetComponent<Collider> ();
		}
		personajeMovimiento.mover = true;
	}


}
