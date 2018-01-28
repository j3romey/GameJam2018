using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteSnapping : MonoBehaviour {

    public string filename;

    List<int> list1;
    List<float> list2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){
            Read(filename);
        }	
	}

    public void Read(string filename)
    {
        list1 = new List<int>();
        list2 = new List<float>();

        using (TextReader reader = File.OpenText("Assets/" + filename + ".txt"))
        {
            string[] input;
            string cur;

            float curFloat;
            while ((cur = reader.ReadLine()) != null)
            {

                if (cur == "") break;

                input = cur.Split(' ');
                list1.Add(int.Parse(input[0]));
                curFloat = float.Parse(input[1]);

                Debug.Log( Mathf.Round(curFloat / (60f/2/124)) * (60f/2/124));

            }
        }
    }
}
