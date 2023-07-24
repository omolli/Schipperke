using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectile : MonoBehaviour
{
  private Vector3 projectileDir;

  public void Setup(Vector3 projectileDir) {
    this.projectileDir = projectileDir;
    transform.right = projectileDir;
    Destroy(gameObject,5f);
  }

  private void Update() {
    float proSpeed = 100f;
    transform.position = projectileDir * proSpeed * Time.deltaTime;
  }

}
