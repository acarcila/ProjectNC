using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnidadAtaque : MonoBehaviour {

	public UnidadStats objetivo;
	public bool atacar;
	public Transform personaje;

	private UnidadStats stats;
	private int frameCount = 0;
	private int frameMax = 60;


	// Use this for initialization
	void Start () {
		atacar = false;
		stats = this.GetComponent<UnidadStats>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		int daño = stats.daño;
		float mulitplicador = 1f;
		char miTipo = stats.tipo;
		char enemigoTipo = objetivo.tipo;

		mulitplicador = multiplicarDaño (miTipo, enemigoTipo);

		frameCount++;

		if(frameCount > frameMax && atacar)
		{
			objetivo.vida -= Mathf.RoundToInt(daño * mulitplicador);
			frameCount = 0;
		}

	}

	public float multiplicarDaño(char miTipo, char enemigoTipo){
		float multiplicador = 1f;

		switch(miTipo){
		case 'G':
			switch(enemigoTipo){
			case 'A':
				multiplicador = 0.5f;
				break;
			case 'M':
				multiplicador = 2f;
				break;
			}
			break;
		case 'A':
			switch(enemigoTipo){
			case 'G':
				multiplicador = 2f;
				break;
			case 'M':
				multiplicador = 0.5f;
				break;
			}
			break;
		case 'M':
			switch(enemigoTipo){
			case 'G':
				multiplicador = 0.5f;
				break;
			case 'A':
				multiplicador = 2f;
				break;
			}
			break;
		default:
			multiplicador = 1f;
			break;
		}
		return multiplicador;
	}
}
