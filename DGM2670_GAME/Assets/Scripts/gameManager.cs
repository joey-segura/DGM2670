using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  private bool respawnComplete = false;
  public float restartDelay = 1f;
  
  public void Respawn ()
  {
    if (respawnComplete == false)
    {
      respawnComplete = true;
      Debug.Log("Try Again");
      Invoke("Restart", restartDelay);
    }
  }

  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
