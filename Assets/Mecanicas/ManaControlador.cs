using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaControlador : MonoBehaviour {

	public int valorMana;

	private Image imagenBarraMana;
	private int valorManaMax;
	private int frameCount;
	private int frameMax;
	private TiempoControlador empezarMuerteSubita;

	// Use this for initialization
	void Start () {
		empezarMuerteSubita = GameObject.Find("Time").GetComponent<TiempoControlador>();
		frameCount = 0;
		frameMax = 15;
		valorManaMax = 100;
		valorMana = 40;
		imagenBarraMana = transform.GetChild (0).GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		actualizarBarraMana ();
		if(empezarMuerteSubita.muerteSubita){
			frameMax = 5;
		}
	}

	void FixedUpdate () {
		frameCount++;

		if(frameCount > frameMax)
		{
			if(valorMana < valorManaMax)
			{
				valorMana++;
			}
			frameCount = 0;
		}

	}

	public void consumirMana(int valorConsumido)
	{
		valorMana -= valorConsumido;
		actualizarBarraMana ();
	}

	public void actualizarBarraMana(){
		float porcentajeBarra = ((float)valorMana / (float)valorManaMax);
		imagenBarraMana.fillAmount = porcentajeBarra;
	}
}
