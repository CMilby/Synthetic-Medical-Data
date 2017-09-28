using System;
using System.Collections.Generic;

namespace MedicalDataGeneration.DecisionGraphs {

	public class Node : IComparable {

		public int Id { get; set; }
		public List<Transition> Transitions { get; set; }

		public Node ( int p_id ) {
			Id = p_id;
			Transitions = new List<Transition> ( );
		}

		public void AddTransition ( Transition p_transition ) {
			Transitions.Add ( p_transition );
		}

		public Transition this [ int p_index ] {
			get { return Transitions [ p_index ]; }
			set { Transitions [ p_index ] = value; }
		}

		public Transition GetTransitionWithDestinationId ( int p_id ) {
			for ( int i = 0; i < Transitions.Count; i++ ) {
				if ( Transitions [ i ].GetTo ( ) == p_id ) {
					return Transitions [ i ];
				}
			}

			return null;
		}

		public int GetTransitionIndexWithDestinationId ( int p_id ) {
			for ( int i = 0; i < Transitions.Count; i++ ) {
				if ( Transitions [ i ].GetTo ( ) == p_id ) {
					return i;
				}
			}

			return -1;
		}

		public int CompareTo ( object p_obj ) {
			if ( p_obj == null ) {
				return 1;
			}

			Node node = p_obj as Node;
			if ( node != null ) {
				return Id.CompareTo ( node.Id );
			} else {
				throw new ArgumentException ( "Object is not a Node" );
			}
		}
	}
}

