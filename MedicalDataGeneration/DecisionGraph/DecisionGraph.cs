using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace MedicalDataGeneration.DecisionGraphs {

	public class DecisionGraph {

		private List<Node> Nodes;
		private List<GraphVariable> Variables;
		private List<string> Disorders;
		private List<string> Paths;

		private Random Random;

		public DecisionGraph ( string p_graphFile, string p_outputFile, int p_numLines, long p_seed = 1234 ) {
			Nodes = new List<Node> ( );
			Variables = new List<GraphVariable> ( );
			Disorders = new List<string> ( );
			Paths = new List<string> ( );

			Random = new Random ( p_seed );

			LoadDecisionGraphXML ( p_graphFile );
			GenerateRandomData ( p_outputFile, p_numLines );
		}

		public void GenerateRandomData ( string p_outpath, int p_numLines ) {
			FileStream fs = new FileStream ( p_outpath + "data.csv", FileMode.Create );

			List<List<Tuple<int, int>>> paths = TraverseAllPaths ( Nodes [ 0 ] );
			Dictionary<int, int> pathDictionary = new Dictionary<int, int> ( );

			using ( StreamWriter sw = new StreamWriter ( fs ) ) {
				sw.WriteLine ( Person.Header ( ) );

				for ( int i = 0; i < p_numLines; i++ ) {
					int next = Random.Next ( 0, paths.Count );

					sw.WriteLine ( GeneratePersonFollowBranch ( paths [ next ] ).ToCSV ( ) );

					if ( pathDictionary.ContainsKey ( next ) ) {
						pathDictionary [ next ]++;
					} else {
						pathDictionary.Add ( next, 1 );
					}
				}
			}

			fs = new FileStream ( p_outpath + "key.out", FileMode.Create );
			using ( StreamWriter sw = new StreamWriter ( fs ) ) {
				sw.WriteLine ( "Keys:" );

				foreach ( KeyValuePair<int, int> path in pathDictionary ) {
					sw.WriteLine ( Paths [ path.Key ] + " " + path.Value );
				}
			}
		}

		private Person GeneratePersonFollowBranch ( List<Tuple<int, int>> p_branch ) {
			Person person = new Person ( Random );

			int i = 0;
			for ( ; i < p_branch.Count; i++ ) {
				Node next = Nodes [ p_branch [ i ].Item1 ];
				if ( p_branch [ i + 1 ].Item1 < 0 ) {
					break; // Allow or deny state
				}

				Transition trans = next.GetTransitionWithDestinationIdAndTransitionIndex ( p_branch [ i + 1 ].Item1, p_branch [ i + 1 ].Item2 );
				switch ( trans.GetComparator ( ) ) {
					case eTransitionComparisons.COMPARE_AGE:
						trans.CreateAgeFromConditions ( ref person, Random );
						break;
					case eTransitionComparisons.COMPARE_DISORDERS:
						trans.CreateDisordersFromConditions ( ref person );
						break;
					case eTransitionComparisons.COMPARE_BLOOD_PRESSURE:
						break;
					case eTransitionComparisons.COMPARE_GENDER:
						break;
					case eTransitionComparisons.COMPARE_RISK_FACTORS_DRINK:
						break;
					case eTransitionComparisons.COMPARE_RISK_FACTORS_SMOKE:
						break;
					default:
						continue;
				}
			}

			return person;
		}

		private void LoadDecisionGraphXML ( string p_file ) {
			XElement myXML = XElement.Parse ( File.ReadAllText ( p_file ) );

			foreach ( XElement element in myXML.Element ( "disorders" ).Elements ( ) ) {
				Disorders.Add ( element.Value );
			}

			if ( myXML.Element ( "variables" ) != null ) {
				foreach ( XElement element in myXML.Element ( "variables" ).Elements ( ) ) {
					Variables.Add ( new GraphVariable ( element.Attribute ( "name" ).Value,
						element.Attribute ( "value" ).Value ) );
				}
			}

			foreach ( XElement element in myXML.Element ( "graph" ).Elements ( ) ) {
				foreach ( XElement node in element.Elements ( "node" ) ) {
					Node n = new Node ( int.Parse ( node.Attribute ( "id" ).Value ) );
					foreach ( XElement transition in node.Elements ( "transition" ) ) {
						Transition t = new Transition ( int.Parse ( transition.Attribute ( "index" ).Value ),
							               int.Parse ( transition.Attribute ( "to" ).Value ),
							               Transition.StringToTransitionComparison ( transition.Attribute ( "compare" ).Value ),
							               transition.Attribute ( "condition" ).Value );
						n.AddTransition ( t );
					}

					n.Transitions.Sort ( );
					Nodes.Add ( n );
				}
			}

			Nodes.Sort ( ); // Sorted by Id

			Nodes.Add ( new Node ( -1 ) ); // Deny state
			Nodes.Add ( new Node ( -2 ) ); // Allow state
		}

		private List<List<Tuple<int, int>>> TraverseAllPaths ( Node p_root ) {
			List<string> paths = new List<string> ( );

			Queue<Tuple<string, Node>> q = new Queue<Tuple<string, Node>> ( );
			q.Enqueue ( new Tuple<string, Node> ( p_root.Id.ToString ( ) + ",-3", p_root ) );

			while ( q.Count > 0 ) {
				Tuple<string, Node> node = q.Dequeue ( );
				if ( node.Item2.Transitions.Count > 0 ) {
					foreach ( Tuple<Node, Transition> myNode in GetNodesWithTransitionsFrom ( node.Item2 ) ) {
						q.Enqueue ( new Tuple<string, Node> ( node.Item1 + "_" + myNode.Item1.Id.ToString ( ) + "," + myNode.Item2.GetIndex ( ), myNode.Item1 ) );
					}
				} else {
					paths.Add ( node.Item1 );
				}
			}

			paths = paths.Distinct ( ).ToList ( );

			List<List<Tuple<int, int>>> intPaths = new List<List<Tuple<int, int>>> ( );
			foreach ( string str in paths ) {
				string[ ] tokens = str.Split ( '_' );
				List<Tuple<int, int>> p = new List<Tuple<int, int>> ( );

				Console.WriteLine ( str );
				Paths.Add ( str );

				foreach ( string token in tokens ) {
					string[ ] nodeTrans = token.Split ( ',' );
					p.Add ( new Tuple<int, int> ( int.Parse ( nodeTrans [ 0 ] ), int.Parse ( nodeTrans [ 1 ] ) ) );
				}

				intPaths.Add ( p );
			}

			return intPaths;
		}

		private List<Tuple<Node,Transition>> GetNodesWithTransitionsFrom ( Node p_node ) {
			List<Tuple<Node, Transition>> myNodes = new List<Tuple<Node, Transition>> ( );
			for ( int j = 0; j < p_node.Transitions.Count; j++ ) {
				if ( p_node [ j ].GetTo ( ) == -1 ) {
					myNodes.Add ( new Tuple<Node, Transition> ( Nodes [ Nodes.Count - 2 ], p_node.Transitions [ j ] ) );
				} else if ( p_node [ j ].GetTo ( ) == -2 ) {
						myNodes.Add ( new Tuple<Node, Transition> ( Nodes [ Nodes.Count - 1 ], p_node.Transitions [ j ] ) );
					} else {
						myNodes.Add ( new Tuple<Node, Transition> ( Nodes [ p_node [ j ].GetTo ( ) ], p_node.Transitions [ j ] ) );
					}
			}

			return myNodes;
		}
	}
}

