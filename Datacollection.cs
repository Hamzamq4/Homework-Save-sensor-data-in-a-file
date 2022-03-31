using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Datacollection : MonoBehaviour
{
    string filename = "";
    [System.Serializable]
    public class Data
    {
        public float x;
        public float y;
        public float z;
    }
    [System.Serializable]
    public class DataFold
    {
        public Data[] sensor;
    }

    public DataFold newDataFold = new DataFold();
    public bool Activated = false;

    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "/Data.csv";
        TextWriter tw = new StreamWriter(filename, false);
        tw.WriteLine("x,y,z");
        tw.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (Activated == true)
        {
            WriteToCSV();
        }

    }

    public void OnTrigger()
    {
        if (Activated == true)
        {
            Activated = false;
        }
        else if (Activated == false)
        {
            Activated = true;

        }
    }
    public void WriteToCSV()
    {
        if (newDataFold.sensor.Length > 0)
        {
            TextWriter tw = new StreamWriter(filename, true);
            tw.Close();

            tw = new StreamWriter(filename, true);



            for (int i = 0; i < newDataFold.sensor.Length; i++)
            {
    
                newDataFold.sensor[i].x = Input.acceleration.x;
                newDataFold.sensor[i].y = Input.acceleration.y;
                newDataFold.sensor[i].z = Input.acceleration.z;
                tw.WriteLine(newDataFold.sensor[i].x + "," + newDataFold.sensor[i].y + "," + newDataFold.sensor[i].z);


            }
            tw.Close();

            Debug.Log("Should be working, hopefully");

        }
        
    }
}
