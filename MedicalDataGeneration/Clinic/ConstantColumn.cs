using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDataGeneration.Clinic {

	public class ConstantColumn : Column {

		private string Constant;

		public ConstantColumn ( string p_header, string p_constant ) : base ( p_header ) {
			Constant = p_constant;
		}

		public override string Generate() {
			return Constant;
		}
	}
}
