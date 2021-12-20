using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DatenightTitlescene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Updating");
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Date Night diner scene", LoadSceneMode.Single);

        }
    }
}
