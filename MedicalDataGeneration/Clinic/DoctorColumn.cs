using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDataGeneration.Clinic {

	public class DoctorColumn : MultivalueColumn {

		private Person Person;

		private string Type;
		private int NPI;

		public enum eDoctorColumns {
			FIRST_NAME,
			LAST_NAME,
			NPI
		}

		public DoctorColumn ( Random p_random, string p_type ) : base ( p_random ) {
			Person = new Person ( Random );

			NPI = p_random.Next ( 100000, 999999 );

			HeaderMapper.Add ( "FIRST_NAME", FirstName );
			HeaderMapper.Add ( "LAST_NAME", LastName );
			HeaderMapper.Add ( "NPI", GetNPI );
		}

		public Column this [ eDoctorColumns p_column ] {
			get {
				return HeaderMapper [ p_column.ToString ( ) ] ( );
			}
		}

		public ConstantColumn FirstName() {
			return new ConstantColumn ( Type + "FirstName", Person.Name.FirstName );
		}

		public ConstantColumn LastName() {
			return new ConstantColumn ( Type + "LastName", Person.Name.LastName );
		}

		public ConstantColumn GetNPI ( ) {
			return new ConstantColumn ( Type + "DoctorNPI", NPI.ToString ( ) );
		}

		public override string GetHeader() {
			return "";
		}

		public override string Generate() {
			return "";
		}
	}
}
