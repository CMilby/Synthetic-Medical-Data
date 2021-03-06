﻿using System;
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

		public DecisionGraph ( string p_graphFile, long p_seed = 1234 ) {
			Nodes = new List<Node> ( );
			Variables = new List<GraphVariable> ( );
			Disorders = new List<string> ( );
			Paths = new List<string> ( );

			Random = new Random ( p_seed );

			LoadDecisionGraphXML ( p_graphFile );
		}

		public void GenerateRandomData ( string p_dataOut, string p_keyOut, int p_numLines ) {
			GenerateRandomData ( p_dataOut, p_keyOut, p_numLines, ePrintColumns.COLUMN_F_NAME,
					ePrintColumns.COLUMN_M_NAME, ePrintColumns.COLUMN_L_NAME, ePrintColumns.COLUMN_SEX,
					ePrintColumns.COLUMN_RACE, ePrintColumns.COLUMN_DOB, ePrintColumns.COLUMN_AGE,
					ePrintColumns.COLUMN_HEIGHT, ePrintColumns.COLUMN_WEIGHT, ePrintColumns.COLUMN_WEIGHT_PERCENTILE,
					ePrintColumns.COLUMN_PHONE, ePrintColumns.COLUMN_SSN, ePrintColumns.COLUMN_ADDRESS,
					ePrintColumns.COLUMN_TOWN, ePrintColumns.COLUMN_STATE, ePrintColumns.COLUMN_ZIP,
					ePrintColumns.COLUMN_SYSTOLIC, ePrintColumns.COLUMN_DIASTOLIC, ePrintColumns.COLUMN_RISK_FACTORS,
					ePrintColumns.COLUMN_DISORDERS );
		}

		public void GenerateRandomData ( string p_dataOut, string p_keyOut, int p_numLines, params ePrintColumns [ ] p_columns ) {
			FileStream fs = new FileStream ( p_dataOut, FileMode.Create );

			List<List<Tuple<int, int>>> paths = TraverseAllPaths ( Nodes [ 0 ] );
			Dictionary<int, int> pathDictionary = new Dictionary<int, int> ( );

			using ( StreamWriter sw = new StreamWriter ( fs ) ) {
				if ( p_columns.Contains ( ePrintColumns.COLUMN_INCREMENTAL_ID ) ) {
					sw.Write ( "Id," );
				}

				sw.WriteLine ( Person.Header ( p_columns ) );

				for ( int i = 0; i < p_numLines; i++ ) {
					int next = Random.Next ( 0, paths.Count - 1 );

					string line = GeneratePersonFollowBranch ( paths [ next ] ).ToCSV ( p_columns );
					if ( p_columns.Contains ( ePrintColumns.COLUMN_INCREMENTAL_ID ) ) {
						line = i.ToString ()  + "," + line;
					}

					sw.WriteLine ( line );

					if ( pathDictionary.ContainsKey ( next ) ) {
						pathDictionary [ next ]++;
					} else {
						pathDictionary.Add ( next, 1 );
					}
				}
			}

			fs = new FileStream ( p_keyOut, FileMode.Create );
			using ( StreamWriter sw = new StreamWriter ( fs ) ) {
				sw.WriteLine ( "Keys:" );

				foreach ( KeyValuePair<int, int> path in pathDictionary ) {
					sw.WriteLine ( Paths [ path.Key ] + " " + path.Value );
				}
			}
		}

		public void GenerateEachData ( string p_dataOut, string p_keyOut ) {
			GenerateEachData ( p_dataOut, p_keyOut, ePrintColumns.COLUMN_F_NAME,
					ePrintColumns.COLUMN_M_NAME, ePrintColumns.COLUMN_L_NAME, ePrintColumns.COLUMN_SEX,
					ePrintColumns.COLUMN_RACE, ePrintColumns.COLUMN_DOB, ePrintColumns.COLUMN_AGE,
					ePrintColumns.COLUMN_HEIGHT, ePrintColumns.COLUMN_WEIGHT, ePrintColumns.COLUMN_WEIGHT_PERCENTILE,
					ePrintColumns.COLUMN_PHONE, ePrintColumns.COLUMN_SSN, ePrintColumns.COLUMN_ADDRESS,
					ePrintColumns.COLUMN_TOWN, ePrintColumns.COLUMN_STATE, ePrintColumns.COLUMN_ZIP,
					ePrintColumns.COLUMN_SYSTOLIC, ePrintColumns.COLUMN_DIASTOLIC, ePrintColumns.COLUMN_RISK_FACTORS,
					ePrintColumns.COLUMN_DISORDERS );
		}

		public void GenerateEachData ( string p_dataOut, string p_keyOut, params ePrintColumns [ ] p_columns ) {
			FileStream fs = new FileStream ( p_dataOut, FileMode.Create );

			List<List<Tuple<int, int>>> paths = TraverseAllPaths ( Nodes [ 0 ] );
			Dictionary<int, int> pathDictionary = new Dictionary<int, int> ( );

			using ( StreamWriter sw = new StreamWriter ( fs ) ) {
				if ( p_columns.Contains ( ePrintColumns.COLUMN_INCREMENTAL_ID )  ) {
					sw.Write ( "Id," );
				}

				sw.WriteLine ( Person.Header ( p_columns ) );

				for ( int i = 0; i < paths.Count; i++ ) {
					string line = GeneratePersonFollowBranch ( paths [ i ] ).ToCSV ( p_columns );
					if ( p_columns.Contains ( ePrintColumns.COLUMN_INCREMENTAL_ID ) ) {
						line = i.ToString ( ) + "," + line;
					}
					sw.WriteLine ( line );

					if ( pathDictionary.ContainsKey ( i ) ) {
						pathDictionary [ i ]++;
					} else {
						pathDictionary.Add ( i, 1 );
					}
				}
			}

			fs = new FileStream ( p_keyOut, FileMode.Create );
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
			for (; i < p_branch.Count; i++ ) {
				Node next = Nodes [ p_branch [ i ].Item1 ];

				Transition trans = next.GetTransitionWithDestinationIdAndTransitionIndex ( p_branch [ i + 1 ].Item1, p_branch [ i + 1 ].Item2 );
				switch ( trans.GetComparator ( ) ) {
					case eTransitionComparisons.COMPARE_AGE:
						trans.CreateAgeFromConditions ( ref person, Random );
						break;
					case eTransitionComparisons.COMPARE_DISORDERS:
						trans.CreateDisordersFromConditions ( ref person );
						break;
					case eTransitionComparisons.COMPARE_BLOOD_PRESSURE:
						trans.CreateBloodPressureFromCondition ( ref person, Random );
						break;
					case eTransitionComparisons.COMPARE_GENDER:
						trans.CreateGenderFromCondition ( ref person );
						break;
					case eTransitionComparisons.COMPARE_RISK_FACTORS_DRINK:
						trans.CreateRiskFactorDrinkFromCondition ( ref person );
						break;
					case eTransitionComparisons.COMPARE_RISK_FACTORS_SMOKE:
						trans.CreateRiskFactorSmokeFromCondition ( ref person );
						break;
					case eTransitionComparisons.COMPARE_PREGNANT:
						trans.CreatePregnantFromCondition ( ref person );
						break;
					default:
						continue;
				}

				if ( p_branch [ i + 1 ].Item1 < 0 ) {
					break; // Allow, deny, or consult state
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
			Nodes.Add ( new Node ( -3 ) ); // Consult state
		}

		private List<List<Tuple<int, int>>> TraverseAllPaths ( Node p_root ) {
			List<string> paths = new List<string> ( );

			Queue<Tuple<string, Node>> q = new Queue<Tuple<string, Node>> ( );
			q.Enqueue ( new Tuple<string, Node> ( "-5," + p_root.Id.ToString ( ), p_root ) );

			while ( q.Count > 0 ) {
				Tuple<string, Node> node = q.Dequeue ( );
				if ( node.Item2.Transitions.Count > 0 ) {
					foreach ( Tuple<Node, Transition> myNode in GetNodesWithTransitionsFrom ( node.Item2 ) ) {
						q.Enqueue ( new Tuple<string, Node> ( node.Item1 + "|" + myNode.Item2.GetIndex ( ) + "," + myNode.Item1.Id.ToString ( ), myNode.Item1 ) );
					}
				} else {
					paths.Add ( node.Item1 );
				}
			}

			paths = paths.Distinct ( ).ToList ( );

			List<List<Tuple<int, int>>> intPaths = new List<List<Tuple<int, int>>> ( );
			foreach ( string str in paths ) {
				string[ ] tokens = str.Split ( '|' );
				List<Tuple<int, int>> p = new List<Tuple<int, int>> ( );

				// Console.WriteLine ( str );
				Paths.Add ( str );

				foreach ( string token in tokens ) {
					string[ ] nodeTrans = token.Split ( ',' );
					p.Add ( new Tuple<int, int> ( int.Parse ( nodeTrans [ 1 ] ), int.Parse ( nodeTrans [ 0 ] ) ) );
				}

				intPaths.Add ( p );
			}

			return intPaths;
		}

		private List<Tuple<Node, Transition>> GetNodesWithTransitionsFrom ( Node p_node ) {
			List<Tuple<Node, Transition>> myNodes = new List<Tuple<Node, Transition>> ( );
			for ( int j = 0; j < p_node.Transitions.Count; j++ ) {
				if ( p_node [ j ].GetTo ( ) == -1 ) {
					myNodes.Add ( new Tuple<Node, Transition> ( Nodes [ Nodes.Count - 3 ], p_node.Transitions [ j ] ) );
				} else if ( p_node [ j ].GetTo ( ) == -2 ) {
						myNodes.Add ( new Tuple<Node, Transition> ( Nodes [ Nodes.Count - 2 ], p_node.Transitions [ j ] ) );
					} else if ( p_node [ j ].GetTo ( ) == -3 ) {
							myNodes.Add ( new Tuple<Node, Transition> ( Nodes [ Nodes.Count - 1 ], p_node.Transitions [ j ] ) );
						} else {
							myNodes.Add ( new Tuple<Node, Transition> ( Nodes [ p_node [ j ].GetTo ( ) ], p_node.Transitions [ j ] ) );
						}
			}

			return myNodes;
		}
	}
}

