using System;
using System.Collections.Generic;

namespace MedicalDataGeneration.Clinic {

	public class PatientColumn : MultivalueColumn {

		private Person Person;

		public enum ePatientColumns {
			FIRST_NAME,
			LAST_NAME,
			SEX,
			AGE_END,
			DATE_OF_BIRTH,
		}

		public PatientColumn ( Random p_random ) : base ( p_random ) {
			Person = new Person ( Random, 1, 1 );

			HeaderMapper.Add ( "FIRST_NAME", FirstName );
			HeaderMapper.Add ( "LAST_NAME", LastName );
			HeaderMapper.Add ( "SEX", Sex );
			HeaderMapper.Add ( "AGE_END", AgeEnd );
			HeaderMapper.Add ( "DATE_OF_BIRTH", DateOfBirth );
		}

		public Column this [ ePatientColumns p_column ] {
			get {
				return HeaderMapper [ p_column.ToString ( ) ] ( );
			}
		}

		public ConstantColumn FirstName ( ) {
			return new ConstantColumn ( "PatientFirstName", Person.Name.FirstName );
		}

		public ConstantColumn LastName() {
			return new ConstantColumn ( "PatientLastName", Person.Name.LastName );
		}

		public ConstantColumn Sex() {
			return new ConstantColumn ( "Sex", Person.Sex.ToString ( ) );
		}

		public ConstantColumn AgeEnd() {
			return new ConstantColumn ( "PatientAgeAtEndProcedure", Person.GetAge () .ToString ( ) );
		}

		public ConstantColumn DateOfBirth() {
			return new ConstantColumn ( "DateOfBirth", Person.DateOfBirth.ToString ( "yyyy-MM-dd" ) );
		}

		public override string GetHeader() {
			return "";
		}

		public override string Generate() {
			return "";
		}
	}
}
