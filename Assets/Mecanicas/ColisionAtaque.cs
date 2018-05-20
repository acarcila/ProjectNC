using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionAtaque : MonoBehaviour {

	private MovimientoPersonaje personajeMovimiento;
	private UnidadAtaque personajeAtaque;
	private UnidadStats personaje;
	private Collider objetivoActual;

	// Use this for initialization
	void Start () {
		personajeMovimiento = GetComponentInParent<MovimientoPersonaje> ();
		personajeAtaque = GetComponentInParent<UnidadAtaque> ();
		personaje = GetComponentInParent<UnidadStats> ();

		setCastilloAsObjetivo ();
	}
	
	// Update is called once per frame
	void Update () {
		if(objetivoActual != null)
		{
			if(!objetivoActual.gameObject.activeInHierarchy)
			{
				setCastilloAsObjetivo ();
			}
		}else
		{
			setCastilloAsObjetivo ();

		}

	}

	void OnTriggerEnter(Collider objetivo){
		if(objetivo.gameObject.tag == personaje.unidadEnemiga)
		{
				objetivoActual = objetivo;
				personajeAtaque.objetivo = objetivoActual.gameObject.GetComponent<UnidadStats> ();	
				personajeMovimiento.mover = false;
				personajeAtaque.atacar = true;
		}
	}

	void OnTriggerStay(Collider objetivo){
		if(objetivo.gameObject.tag == personaje.unidadEnemiga)
		{
			objetivoActual = objetivo;
			personajeAtaque.objetivo = objetivoActual.gameObject.GetComponent<UnidadStats> ();	
			personajeMovimiento.mover = false;
			personajeAtaque.atacar = true;
		}

	}

	void OnTriggerExit(Collider objetivo){
		if(objetivo == objetivoActual)
		{
			setCastilloAsObjetivo ();
		}

	}

	private void setCastilloAsObjetivo()
	{
		if(personaje.unidadEnemiga == "UnidadRoja")
		{
			personajeAtaque.objetivo = GameObject.Find ("Castillo Rojo").gameObject.GetComponent<UnidadStats> ();
			objetivoActual = GameObject.Find ("Castillo Rojo").GetComponent<Collider>();
		}else if(personaje.unidadEnemiga == "UnidadAzul")
		{
			personajeAtaque.objetivo = GameObject.Find ("Castillo Azul").gameObject.GetComponent<UnidadStats> ();
			objetivoActual = GameObject.Find ("Castillo Azul").GetComponent<Collider>();
		}

		personajeMovimiento.mover = true;
		personajeAtaque.atacar = false;
	}
}
