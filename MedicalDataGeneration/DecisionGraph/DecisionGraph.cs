using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace MedicalDataGeneration.DecisionGraphs {
	
	public class DecisionGraph {

		private List<Node> Nodes;
		private List<GraphVariable> Variables;
		private List<string> Disorders;

		private Random Random;

		public DecisionGraph ( string p_file, long p_seed = 1234 ) {
			Nodes = new List<Node> ( );
			Variables = new List<GraphVariable> ( );
			Disorders = new List<string> ( );

			Random = new Random ( p_seed );

			LoadDecisionGraphXML ( p_file );

			for ( int i = 0; i < 100; i++ ) {
				Console.WriteLine ( GeneratePersonFollowBranch ( new List<int> ( ) { 0, 4, 5, 6, 7, -2 } ).ToCSV ( ) );
			}
		}

		private Person GeneratePersonFollowBranch ( List<int> p_branch ) {
			Person person = new Person ( Random );

			int i = 0;
			for ( ; i < p_branch.Count; i++ ) {
				Node next = Nodes [ p_branch [ i ] ];
				if ( p_branch[ i + 1 ] < 0 ) {
					break; // Allow or deny state
				}

				Transition trans = next.GetTransitionWithDestinationId ( p_branch [ i + 1 ] );
				switch ( trans.GetComparator ( ) ) {
					case eTransitionComparisons.COMPARE_AGE:
						trans.CreateAgeFromConditions ( ref person, Random );
						break;
					case eTransitionComparisons.COMPARE_DISORDERS:
						trans.CreateDisordersFromConditions ( ref person );
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

			foreach ( XElement element in myXML.Element ( "variables" ).Elements ( ) ) {
				Variables.Add ( new GraphVariable ( element.Attribute ( "name" ).Value,
													element.Attribute ( "value" ).Value ) );
			}

			foreach ( XElement element in myXML.Element ( "graph" ).Elements ( ) ) {
				foreach ( XElement node in element.Elements ( "node" ) ) {
					Node n = new Node ( int.Parse( node.Attribute ( "id" ).Value ) );
					foreach ( XElement transition in node.Elements ( "transition" ) ) {
						Transition t = new Transition ( int.Parse ( transition.Attribute ( "to" ).Value ),
							               Transition.StringToTransitionComparison ( transition.Attribute ( "compare" ).Value ),
							               transition.Attribute ( "condition" ).Value );
						n.AddTransition ( t );
					}
					Nodes.Add ( n );
				}
			}

			Nodes.Sort ( ); // Sorted by Id
		}

		private List<List<int>> TraverseAllPaths ( ) {
			return new List<List<int>> ( );
		}
	}
}

