
using UnityEngine;
using System.Collections;



public class example : MonoBehaviour {
	private FMOD.Studio.EventInstance velnave;
	private FMOD.Studio.EventInstance giro;
	private FMOD.Studio.EventInstance Bass;
	private FMOD.Studio.EventInstance Laser;
	private FMOD.Studio.EventInstance MusicLenta;
	private FMOD.Studio.EventInstance MusicMedia;
	private FMOD.Studio.EventInstance MusicRapida;
	private FMOD.Studio.ParameterInstance pitch;



	private float maxSpeed = 10;
	public float current_speed=0;

	void Start()
	{

		velnave = FMODUnity.RuntimeManager.CreateInstance ("event:/Movimiento Spaceship");
		giro = FMODUnity.RuntimeManager.CreateInstance ("event:/Spaceship_Takeoff-Richard-902554369");
		Bass = FMODUnity.RuntimeManager.CreateInstance ("event:/Bass Spaceship");
		Laser = FMODUnity.RuntimeManager.CreateInstance ("event:/Laser");
		MusicLenta=FMODUnity.RuntimeManager.CreateInstance ("event:/Music");
		MusicMedia=FMODUnity.RuntimeManager.CreateInstance ("event:/Music3");
		MusicRapida=FMODUnity.RuntimeManager.CreateInstance ("event:/Music4");


		MusicLenta.start ();
		MusicMedia.start ();
		MusicRapida.start ();
		Bass.start ();
		velnave.start();
		velnave.getParameter ("Parameter 1", out pitch);
	}
	void Update()
	{
		if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && (current_speed < maxSpeed)) {
			current_speed += 1; 
		} else if ((Input.GetKeyDown("down") || Input.GetKeyDown("s"))  && (current_speed > 0)) {
			current_speed -= 1; 
		}

		if (current_speed <= 4) {
			MusicLenta.setPaused (false);
			MusicRapida.setPaused (true);
			MusicMedia.setPaused (true);

		} else if (current_speed > 4 && current_speed <= 7) {
			MusicRapida.setPaused (true);
			MusicLenta.setPaused (true);
			MusicMedia.setPaused (false);
		} else{
			MusicMedia.setPaused (true);
			MusicLenta.setPaused (true);
			MusicRapida.setPaused (false);
			MusicLenta.start ();
		}
		pitch.setValue(current_speed);


		if (Input.GetKeyDown("a") || Input.GetKeyDown ("d") || Input.GetKeyDown ("left") || Input.GetKeyDown ("right")) {
			giro.start ();
		} 

		if (Input.GetMouseButtonDown (0)) {
			Laser.start ();
		}

	}
}
