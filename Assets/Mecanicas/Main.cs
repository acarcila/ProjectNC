using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	private UnidadStats castilloRojo, castilloAzul;
	private TiempoControlador tiempo;
	private ConocerGanador ganador;

	void Start () {
		castilloRojo = GameObject.Find("Castillo Rojo").GetComponent<UnidadStats>();
		castilloAzul = GameObject.Find("Castillo Azul").GetComponent<UnidadStats>();
		ganador = GameObject.Find("Ganador").GetComponent<ConocerGanador>();
		tiempo = GameObject.Find("Time").GetComponent<TiempoControlador>();
	}
		
	// Update is called once per frame
	void Update () {
		if(tiempo.tiempo <= 0 || castilloRojo.vida <= 0 || castilloAzul.vida <= 0){
			ganador.bandera = true;
			ganador.ganador = "El ganador es el jugador " + compararVida ();
			cambiarPantalla();
		}
	}

	public string compararVida(){
		string ganador = "";
		if(castilloRojo.vida > castilloAzul.vida){
			 ganador = "Rojo";
		}else if(castilloRojo.vida < castilloAzul.vida){
			 ganador = "Azul";
		}
		return ganador;
	}

	public void cambiarPantalla(){
		SceneManager.LoadScene ("Fin");
	}
}
