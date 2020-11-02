using UnityEngine;

using SBO = StringBuilderOperator.StringBuilderOperator;

/// <summary>
/// TestCode
/// </summary>

public class TestScript : MonoBehaviour
{
	bool flag = true;
	TextMesh txt;

	void Start()
	{
		txt = GetComponent<TextMesh>();
	}

	void Update()
	{
		if( Input.GetMouseButtonDown( 0 ) )
		{
			flag = !flag;
		}
		int data = 1;
		string s;
		float t = Time.realtimeSinceStartup;
		if( flag )
		{
			s = UpdateSbtOn( data );
		}
		else
		{
			s = UpdateSbtOff( data );
		}
		t = Time.realtimeSinceStartup - t;
		//Debug.Log( s );

		this.txt.text = SBO.i + "SBO flag " + flag + "\n" + "Time:" + t;
	}

	string UpdateSbtOn( int data )
	{
		/*
		// string型のままループ連結すると毎回sb.ToString()されるので速くならない
		string s = SBO.i + "Test";
		for( int i = 0 ; i < 2000 ; ++i )
		{
			s = SBO.i + s + " " + data + " " + data;
			data++;
		}
		return s;
		*/

		// SBO型で保持して複数行の結合を行えば速い
		SBO s = SBO.i + "Test";
		for( int i = 0 ; i < 2000 ; ++i )
		{
			s = s + " " + data + " " + data;
			data++;
		}
		return s.ToString();
	}

	string UpdateSbtOff( int data )
	{
		var s = "Test";
		for( int i = 0 ; i < 2000 ; ++i )
		{
			s = s + " " + data + " " + data;
			data++;
		}
		return s;
	}
}
