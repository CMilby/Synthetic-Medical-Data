using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace MedicalDataGeneration.Clinic {

	public class ClinicGenerator {

		public enum eGeneratorType {
			GENERATOR_CSV,
			GENERATOR_XML
		}

		private Random Random;

		public ClinicGenerator( string p_outFile, int p_numLines, long p_seed, eGeneratorType p_type = eGeneratorType.GENERATOR_CSV ) {
			Random = new Random ( p_seed );

			HospitalColumnPool.Init ( 5, Random );

			if ( p_type == eGeneratorType.GENERATOR_CSV ) {
				Generate ( p_outFile, p_numLines );
			} else if ( p_type == eGeneratorType.GENERATOR_XML ) {
				GenerateXML ( p_outFile, p_numLines );
			}
		}

		private Column [ ] GenColumns( Random p_random, PatientColumn p_patient, DoctorColumn p_attendingDoctor, DoctorColumn p_orderingDoctor ) {
			HospitalColumn hospital = HospitalColumnPool.GetHospital ( p_random );
			DoctorColumn firstReading = new DoctorColumn ( p_random, "FirstReading" );
			DoctorColumn firstAttending = new DoctorColumn ( p_random, "FirstAddending" );
			ProcedureColumn procedure = new ProcedureColumn ( p_random );
			DateGeneratorColumn dates = new DateGeneratorColumn ( p_random );

			Column [ ] columns = new Column [ ] {
				p_patient [ PatientColumn.ePatientColumns.FIRST_NAME ],
				new EmptyColumn ( "FirstAddendingFirstName" ),
				new RandomFillColumn ( "TechnicalAccountingUnit", 0.35f, p_random, new RandomNumberColumn ( "TechnicalAccountingUnit", p_random, 100000, 999999, 6 ) ),
				new RandomFillColumn ( "LastSigningEmployeeTypeId", 0.5f, p_random, new ConstantColumn ( "LastSigningEmployeeTypeId", "10" ) ),
				new RandomFillColumn ( "CancelDescription", 0.2f, p_random, new ConstantColumn ( "CancelDescription", "MISCELLANEOUS" ) ),
				new ConstantColumn ( "Type", "Study" ),
				new EmptyColumn ( "ProcedureSubspeciality" ),
				p_orderingDoctor [ DoctorColumn.eDoctorColumns.NPI ],
				new ConstantColumn ( "ProcedureReason", "Test" ),
				new RandomFillColumn ( "FirstAddendingEmployeeTypeDescription", 0.1f, p_random, new ConstantColumn ( "FirstAddendingEmployeeTypeDescription", "Staff" ) ),
				new IncrementalColumn ( "ID", 100000 ),
				p_patient [ PatientColumn.ePatientColumns.DATE_OF_BIRTH ],
				new EmptyColumn ( "LateralityDescription" ),
				new ConstantColumn ( "IsReportable", "1" ),
				new RandomFillColumn ( "MRNAssigningAuthority", 0.5f, p_random, new ConstantColumn ( "MRNAssigningAuthority", "CCF" ) ),
				new RandomFillColumn ( "FirstReadingEmployeeTypeDescription", 0.5f, p_random, new ConstantColumn ( "FirstReadingEmployeeTypeDescription", "Staff" ) ),
				dates [ DateGeneratorColumn.eDateGeneratorColumns.LEFT_DEPT_DATE_TIME ],
				new ConstantColumn ( "IsFamilyHealthCenter", "FALSE" ),
				new EmptyColumn ( "Impression" ),
				new RandomFillColumn ( "LastSigningEmployeeTypeDescription", 0.5f, p_random, new ConstantColumn ( "LastSigningEmployeeTypeDescription", "Staff" ) ),
				p_orderingDoctor [ DoctorColumn.eDoctorColumns.NUMBER ],
				dates [ DateGeneratorColumn.eDateGeneratorColumns.LAST_SIGNING_DATE_TIME ],
				new EmptyColumn ( "FirstReadingLastName" ),
				hospital [ HospitalColumn.eHospitalColumns.CODE ],
				new EmptyColumn ( "FirstAddendingEmployeeTypeID" ),
				p_orderingDoctor [ DoctorColumn.eDoctorColumns.LAST_NAME ],
				dates [ DateGeneratorColumn.eDateGeneratorColumns.ENTER_DEPT_DATE_TIME ],
				p_patient [ PatientColumn.ePatientColumns.LAST_NAME ],
				new EmptyColumn ( "OrderingDoctorMiddleName" ),
				hospital [ HospitalColumn.eHospitalColumns.DESCRIPTION ],
				procedure [ ProcedureColumn.eProcedureColumns.PROCEDURE_CODE ],
				new EmptyColumn ( "LateralityCode" ),
				new EmptyColumn ( "LastSigningNPI" ),
				p_patient [ PatientColumn.ePatientColumns.SEX ],
				new EmptyColumn ( "AttendingDoctorMiddleName" ),
				p_patient [ PatientColumn.ePatientColumns.MRN ],
				new EmptyColumn ( "PatientClassCode" ),
				dates [ DateGeneratorColumn.eDateGeneratorColumns.FIRST_SIGN_DATE_TIME ],
				new EmptyColumn ( "LastSigningFirstName" ),
				new EmptyColumn ( "FirstSigningMiddleName" ),
				new EmptyColumn ( "FirstAddendingNPI" ),
				procedure [ ProcedureColumn.eProcedureColumns.PROCEDURE_DESCRIPTION ],
				new ConstantColumn ( "EnterpriseMRN", "E" + p_patient.GetMRN ( ).Generate ( ) ),
				p_patient [ PatientColumn.ePatientColumns.AGE_END ],
				new EmptyColumn ( "FirstReadingMiddleName" ),
				new RandomNumberColumn ( "DepartmentKey", p_random, 1000, 9999 ),
				new IncrementalColumn ( "Accession", 100000 ),
				dates [ DateGeneratorColumn.eDateGeneratorColumns.ORDERED_FOR_DATE_TIME ],
				new EmptyColumn ( "LastSigningMiddleName" ),
				new RandomFillColumn ( "StudyTypeCPTCode", 0.75f, p_random, new RandomNumberColumn ( "StudyTypeCPTCode", p_random, 10000, 99999 ) ),
				dates [ DateGeneratorColumn.eDateGeneratorColumns.FIRST_READING_DATE_TIME ],
				dates [ DateGeneratorColumn.eDateGeneratorColumns.BEGIN_PROCEDURE_DATE_TIME ],
				p_attendingDoctor [ DoctorColumn.eDoctorColumns.LAST_NAME ],
				procedure [ ProcedureColumn.eProcedureColumns.BODY_PART ],
				new EmptyColumn ( "TotalImagesWithinStudy" ),
				new EmptyColumn ( "FirstReadingNPI" ),
				dates [ DateGeneratorColumn.eDateGeneratorColumns.FIRST_ADDENDUM_DATE_TIME ],
				new EmptyColumn ( "PatientClassDescription" ),
				new EmptyColumn ( "FirstSigningEmployeeTypeID" ),
				procedure [ ProcedureColumn.eProcedureColumns.MODE_DESCRIPTION ],
				new EmptyColumn ( "FirstReadingDoctorKey" ),
				new EmptyColumn ( "LastSigningDoctorKey" ),
				new EmptyColumn ( "FirstAddendingMiddleName" ),
				new EmptyColumn ( "ResourceKey" ),
				new EmptyColumn ( "AttendingDoctorNPI" ),
				dates [ DateGeneratorColumn.eDateGeneratorColumns.ORIGINAL_ORDERED_ON_DATE_TIME ],
				new EmptyColumn ( "FirstReadingEmployeeTypeID" ),
				p_attendingDoctor [ DoctorColumn.eDoctorColumns.FIRST_NAME ],
				new EmptyColumn ( "AttendingDoctorNumber" ),
				new EmptyColumn ( "FirstSigningNPI" ),
				new EmptyColumn ( "OrderingDoctorSKey" ),
				new EmptyColumn ( "DepartmentLongName" ),
				new EmptyColumn ( "FirstSigningEmployeeTypeDescription" ),
				p_orderingDoctor [ DoctorColumn.eDoctorColumns.FIRST_NAME ],
				procedure [ ProcedureColumn.eProcedureColumns.MODE_CODE ],
				new EmptyColumn ( "FirstSigningLastName" ),
				new EmptyColumn ( "ProcedurePriority" ),
				new RandomNumberColumn ( "StudySKey", p_random, 100, 10000 ),
				new ConstantColumn ( "ProcedureIsActive", "0" ),
				new EmptyColumn ( "FirstSigningDoctorKey" ),
				dates [ DateGeneratorColumn.eDateGeneratorColumns.END_PROCEDURE_DATE_TIME ],
				new EmptyColumn ( "DepartmentCode" ),
				new EmptyColumn ( "ResourceCode" ),
				new EmptyColumn ( "AttendingDoctorSKey" ),
				dates [ DateGeneratorColumn.eDateGeneratorColumns.ORDERED_ON_DATE_TIME ],
				new EmptyColumn ( "VisitDiagnosis" ),
				new ConstantColumn ( "IsBilled", "1" ),
				firstAttending [ DoctorColumn.eDoctorColumns.LAST_NAME ],
				p_attendingDoctor [ DoctorColumn.eDoctorColumns.LAST_NAME ],
				new EmptyColumn ( "FirstSigningFirstName" ),
				new EmptyColumn ( "ResourceDescription" ),
				new EmptyColumn ( "PatientMiddleName" ),
				new EmptyColumn ( "LastSigningLastName" ),
				new EmptyColumn ( "CancelCode" ),
				new EmptyColumn ( "FirstReadingFirstName" ),
				new EmptyColumn ( "StudyTypeCPTDescription" )
			};

			return columns;
		}

		private void Generate( string p_outFile, int p_lineNums ) {
			FileStream fs = new FileStream ( p_outFile, FileMode.Create );

			PatientColumn patient = new PatientColumn ( Random );
			DoctorColumn attendingDoctor = new DoctorColumn ( Random, "Attending" );
			DoctorColumn orderingDoctor = new DoctorColumn ( Random, "Ordering" );
			Column [ ] columns = GenColumns ( Random, patient, attendingDoctor, orderingDoctor );

			using ( StreamWriter sw = new StreamWriter ( fs ) ) {
				for ( int j = 0; j < columns.Length; j++ ) {
					sw.Write ( columns [ j ].Header );
					if ( j != columns.Length - 1 ) {
						sw.Write ( "," );
					}
				}

				sw.WriteLine ( "" );

				for ( int i = 0; i < p_lineNums; ) {
					int visits = Random.Next ( 1, 5 );

					for ( int x = 0; x < visits && i < p_lineNums; x++, i++ ) {
						for ( int j = 0; j < columns.Length; j++ ) {
							sw.Write ( columns [ j ].Generate ( ) );
							if ( j != columns.Length - 1 ) {
								sw.Write ( "," );
							}
						}

						sw.WriteLine ( "" );
						columns = GenColumns ( Random, patient, attendingDoctor, orderingDoctor );
					}

					patient = new PatientColumn ( Random );
					attendingDoctor = new DoctorColumn ( Random, "Attending" );
					orderingDoctor = new DoctorColumn ( Random, "Ordering" );
					columns = GenColumns ( Random, patient, attendingDoctor, orderingDoctor );
				}
			}
		}

		private void GenerateXML ( string p_outFile, int p_lineNums ) {
			PatientColumn patient = new PatientColumn ( Random );
			DoctorColumn attendingDoctor = new DoctorColumn ( Random, "Attending" );
			DoctorColumn orderingDoctor = new DoctorColumn ( Random, "Ordering" );
			Column [ ] columns = GenColumns ( Random, patient, attendingDoctor, orderingDoctor );

			XDocument myDoc = new XDocument ( );
			XElement myRoot = new XElement ( "root" );
			
			for ( int i = 0; i < p_lineNums; ) {
				int visits = Random.Next ( 1, 5 );

				for ( int x = 0; x < visits && i < p_lineNums; x++, i++ ) {
					myRoot.Add ( PatientXML ( columns ) );
					columns = GenColumns ( Random, patient, attendingDoctor, orderingDoctor );
				}

				patient = new PatientColumn ( Random );
				attendingDoctor = new DoctorColumn ( Random, "Attending" );
				orderingDoctor = new DoctorColumn ( Random, "Ordering" );
				columns = GenColumns ( Random, patient, attendingDoctor, orderingDoctor );
			}

			myDoc.Add ( myRoot );
			myDoc.Save ( p_outFile );
		}

		private XElement PatientXML( Column[] p_columns ) {
			XElement myRoot = new XElement ( "Patient" );
			// myRoot.Add ( new XAttribute ( "xmlns", "http://hl7.org/fhir" ) );

			for ( int i = 0; i < p_columns.Length; i++ ) {
				myRoot.Add ( new XElement ( p_columns [ i ].GetHeader ( ), p_columns [ i ].Generate ( ) ) );
			}

			return myRoot;
		}
	}
}
