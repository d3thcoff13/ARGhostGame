using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    enum GhostType {WHITE,RED,GREEN};
    [SerializeField]
    GhostType type;
    [SerializeField]
    int value;
    Manager manager;
    bool lit;
    float changeDir;
    int dir;
    flashlighht ligght;
    MeshRenderer renderer;
    RaycastHit hit;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {

        ligght = GameObject.Find("flashlight").transform.GetChild(0).GetComponent<flashlighht>();
        renderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        mat = renderer.material;
        mat.GetColor("_Color");
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        if (this.type == GhostType.GREEN)
        {
            dir = -1;
            changeDir = Time.time + 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ligght.on)
        {
            hit = ligght.getHit();
            //Debug.Log(hit.collider);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == this.gameObject && mat.GetColor("_Color").a > 0) mat.SetColor("_Color", new Color(mat.GetColor("_Color").r, mat.GetColor("_Color").g, mat.GetColor("_Color").b, mat.GetColor("_Color").a - 1 * Time.deltaTime));//this.transform.gameObject.SetActive(false);
                if (mat.GetColor("_Color").a <= 0)
                {
                    this.gameObject.SetActive(false);
                    manager.score += value;
                    manager.ghostCount--;
                }
                //Debug.Log(mat.GetColor("_Color"));
            }
        }

        Ghost_Move(this.type);
    }

    public void isLit() {
        this.lit = !lit;
    }

    void Ghost_Move(GhostType color)
    {
        switch (color)
        {
            case GhostType.RED:
                transform.position += transform.forward * Time.deltaTime * 1;
                if (transform.position.x > manager.xMax) transform.position = new Vector3(manager.xMin, transform.position.y, transform.position.z);
                else if (transform.position.x < manager.xMin) transform.position = new Vector3(manager.xMax, transform.position.y, transform.position.z);
                
                if (transform.position.y > manager.yMax) transform.position = new Vector3(transform.position.x, manager.yMin, transform.position.z);
                else if (transform.position.y < manager.yMin) transform.position = new Vector3(transform.position.x, manager.yMax, transform.position.z);
                
                if (transform.position.z > manager.zMax) transform.position = new Vector3(transform.position.x, transform.position.y, manager.zMin);
                else if (transform.position.z < manager.zMin) transform.position = new Vector3(transform.position.x, transform.position.y, manager.zMax);
                break;
            case GhostType.GREEN:
                transform.position += transform.forward * Time.deltaTime * 2;
                if (Time.time > changeDir)
                {
                    changeDir = Time.time + 2;
                    if(dir == -1) dir = 1;
                    else if (dir == 1) dir = -1;
                }
                if (dir == 1)
                {
                    transform.position += transform.up * Time.deltaTime * 1;
                }else transform.position -= transform.up * Time.deltaTime * 1;

                if (transform.position.x > manager.xMax) transform.Rotate(0, (int)(90 + transform.rotation.y), 0, Space.Self);
                else if (transform.position.x < manager.xMin) transform.Rotate(0, (int)(90 + transform.rotation.y), 0, Space.Self);

                if (transform.position.y > manager.yMax) transform.Rotate((int)(90 + transform.rotation.x), 0, 0, Space.Self);
                else if (transform.position.y < manager.yMin) transform.Rotate((int)(90 + transform.rotation.x), 0, 0, Space.Self);

                if (transform.position.z > manager.zMax) transform.Rotate(0, (int)(90 + transform.rotation.y), 0, Space.Self);
                else if (transform.position.z < manager.zMin) transform.Rotate(0, (int)(90 + transform.rotation.y), 0, Space.Self);



                if (transform.position.x > manager.xMax) transform.position = new Vector3(manager.xMax, transform.position.y, transform.position.z);
                else if (transform.position.x < manager.xMin) transform.position = new Vector3(manager.xMin, transform.position.y, transform.position.z);

                if (transform.position.y > manager.yMax) transform.position = new Vector3(transform.position.x, manager.yMax, transform.position.z);
                else if (transform.position.y < manager.yMin) transform.position = new Vector3(transform.position.x, manager.yMin, transform.position.z);

                if (transform.position.z > manager.zMax) transform.position = new Vector3(transform.position.x, transform.position.y, manager.zMax);
                else if (transform.position.z < manager.zMin) transform.position = new Vector3(transform.position.x, transform.position.y, manager.zMin);
                break;
            case GhostType.WHITE:
                transform.position += transform.forward * Time.deltaTime * 2;
                if (transform.position.x > manager.xMax) transform.Rotate(0, (int)(90 + transform.rotation.y), 0, Space.Self);
                else if (transform.position.x < manager.xMin) transform.Rotate(0, (int)(90 + transform.rotation.y), 0, Space.Self);

                if (transform.position.y > manager.yMax) transform.Rotate((int)(90+transform.rotation.x), 0, 0, Space.Self);
                else if (transform.position.y < manager.yMin) transform.Rotate((int)(90 + transform.rotation.x), 0, 0, Space.Self);

                if (transform.position.z > manager.zMax) transform.Rotate(0, (int)(90 + transform.rotation.y), 0, Space.Self);
                else if (transform.position.z < manager.zMin) transform.Rotate(0, (int)(90 + transform.rotation.y), 0, Space.Self);



                if (transform.position.x > manager.xMax) transform.position = new Vector3(manager.xMax, transform.position.y, transform.position.z);
                else if (transform.position.x < manager.xMin) transform.position = new Vector3(manager.xMin, transform.position.y, transform.position.z);

                if (transform.position.y > manager.yMax) transform.position = new Vector3(transform.position.x, manager.yMax, transform.position.z);
                else if (transform.position.y < manager.yMin) transform.position = new Vector3(transform.position.x, manager.yMin, transform.position.z);

                if (transform.position.z > manager.zMax) transform.position = new Vector3(transform.position.x, transform.position.y, manager.zMax);
                else if (transform.position.z < manager.zMin) transform.position = new Vector3(transform.position.x, transform.position.y, manager.zMin);

                break;
        }
    }
}
