using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour 
{
	[SerializeField] GameObject tileViewPrefab;
	[SerializeField] GameObject tileSelectionIndicatorPrefab;
	Transform _marker;
	Dictionary<Point, Tile> tiles = new Dictionary<Point, Tile>();

	[SerializeField] int width = 10;
    [SerializeField] int depth = 10;
    [SerializeField] int height = 8;

	[SerializeField] Point pos;

	[SerializeField] LevelData levelData;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	Transform marker
    {
      get
      {
        if (_marker == null)
        {
          GameObject instance = Instantiate(tileSelectionIndicatorPrefab) as GameObject;
          _marker = instance.transform;
        }
        return _marker;
      }
    }

	public void GrowArea()
    {
		Rect r = RandomRect();
		GrowRect(r);
    }

    public void ShrinkArea()
    {
		Rect r = RandomRect();
		ShrinkRect(r);
    }

	Rect RandomRect ()
    {
		int x = UnityEngine.Random.Range(0, width);
		int y = UnityEngine.Random.Range(0, depth);
		int w = UnityEngine.Random.Range(1, width - x + 1);
		int h = UnityEngine.Random.Range(1, depth - y + 1);
		return new Rect(x, y, w, h);
    }

	void GrowRect (Rect rect)
    {
		for (int y = (int)rect.yMin; y < (int)rect.yMax; ++y)
		{
			for (int x = (int)rect.xMin; x < (int)rect.xMax; ++x)
			{
				Point p = new Point(x, y);
				GrowSingle(p);
			}
		}
    }
    void ShrinkRect (Rect rect)
    {
		for (int y = (int)rect.yMin; y < (int)rect.yMax; ++y)
		{
			for (int x = (int)rect.xMin; x < (int)rect.xMax; ++x)
			{
				Point p = new Point(x, y);
				ShrinkSingle(p);
			}
		}
    }

	Tile Create ()
    {
		GameObject instance = Instantiate(tileViewPrefab) as GameObject;
		instance.transform.parent = transform;
		return instance.GetComponent<Tile>();
    }

    Tile GetOrCreate (Point p)
    {
		if (tiles.ContainsKey(p))
			return tiles[p];
		
		Tile t = Create();
		t.Load(p, 0);
		tiles.Add(p, t);
		
		return t;
    }
    
	void GrowSingle (Point p)
    {
		Tile t = GetOrCreate(p);
		if (t.height < height)
			t.Grow();
    }

	void ShrinkSingle (Point p)
    {
		if (!tiles.ContainsKey(p))
			return;
		
		Tile t = tiles[p];
		t.Shrink();
		
		if (t.height <= 0)
		{
			tiles.Remove(p);
			DestroyImmediate(t.gameObject);
		}
    }
}
