using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostrarGanador : MonoBehaviour {
	
	private TextMeshProUGUI Ganador;
	private ConocerGanador textGanador;

	void Start () {
		textGanador = GameObject.Find("Ganador").GetComponent<ConocerGanador>();
		Ganador = GetComponent <TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
		Ganador.text = textGanador.ganador;
	}
}
