using System;

namespace MedicalDataGeneration.DecisionGraphs {

	public enum eGraphGenertorType {
		GENERATOR_TYPE_RANDOM,
		GENERATOR_TYPE_EACH
	}

	public class GraphDataGenerator {

		public GraphDataGenerator ( string p_graphFile, string p_dataOut, string p_keyOut, eGraphGenertorType p_genType = eGraphGenertorType.GENERATOR_TYPE_RANDOM, int p_numLines = 1, long p_seed = 1234, params ePrintColumns[] p_columns ) {
			DecisionGraph graph = new DecisionGraph ( p_graphFile, p_seed );

			if ( p_genType == eGraphGenertorType.GENERATOR_TYPE_RANDOM ) {
				if ( p_columns.Length > 0 ) {
					graph.GenerateRandomData ( p_dataOut, p_keyOut, p_numLines, p_columns );
				} else {
					graph.GenerateRandomData ( p_dataOut, p_keyOut, p_numLines );
				}
			} else if ( p_genType == eGraphGenertorType.GENERATOR_TYPE_EACH ) {
				if ( p_columns.Length > 0 ) {
					graph.GenerateEachData ( p_dataOut, p_keyOut, p_columns );
				} else {
					graph.GenerateEachData ( p_dataOut, p_keyOut );
				}
			}
		}
	}
}

