/*
 * Gestion camera style RTS
 */
using UnityEngine;

public class CameraController : MonoBehaviour {

    private bool doMouvement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 4f;
    public float minY = 10f;
    public float maxY = 80f;
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMouvement = !doMouvement;
        } 

        if (!doMouvement)
            return;
        if (Input.GetKey("z"))// || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))// || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))// || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("q"))// || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        //scroll wheel

        float scroll = Input.GetAxis("Mouse ScrollWheel");// récupère la valeur de rotation de la roue
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;//modifie la position en y(zoom), la valeur de scroll étant très faible on rajoute un facteur multiplicateur 1000
        pos.y = Mathf.Clamp(pos.y, minY, maxY);// restraint la nouvelle valeur du zoom
        //application de la modification
        transform.position = pos;

	}
}

//Vector3.forward == new Vector3 (0f,0f,1f)
// multiplier par Time.deltaTime permet d'être sur que notre mouvement ne dépend pas du framerate
/* la camera a subis une rotation pour voir la zone en diagonal, du coup l'axe des x regarde la zone
 * si on utilise cette axe pour se déplacer on va zoomer et non avancer. L'utilisation de Space.world permet d'utiliser les
 * variable global de unity.
 */
//Mouseposition default value : en bas a gauche la position en coordonnée est de (0,0)