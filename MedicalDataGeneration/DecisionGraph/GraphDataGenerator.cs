using System;

namespace MedicalDataGeneration.DecisionGraphs {

	public enum eGraphGenertorType {
		GENERATOR_TYPE_RANDOM,
		GENERATOR_TYPE_EACH
	}

	public class GraphDataGenerator {

		public GraphDataGenerator ( string p_graphFile, string p_dataOut, string p_keyOut, eGraphGenertorType p_genType = eGraphGenertorType.GENERATOR_TYPE_RANDOM, int p_numLines = 1, long p_seed = 1234 ) {
			DecisionGraph graph = new DecisionGraph ( p_graphFile, p_seed );

			if ( p_genType == eGraphGenertorType.GENERATOR_TYPE_RANDOM ) {
				graph.GenerateRandomData ( p_dataOut, p_keyOut, p_numLines );
			} else if ( p_genType == eGraphGenertorType.GENERATOR_TYPE_EACH ) {
				graph.GenerateEachData ( p_dataOut, p_keyOut );
			}
		}
	}
}

