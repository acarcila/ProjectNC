using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaControlador : MonoBehaviour {

	private Image imagenBarraMana;
	private int valorManaMax;
	public int valorMana;

	private int frameCount = 0;
	private int frameMax = 15;

	// Use this for initialization
	void Start () {
		valorManaMax = 100;
		valorMana = 40;
		imagenBarraMana = transform.GetChild (0).GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		actualizarBarraMana ();
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
