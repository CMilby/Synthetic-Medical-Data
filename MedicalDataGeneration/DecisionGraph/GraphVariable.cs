using System;

namespace MedicalDataGeneration {

	public class GraphVariable {

		public string Name;
		public string Value;

		public GraphVariable ( ) {
			Name = Value = "";
		}

		public GraphVariable ( string p_name, string p_value = "" ) {
			Name = p_name;
			Value = p_value;
		}
	}
}

