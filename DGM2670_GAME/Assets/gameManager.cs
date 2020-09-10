
using UnityEngine;

public class gameManager : MonoBehaviour
{
  private bool respawnComplete = false;
  
  public void Respawn ()
  {
    if (respawnComplete == false)
    {
      respawnComplete = true;
      Debug.Log("Try Again");
    }
  }
}
