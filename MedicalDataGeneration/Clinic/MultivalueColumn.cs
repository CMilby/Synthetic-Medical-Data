using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDataGeneration.Clinic {

	public class MultivalueColumn : Column {

		public Dictionary< string, Func < Column > > HeaderMapper;
		protected Random Random;

		public MultivalueColumn ( ) : base ( "" ) {
			HeaderMapper = new Dictionary < string, Func < Column > > ( );
			Random = new Random ( 1234 );
		}

		public MultivalueColumn ( Random p_random ) : base ( "" ) {
			HeaderMapper = new Dictionary < string, Func < Column > > ( );
			Random = p_random;
		}
	}
}
