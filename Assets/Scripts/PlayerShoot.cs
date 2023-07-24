using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
  AudioSource fxSound;
  public AudioClip jumpAudio;
  private bool isShooting;
  private Transform theProjectile;
  private float shootDelay = 1f;

  void Start()
  {
    fxSound = GetComponent<AudioSource> ();
    fxSound.clip = jumpAudio;
  }
  private void Awake() {
    // GetComponent<whichdirection> = ???
  }
  private void Update(){
    float dirX = Input.GetAxis("Horizontal");
    Vector3 playerDir = new Vector3(dirX,0, 0);
    if (Input.GetKey(KeyCode.S) && !isShooting) {
      isShooting = true;
      //rb2d.AddForce(new Vector2(0,bulletSpeed),ForceMode2D.Impulse);

      Transform projectileTransform = Instantiate(theProjectile);
      Vector3 projectileDir = playerDir;
      projectileTransform.GetComponent<playerProjectile>().Setup(projectileDir);
      fxSound.Play();
      Invoke("ResetShot",shootDelay);
  }
  // private void PlayerShootProjectile(){
  //   Tranform projectileTransform = Instantiate(theProjectile);
  //   Vector3 projectileDir = playerDir;
  //   projectileTransform.GetComponent<Projectile>().Setup(projectileDir);
  // }


  }
  void ResetShot()
  {
    isShooting = false;
  }
}
