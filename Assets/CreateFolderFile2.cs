using UnityEngine;
using System.Collections;
using System.IO;
 
public class CreateFolderFile2 : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		string filePath1 = Application.dataPath + @"\Scripts\File\data4.txt";
		FileStream file = null;

		try
		{
			file = File.Open(filePath1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		}
		catch (IOException e)
		{
			Debug.Log(e.Message);
		}
		finally
		{
			if (file != null)
			{
				try
				{
					file.Dispose();
				}
				catch (IOException e2)
				{
					Debug.Log(e2.Message);
				}
			}
		}
	}
}