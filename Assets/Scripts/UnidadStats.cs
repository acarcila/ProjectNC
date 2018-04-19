using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnidadStats : MonoBehaviour {

	public char tipo;
	public int vida;
	public int daño;
	public int movimiento;
	public int rango;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(vida < 0)
		{
			muerte();
		}
	}

	public void muerte(){
		Destroy (this.gameObject);
	
	}
}
