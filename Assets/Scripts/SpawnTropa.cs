using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTropa : MonoBehaviour {

	public GameObject unidad;
	public int cantidadUnidades;
	public Transform padre;
	public int valorMana;

	public ManaControlador mana;

	// Use this for initialization
	void Start () {
		seleccionarMana ();
		spawnearTropa ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spawnearTropa()
	{
		if(mana.valorMana >= valorMana)
		{
			for(int i = 0; i < cantidadUnidades; i++)
			{
				Vector3 posicionSpawn = this.transform.position;
				posicionSpawn.x += Random.value * (10 + 10) - 10;
				posicionSpawn.y = 0f;
				posicionSpawn.z += Random.value * (10 + 10) - 10;
				GameObject instancia = (GameObject) Instantiate (unidad, posicionSpawn, this.transform.rotation, padre);
			}

			mana.consumirMana (valorMana);

		}

	}

	private void seleccionarMana()
	{
		string miTipo = this.gameObject.tag;
		switch(miTipo){
		case "UnidadRoja":
			mana = GameObject.Find ("ManaRojo").GetComponent<ManaControlador>();
			break;
		case "UnidadAzul":
			mana = GameObject.Find ("ManaAzul").GetComponent<ManaControlador>();
			break;
		}

	}
}
