using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour {

	public Transform meta;
	private UnidadStats personaje;
	public bool mover;
	public bool banderaRedireccionamiento;

	private Vector3 vectorPosicion;

	// Use this for initialization
	void Start () {
		if(this.tag == "UnidadAzul"){
			meta = GameObject.Find ("Castillo Rojo").transform;
		}else{
			meta = GameObject.Find ("Castillo Azul").transform;
		}
		vectorPosicion = meta.position;
		mover = true;
		banderaRedireccionamiento = false;
		personaje = GetComponent<UnidadStats>();
	}
	
	// Update is called once per frame
	void Update () {
		vectorPosicion = meta.position;
		if(this.name != "Castillo Rojo" && this.name != "Castillo Azul"){
			if ((meta.name == "Castillo Rojo" || meta.name == "Castillo Azul") && !banderaRedireccionamiento) {
				vectorPosicion = new Vector3 (transform.position.x, transform.position.y, meta.transform.position.z);
			} 

			if(banderaRedireccionamiento){
				vectorPosicion = meta.position;
			
			}

			if(mover)
			{
				transform.position = Vector3.MoveTowards (transform.position, vectorPosicion, personaje.movimiento * Time.deltaTime);		
				transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
				transform.LookAt(vectorPosicion);
				transform.Rotate (0,180f,0);
			}
		}
	}
}
