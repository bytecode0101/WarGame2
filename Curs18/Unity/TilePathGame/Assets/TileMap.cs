using UnityEngine;
using System.Collections.Generic;

public class TileMap : MonoBehaviour {

	public GameObject selectedUnit;

	public TileType[] tileTypes;

	int[,] tiles;
	Node[,] graph;


	int mapSizeX = 10;
	int mapSizeZ = 10;

	void Start() {
		// Setup the selectedUnit's variable
		selectedUnit.GetComponent<Unit>().tileX = (int)selectedUnit.transform.position.x;
		selectedUnit.GetComponent<Unit>().tileZ = (int)selectedUnit.transform.position.y;
		selectedUnit.GetComponent<Unit>().map = this;

		GenerateMapData();
		GeneratePathfindingGraph();
		GenerateMapVisual();
	}

	void GenerateMapData() {
		// Allocate our map tiles
		tiles = new int[mapSizeX,mapSizeZ];
		
		int x,z;
		
		// Initialize our map tiles to be grass
		for(x=0; x < mapSizeX; x++) {
			for(z=0; z < mapSizeX; z++) {
				tiles[x,z] = 0;
			}
		}

		// Make a swamp area
		//for(x=3; x <= 5; x++) {
		//	for(y=0; y < 4; y++) {
		//		tiles[x,y] = 1;
		//	}
		//}
		
		// Make a u-shaped mountain range
		//tiles[4, 4] = 2;
		//tiles[5, 4] = 2;
		//tiles[6, 4] = 2;
		//tiles[7, 4] = 2;
		//tiles[8, 4] = 2;

		//tiles[4, 5] = 2;
		//tiles[4, 6] = 2;
		//tiles[8, 5] = 2;
		//tiles[8, 6] = 2;

	}

	public float CostToEnterTile(int sourceX, int sourceY, int targetX, int targetY) {

		TileType tt = tileTypes[ tiles[targetX,targetY] ];

		if(UnitCanEnterTile(targetX, targetY) == false)
			return Mathf.Infinity;

		float cost = tt.movementCost;

		if( sourceX!=targetX && sourceY!=targetY) {
			// We are moving diagonally!
			// Prefer movin in straight lines, purely a cosmetic thing!
			cost += 0.001f;
		}

		return cost;

	}

	void GeneratePathfindingGraph() {
		// Initialize the array
		graph = new Node[mapSizeX,mapSizeZ];

		// Initialize a Node for each spot in the array
		for(int x=0; x < mapSizeX; x++) {
			for(int y=0; y < mapSizeX; y++) {
				graph[x,y] = new Node();
				graph[x,y].x = x;
				graph[x,y].y = y;
			}
		}

		// Now that all the nodes exist, calculate their neighbours
		for(int x=0; x < mapSizeX; x++) {
			for(int y=0; y < mapSizeX; y++) {

				// This is the 4-way connection version:
/*				if(x > 0)
					graph[x,y].neighbours.Add( graph[x-1, y] );
				if(x < mapSizeX-1)
					graph[x,y].neighbours.Add( graph[x+1, y] );
				if(y > 0)
					graph[x,y].neighbours.Add( graph[x, y-1] );
				if(y < mapSizeY-1)
					graph[x,y].neighbours.Add( graph[x, y+1] );
*/

				// This is the 8-way connection version (allows diagonal movement)
				// Try left
				if(x > 0) {
					graph[x,y].neighbours.Add( graph[x-1, y] );
					if(y > 0)
						graph[x,y].neighbours.Add( graph[x-1, y-1] );
					if(y < mapSizeZ-1)
						graph[x,y].neighbours.Add( graph[x-1, y+1] );
				}

				// Try Right
				if(x < mapSizeX-1) {
					graph[x,y].neighbours.Add( graph[x+1, y] );
					if(y > 0)
						graph[x,y].neighbours.Add( graph[x+1, y-1] );
					if(y < mapSizeZ-1)
						graph[x,y].neighbours.Add( graph[x+1, y+1] );
				}

				// Try straight up and down
				if(y > 0)
					graph[x,y].neighbours.Add( graph[x, y-1] );
				if(y < mapSizeZ-1)
					graph[x,y].neighbours.Add( graph[x, y+1] );

				// This also works with 6-way hexes and n-way variable areas
			}
		}
	}

	void GenerateMapVisual() {
		for(int x=0; x < mapSizeX; x++) {
			for(int z=0; z < mapSizeX; z++) {
				TileType tt = tileTypes[ tiles[x,z] ];
				GameObject go = (GameObject)Instantiate( tt.tileVisualPrefab, new Vector3(x, z, 0), Quaternion.identity );

				ClickableTile ct = go.GetComponent<ClickableTile>();
				ct.tileX = x;
				ct.tileY = z;
				ct.map = this;
			}
		}
	}

	public Vector3 TileCoordToWorldCoord(int x, int z) {
		return new Vector3(x, 0, z);
	}

	public bool UnitCanEnterTile(int x, int z) {

		// We could test the unit's walk/hover/fly type against various
		// terrain flags here to see if they are allowed to enter the tile.

		return tileTypes[ tiles[x,z] ].isWalkable;
	}

	public void GeneratePathTo(int x, int y) {
		// Clear out our unit's old path.
		selectedUnit.GetComponent<Unit>().currentPath = null;

		if( UnitCanEnterTile(x,y) == false ) {
			// If we clicked on a mountain or something, just quit out.
			return;
		}

		Dictionary<Node, float> dist = new Dictionary<Node, float>();
		Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

		// Setup the list of nodes we haven't checked yet.
		List<Node> unvisited = new List<Node>();
		
		Node source = graph[selectedUnit.GetComponent<Unit>().tileX, selectedUnit.GetComponent<Unit>().tileZ];
		
		Node target = graph[x, y];
		
		dist[source] = 0;
		prev[source] = null;

		// Initialize everything to have INFINITY distance, since
		// we don't know any better right now. Also, it's possible
		// that some nodes CAN'T be reached from the source,
		// which would make INFINITY a reasonable value
		foreach(Node v in graph) {
			if(v != source) {
				dist[v] = Mathf.Infinity;
				prev[v] = null;
			}

			unvisited.Add(v);
		}

		while(unvisited.Count > 0) {
			// "u" is going to be the unvisited node with the smallest distance.
			Node u = null;

			foreach(Node possibleU in unvisited) {
				if(u == null || dist[possibleU] < dist[u]) {
					u = possibleU;
				}
			}

			if(u == target) {
				break;	// Exit the while loop!
			}
			unvisited.Remove(u);

			foreach(Node v in u.neighbours) {
				//float alt = dist[u] + u.DistanceTo(v);
				float alt = dist[u] + CostToEnterTile(u.x, u.y, v.x, v.y);
				if( alt < dist[v] ) {
					dist[v] = alt;
					prev[v] = u;
				}
			}
		}

		// If we get there, the either we found the shortest route
		// to our target, or there is no route at ALL to our target.

		if(prev[target] == null) {
			// No route between our target and the source
			return;
		}

		List<Node> currentPath = new List<Node>();

		Node curr = target;

		// Step through the "prev" chain and add it to our path
		while(curr != null) {
			currentPath.Add(curr);
			curr = prev[curr];
		}

		// Right now, currentPath describes a route from out target to our source
		// So we need to invert it!

		currentPath.Reverse();

		selectedUnit.GetComponent<Unit>().currentPath = currentPath;
	}

}