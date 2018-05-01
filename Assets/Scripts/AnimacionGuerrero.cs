using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionGuerrero : MonoBehaviour {

	public Animator anim;
	private MovimientoPersonaje personaje;
	private UnidadAtaque ataque;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		personaje = GetComponentInParent<MovimientoPersonaje> ();
		ataque = GetComponentInParent<UnidadAtaque> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(personaje.mover)
		{
			anim.Play ("Walk");
		}else if(ataque.atacar)
		{
			anim.Play ("Attack");
		}else{
			anim.Play ("Idle");
		}
	}
}
