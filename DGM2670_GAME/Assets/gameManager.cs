
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
  private bool respawnComplete = false;
  public float restartDelay = 1f;
  
  void KnockOut()
  {
   
  }
  
  public void Respawn ()
  {
    if (respawnComplete == false)
    {
      respawnComplete = true;
      Debug.Log("Try Again");
      Invoke("Restart", restartDelay);
    }
  }
}
