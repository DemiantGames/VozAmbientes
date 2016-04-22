using UnityEngine;
using System.Collections;

public class Voz : MonoBehaviour {
	private FMOD.Studio.EventInstance voz;
	private FMOD.Studio.ParameterInstance Reverb;
	private FMOD.Studio.ParameterInstance Calle;
	private FMOD.Studio.ParameterInstance Library;
	private FMOD.Studio.ParameterInstance Lluvia;
	private FMOD.Studio.ParameterInstance Muro;
	// Use this for initialization
	private bool oprimido=false;

	private bool oreverb = false, ocalle=false, olibrary=false, olluvia=false, omuro=false;
	 


	void Start () {
	voz = FMODUnity.RuntimeManager.CreateInstance ("event:/Vozhumana");
		voz.getParameter ("Reverb", out Reverb);
		voz.getParameter ("Calle", out Calle);
		voz.getParameter ("Muro", out Muro);
		voz.getParameter ("Library", out Library);
		voz.getParameter ("Lluvia", out Lluvia);
	}
	
	// Update is called once per frame
	public void voice(){
		if (!oprimido) {
			voz.start();
			oprimido=true;

		} else {
			
			voz.stop (FMOD.Studio.STOP_MODE.IMMEDIATE);
			oprimido=false;

		}
	}

	public void lluvia(){
		
		if (!olluvia) {

			olluvia=true;
			voz.setParameterValue ("Lluvia", 1);

		} else {


			olluvia = false;
			voz.setParameterValue ("Lluvia", 0);
		}

	}

	public void biblioteca(){
		if (!olibrary) {

			olibrary=true;
			voz.setParameterValue ("Library", 1);

		} else {


			olibrary = false;
			voz.setParameterValue ("Library", 0);
		}
		
	}



	public void reverb(){
		if (!oreverb) {

			oreverb=true;
			voz.setParameterValue ("Reverb", 1);

		} else {


			oreverb = false;
			voz.setParameterValue ("Reverb", 0);
		}

	}
	public void calle(){

		if (!ocalle) {

			ocalle=true;
			voz.setParameterValue ("Calle", 1);

		} else {


			ocalle = false;
			voz.setParameterValue ("Calle", 0);
		}

	}


	public void muro(){

		if (!omuro) {

			omuro=true;
			voz.setParameterValue ("Muro", 1);

		} else {


			omuro = false;
			voz.setParameterValue ("Muro", 0);
		}

	}

}
