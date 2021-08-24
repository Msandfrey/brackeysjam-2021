using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IndieWizards.GameManagement
{
    public class GameOverController : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            //restart game
            if (Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene(0); }
        }
}
}
