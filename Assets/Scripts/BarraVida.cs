using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour {
	
	private UnidadStats stats;
	private Image imagenBarraVida;
	private float vidaInicial;
	private int vida;
	private GameObject camara;


	// Use this for initialization
	void Start () {
		stats = GetComponentInParent<UnidadStats> ();
		imagenBarraVida = transform.GetChild (0).GetChild (0).GetComponent<Image>();
		vidaInicial = stats.vida;

		camara = GameObject.FindWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		actualizarBarraVida ();
		mirarHaciaCamara ();
	}

	public void actualizarBarraVida(){
		imagenBarraVida.fillAmount = stats.vida / vidaInicial;
	}

	public void mirarHaciaCamara()
	{
		Vector3 posicionCamara = camara.transform.position;
		this.transform.LookAt (posicionCamara);
	}
}
