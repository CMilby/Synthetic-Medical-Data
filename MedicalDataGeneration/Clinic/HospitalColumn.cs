using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDataGeneration.Clinic {

	public class HospitalColumn : MultivalueColumn {

		public enum eHospitalColumns {
			CODE,
			DESCRIPTION
		}

		private string HospitalCode;
		private string Description;

		public HospitalColumn ( Random p_random ) : base ( p_random ) {
			Description = Address.GenerateAddress ( p_random ).City.County + " Medical Center";
			HospitalCode = Description [ 0 ].ToString ( ) + "MC";

			HeaderMapper.Add ( "CODE", GetCode );
			HeaderMapper.Add ( "DESCRIPTION", GetDescription );
		}

		public ConstantColumn GetCode ( ) {
			return new ConstantColumn ( "HospitalCode", HospitalCode );
		}

		public ConstantColumn GetDescription ( ) {
			return new ConstantColumn ( "HospitalDescription", Description );
		}

		public Column this [ eHospitalColumns p_column ] {
			get {
				return HeaderMapper [ p_column.ToString ( ) ] ( );
			}
		}

		public override string Generate() {
			return "";
		}

		public override string GetHeader() {
			return "";
		}
	}

	public static class HospitalColumnPool {

		private static List<HospitalColumn> Pool;

		public static void Init ( int p_poolSize, Random p_random ) {
			Pool = new List<HospitalColumn> ( );

			for ( int i = 0; i < p_poolSize; i++ ) {
				Pool.Add ( new HospitalColumn ( p_random ) );
			}
		}

		public static HospitalColumn GetHospital ( Random p_random ) {
			return Pool [ p_random.Next ( 0, Pool.Count - 1 ) ];
		}

		public static HospitalColumn GetHospital ( int p_index ) {
			return Pool [ p_index ];
		}
	}
}
