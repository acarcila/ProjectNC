using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTropa : MonoBehaviour {

	public GameObject padre;
	public GameObject tropa;

	private DefaultTrackableEventHandler imageTarget;
	private bool estado;
	private bool bandera;

	// Use this for initialization
	void Start () {
		imageTarget = this.GetComponent<DefaultTrackableEventHandler> ();
		bandera = true;
	}
	
	// Update is called once per frame
	void Update () {
		actualizarEstado ();
		if(estado && bandera)
		{
			Debug.Log ("--------------------------------");
			GameObject unidad = Instantiate (tropa, this.transform.position, Quaternion.identity, padre.transform);
			unidad.GetComponent<MovimientoPersonaje> ().meta = GameObject.Find ("Sphere").transform;

			bandera = false;
		}
	}

	public void actualizarEstado()
	{
		estado = imageTarget.activo;

	}
}
