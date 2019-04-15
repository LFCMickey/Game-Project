using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonRay : MonoBehaviour
{
    public GameObject UI; 
    public GameObject playerObject;
    private GameObject Door;
    private GameObject SmallBug;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ray.origin = playerObject.transform.position;
            bool hit = Physics.Raycast(ray, out hitInfo, range);
            GameObject _target = hitInfo.transform.gameObject;
            if (_target != null)
              //  Debug.Log(_target);
                
            if (_target.tag == "Door")
            {
                Door = _target;
                OpenDoor OpenDoor = Door.GetComponent<OpenDoor>();
                OpenDoor.DoorOpen();
            }
            if (_target.tag == "SmallBug")
            {
                SmallBug = _target;
                Mount PMount = playerObject.GetComponent<Mount>();
                Mount BMount = _target.GetComponent<Mount>();
                PMount.mount(_target, playerObject);
                BMount.mount(_target, playerObject);

            }
            if (_target.tag == "PickUp")
            {
                
                UIManager IUE = UI.GetComponent<UIManager>();
               
                if (_target.name.Contains ("Ball"))
                {
                    //IUE.Inventory[1] = _target.name;
                    IUE.Amount[0] += 1;
                }
                if (_target.name == "TeddyBear")
                {
                    IUE.Amount[1] += 1;
                }
                DestroyImmediate(_target);
            }
        }

    }
}
