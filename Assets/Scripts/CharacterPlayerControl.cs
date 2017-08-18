using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayerControl : MonoBehaviour {


    Character character;

	// Use this for initialization
	void Start () {
        character = GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            character.Attack();
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            character.SwitchRiding();
        }

        float hacc = Input.GetAxis("Horizontal");
        float vacc = Input.GetAxis("Vertical");

        character.Move(hacc, vacc);
    }
}
