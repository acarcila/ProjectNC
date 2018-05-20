using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTropa : MonoBehaviour {

	public GameObject unidad;
	public int cantidadUnidades;
	public Transform padre;
	public int valorMana;
	public ManaControlador mana;

	private DefaultTrackableEventHandler marcador;
	private bool banderaSpawn;
	private float scaleX;
	private float scaleZ;

	// Use this for initialization
	void Start () {
		seleccionarMana ();
		banderaSpawn = true;
		marcador = GetComponentInParent<DefaultTrackableEventHandler> ();

		scaleX = transform.localScale.x;
		scaleZ = transform.localScale.z;

	}
	
	// Update is called once per frame
	void Update () {
		if(marcador.activo && banderaSpawn)
		{
			spawnearTropa ();
			banderaSpawn = false;
		}

		if(!marcador.activo)
		{
			banderaSpawn = true;
		}

		transform.SetPositionAndRotation (new Vector3(transform.position.x, 0.1f, transform.position.z), transform.rotation);
	}

	public void spawnearTropa()
	{
		if(mana.valorMana >= valorMana)
		{
			for(int i = 0; i < cantidadUnidades; i++)
			{
				Vector3 posicionSpawn = this.transform.position;
				posicionSpawn.x += Random.value * ((10*scaleX) + (10*scaleX)) - (10*scaleX);
				posicionSpawn.y = 0f;
				posicionSpawn.z += Random.value * ((10*scaleZ) + (10*scaleZ)) - (10*scaleZ);
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

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Terreno")
		{
//			spawnearTropa ();

		}

		Debug.Log(other.gameObject.name);
	}

	void OnTriggerStay(Collider other)
	{
		if(other.name == "Terreno")
		{
			//			spawnearTropa ();

		}

		Debug.Log(other.gameObject.name);
	}

	void OnTriggerExit(Collider other)
	{
		if(other.name == "Terreno")
		{
			//			spawnearTropa ();

		}

		Debug.Log(other.gameObject.name);
	}
}
