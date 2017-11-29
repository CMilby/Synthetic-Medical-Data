using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDataGeneration.Clinic {

	public class Column {

		public string Header { get; set; }
			
		public Column ( string p_header ) {
			Header = p_header;
		}

		public virtual string GetHeader ( ) {
			return Header;
		}

		public virtual string Generate ( ) {
			return "";
		}
	}
}
