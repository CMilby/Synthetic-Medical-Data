using System;

namespace MedicalDataGeneration.DecisionGraphs {

	public class GraphDataGenerator {

		public GraphDataGenerator ( string p_graphFile, string p_outFile, int p_numLines, long p_seed = 1234 ) {
			new DecisionGraph ( p_graphFile, p_outFile, p_numLines, p_seed );
		}
	}
}

